using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MLAPI;
using MLAPI.Connection;
using MLAPI.Spawning;
using MLAPI.Messaging;
using MLAPI.NetworkVariable.Collections;
using System;

public class PlayerList : NetworkBehaviour
{
    public TextMeshProUGUI PlayerInfoPrefab;
    private NetworkManager networkManager;

    private NetworkList<LobbyPlayer> lobbyPlayers = new NetworkList<LobbyPlayer>();
    private void Awake()
    {
        networkManager = NetworkManager.Singleton;
        networkManager.OnClientConnectedCallback += HandleClientConnectedServerRpc;
        networkManager.OnClientDisconnectCallback += HandleClientDisConnectedServerRpc;
    }

    private void OnDestroy()
    {
        networkManager.OnClientConnectedCallback -= HandleClientConnectedServerRpc;
        networkManager.OnClientDisconnectCallback -= HandleClientDisConnectedServerRpc;
    }

    public override void NetworkStart()
    {
        if (IsClient)
        {
            lobbyPlayers.OnListChanged += HandleLobbyPlayerStateChanged;
        }

        if (IsServer)
        {

        }
    }

    private void HandleLobbyPlayerStateChanged(NetworkListEvent<LobbyPlayer> changeEvent)
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        print("Start");
        if (IsLocalPlayer || IsHost)
        {
            JoinPlayerListServerRpc(networkManager.LocalClientId);
        }
    }

    [ServerRpc]
    private void JoinPlayerListServerRpc(ulong clientID)
    {
        TextMeshProUGUI prefab = Instantiate(PlayerInfoPrefab);
        prefab.GetComponent<NetworkObject>().Spawn();
        print("PlayerList is spawned: " + transform.GetComponent<NetworkObject>().IsSpawned);
        prefab.text = "Player " + clientID.ToString();
        prefab.transform.SetParent(transform);
    }

    [ServerRpc]
    private void HandleClientConnectedServerRpc(ulong playerID)
    {
        print("Player connected: " + playerID.ToString());
    }

    [ServerRpc]
    private void HandleClientDisConnectedServerRpc(ulong playerID)
    {
        print("Player disconnected: " + playerID.ToString());
    }
}
