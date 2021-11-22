using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MLAPI;
using MLAPI.Connection;
using MLAPI.NetworkVariable.Collections;
using System;
using UnityEngine.UI;
using MLAPI.Messaging;
using MLAPI.SceneManagement;
using UnityEngine.SceneManagement;
using MLAPI.Spawning;

public class LobbyUI : NetworkBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject PlayerInfoPrefab;
    public GameObject PlayerListPanel; 
    public Button StartButton;

    private NetworkList<LobbyPlayerData> lobbyPlayers = new NetworkList<LobbyPlayerData>();

    public override void NetworkStart()
    {
        print(GetComponent<NetworkObject>().IsSpawned);
        if (IsClient)
        {
            lobbyPlayers.OnListChanged += HandleLobbyPlayerStateChanged;
        }

        if (IsHost)
        {
            StartButton.gameObject.SetActive(true);

            NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnected;

            foreach (NetworkClient client in NetworkManager.Singleton.ConnectedClientsList)
            {
                HandleClientConnected(client.ClientId);
            }
        }
    }

    private void OnDestroy()
    {
        lobbyPlayers.OnListChanged -= HandleLobbyPlayerStateChanged;

        if (NetworkManager.Singleton)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnected;
        }
    }

    private void HandleClientConnected(ulong clientID)
    {
        GameObject display = Instantiate(PlayerInfoPrefab, PlayerListPanel.transform);
        display.GetComponent<NetworkObject>().SpawnWithOwnership(clientID);
        LobbyPlayerData player = new LobbyPlayerData(clientID, display);
        lobbyPlayers.Add(player);
    }

    private void HandleClientDisconnected(ulong clientID)
    {
        for (int i = 0; i < lobbyPlayers.Count; i++)
        {
            LobbyPlayerData player = lobbyPlayers[i];
            if (player.ClientID == clientID)
            {
                lobbyPlayers.RemoveAt(i);
            }
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void StartGameServerRpc(ServerRpcParams serverRpcParams = default)  // TODO Player spawning on valel hetkel, kuskile peaks tegema eventlisteneri
    {
        print("(ServerRpc) Start Game");
        for (int i = 0; i < lobbyPlayers.Count; i++)
        {
            LobbyPlayerData playerData = lobbyPlayers[i];
            GameObject player = Instantiate(PlayerPrefab);
            player.GetComponent<NetworkObject>().SpawnWithOwnership(playerData.ClientID);
        }
        NetworkSceneManager.SwitchScene("SampleScene");
    }

    public void OnLeaveClicked()
    {
        if (IsHost)
        {
            for (int i = 0; i < NetworkManager.Singleton.ConnectedClientsList.Count; i++) // BUG katki 
            {
                NetworkClient client = NetworkManager.Singleton.ConnectedClientsList[i];
                NetworkManager.Singleton.DisconnectClient(client.ClientId);
            }
            foreach (NetworkClient client in NetworkManager.Singleton.ConnectedClientsList)
            {
                NetworkManager.Singleton.DisconnectClient(client.ClientId);
            }
            NetworkManager.Singleton.StopHost();
        }
        else
        {
            NetworkManager.Singleton.StopClient();
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void OnStartGameClicked()
    {
        StartGameServerRpc();
    }

    private void HandleLobbyPlayerStateChanged(NetworkListEvent<LobbyPlayerData> changeEvent)
    {
        print("HandleLobbyPlayerStateChanged");
        for (int i = 0; i < NetworkManager.Singleton.ConnectedClientsList.Count; i++)
        {
            LobbyPlayerData player = lobbyPlayers[i];
            if (lobbyPlayers.Count > i)
            {
                player.UpdateDisplay(player);
                UpdateDisplayClientRpc(player);
                //ReparentClientRpc(player);
                //AddClientInfoDisplayServerRpc(player);
            }
            else
            {

                player.DisableDisplay();
                //RemoveClientInfoDisplayServerRpc(player.ClientID);
            }
        }
    }
    
    [ServerRpc]
    private void AddClientInfoDisplayServerRpc(LobbyPlayerData player)
    {
        player.UpdateDisplay(player);
    }

    [ServerRpc]
    private void RemoveClientInfoDisplayServerRpc(ulong clientID)
    {
        Events.DestroyPlayerInfoDisplay(clientID);
        print("Remove");
    }

    [ClientRpc]
    private void UpdateDisplayClientRpc(LobbyPlayerData player)
    {
        GameObject display = Instantiate(PlayerInfoPrefab, PlayerListPanel.transform);
    }
}
