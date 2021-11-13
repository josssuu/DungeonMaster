using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action OnSpawnNetworkObjects;
    public static void SpawnNetworkObjects() => OnSpawnNetworkObjects?.Invoke();

    public static event Action OnJoinPlayerList;
    public static void JoinPlayerList() => OnJoinPlayerList?.Invoke();
    public static event Action OnLeavePlayerList;
    public static void LeavePlayerList() => OnLeavePlayerList?.Invoke();
}
