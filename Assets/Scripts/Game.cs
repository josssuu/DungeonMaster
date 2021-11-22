using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class Game : NetworkBehaviour
{
    public static Game Instance;

    public GameObject TreePrefab;
    public GameObject BlockPrefab;
    public GameObject Upgrade;
    public float TreeDistance = 1f;
    public float BlockDistance = 1f;
    public float UpgradeDistance = 1f;

    public float Speed = 1f;
    private List<GameObject> _trees;
    private List<GameObject> _blocks;
    private List<GameObject> _upgrades;
    private bool _stop;

    void Start()
    {
        _stop = false;
        Instance = this;
        _trees = new List<GameObject>();
        _blocks = new List<GameObject>();
        _upgrades = new List<GameObject>();
        for (int i = 0; i < 16; i++)
        {
            GameObject tree = Instantiate(TreePrefab);
            GameObject block = Instantiate(BlockPrefab);
            //tree.GetComponent<NetworkObject>().Spawn();
            //block.GetComponent<NetworkObject>().Spawn();
            _trees.Add(tree);
            _blocks.Add(block);

            tree.transform.position = new Vector3(TreeDistance * i, -4.8f, 0f);
            tree.transform.rotation = Quaternion.Euler(0, 0, 90);

            block.transform.position = new Vector3(BlockDistance * i, Random.Range(-4.8f, 0f), 0);

            if (i == 4 | i == 14)
            {
                GameObject upgrade = Instantiate(Upgrade);
                //upgrade.GetComponent<NetworkObject>().Spawn();

                _blocks.Add(upgrade);
                upgrade.transform.position = new Vector3(UpgradeDistance * i * 3f, Random.Range(-4f, -1.2f), 0);
            }
        }
    }

    void Update()
    {
        {
            Speed += Time.deltaTime * 1.01f;
            BlockDistance = Random.Range(5f, 15f);
            UpgradeDistance = Random.Range(5f, 15f);

            foreach (GameObject tree in _trees)
            {
                tree.transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);

                if (tree.transform.position.x < -TreeDistance * (_trees.Count / 2.5f))
                {
                    ScoreScript.scoreValue += 1;
                }

                if (tree.transform.position.x < -TreeDistance * (_trees.Count / 2.5f))
                {
                    tree.transform.position += new Vector3(TreeDistance * _trees.Count, 0f, 0f);
                }
            }

            foreach (GameObject block in _blocks)
            {
                block.transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
                if (block.transform.position.x < -BlockDistance * (_blocks.Count / 2.5f))
                {
                    block.transform.position += new Vector3(BlockDistance * _blocks.Count, 0f, 0f);
                }
            }

            foreach (GameObject upgrade in _upgrades)
            {
                upgrade.transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
                if (upgrade.transform.position.x < -UpgradeDistance * (_upgrades.Count / 2.5f))
                {
                    upgrade.transform.position += new Vector3(UpgradeDistance * _upgrades.Count, 0f, 0f);
                }
            }
        }
    }

    public void Restart()
    {
        ScoreScript.scoreValue = 0;
        foreach (GameObject tree in _trees)
        {
            //tree.GetComponent<NetworkObject>().Despawn(true);
            Destroy(tree);
        }

        foreach (GameObject block in _blocks)
        {
            //block.GetComponent<NetworkObject>().Despawn(true);
            Destroy(block);
        }

        foreach (GameObject upgrade in _upgrades)
        {
            //upgrade.GetComponent<NetworkObject>().Despawn(true);
            Destroy(upgrade);
        }

        Start();
    }


    public void StopGame()
    {
        _stop = true;
    }
}