using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI.Serialization;
using System;
using TMPro;
using MLAPI;

public struct LobbyPlayer : INetworkSerializable
{
    public ulong ClientID;
    public GameObject PlayerInfoObject;

    public LobbyPlayer(ulong clientID, GameObject playerInfoObject)
    {
        ClientID = clientID;
        PlayerInfoObject = playerInfoObject;
    }

    public void NetworkSerialize(NetworkSerializer serializer)
    {
        serializer.Serialize(ref ClientID);
    }

    public void UpdateDisplay(LobbyPlayer player)   // TODO Visuaalselt vaja näidata mängijat listis
    {
        Debug.Log("Update display");
        ClientID = player.ClientID;
        PlayerInfoObject.GetComponent<TextMeshProUGUI>().text = "Player " + player.ClientID.ToString();
    }

    public void DisableDisplay()    // TODO Eemaldada mängija listis
    {
        Debug.Log("Disable display");
    }
}
