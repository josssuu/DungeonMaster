using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action<ulong> OnDestroyPlayerInfoDisplay;
    public static void DestroyPlayerInfoDisplay(ulong clientID) => OnDestroyPlayerInfoDisplay?.Invoke(clientID);
}
