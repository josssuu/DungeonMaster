using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using UnityEngine.SceneManagement;

public class NetworkSpawner : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.sceneLoaded += SceneWasLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneWasLoaded;
    }

    private void SceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
        /*
        print(gameObject.name);
        print(gameObject.transform.parent);
        GetComponent<NetworkObject>().Spawn();
        print(gameObject.transform.parent);
        */
    }
}
