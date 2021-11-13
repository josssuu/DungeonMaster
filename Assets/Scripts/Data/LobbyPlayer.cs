using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI.Serialization;
using System;

public class LobbyPlayer : INetworkSerializable
{
    public ulong ClientID;

    public LobbyPlayer(ulong clientID)
    {
        ClientID = clientID;
    }

    public void NetworkSerialize(NetworkSerializer serializer)
    {
        serializer.Serialize(ref ClientID);
    }

    public void UpdateDisplay(LobbyPlayer player)
    {
        Debug.Log("Update display");
        ClientID = player.ClientID;
    }

    public void DisableDisplay()
    {
        Debug.Log("Disable display");
        throw new NotImplementedException();
    }
}
