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

public class LobbyUI : NetworkBehaviour
{
    public TextMeshProUGUI PlayerInfoPrefab;
    public Button StartButton;

    private NetworkList<LobbyPlayer> lobbyPlayers = new NetworkList<LobbyPlayer>();

    public override void NetworkStart()
    {
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
        LobbyPlayer player = new LobbyPlayer(clientID);
        lobbyPlayers.Add(player);
    }

    private void HandleClientDisconnected(ulong clientID)
    {
        for (int i = 0; i < lobbyPlayers.Count; i++)
        {
            LobbyPlayer player = lobbyPlayers[i];
            if (player.ClientID == clientID)
            {
                lobbyPlayers.RemoveAt(i);
            }
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void StartGameServerRpc(ServerRpcParams serverRpcParams = default)
    {
        print("(ServerRpc) Start Game");
        NetworkSceneManager.SwitchScene("SampleScene");
    }

    public void OnLeaveClicked()
    {
        if (IsHost)
        {
            for (int i = 0; i < NetworkManager.Singleton.ConnectedClientsList.Count; i++) // Katki 
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

    private void HandleLobbyPlayerStateChanged(NetworkListEvent<LobbyPlayer> changeEvent)
    {
        for (int i = 0; i < lobbyPlayers.Count; i++)
        {
            LobbyPlayer player = lobbyPlayers[i];
            if (lobbyPlayers.Count > i)
            {
                player.UpdateDisplay(player);
            }
            else
            {
                player.DisableDisplay();
            }
        }
    }
}
