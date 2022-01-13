using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class Game : NetworkBehaviour
{
    public static Game Instance;

    public GameObject TreePrefab;
    public GameObject BlockPrefab;
    public GameObject SpeedUpgrade;
    public GameObject JumpUpgrade;
    public GameObject Background;
    public float TreeDistance = 1f;
    public float BlockDistance = 1f;
    public float UpgradeDistance = 1f;
    public float UpgradeDistance2 = 2f;

    public float Speed = 1f;
    private List<GameObject> _trees;
    private List<GameObject> _blocks;
    private List<GameObject> _upgrades;
    private List<GameObject> _upgradesJump;
    private bool _stop;
    private float width;

    void Start()
    {
        _stop = false;
        Instance = this;
        _trees = new List<GameObject>();
        _blocks = new List<GameObject>();
        _upgrades = new List<GameObject>();
        _upgradesJump = new List<GameObject>();
        for (int i = 0; i <= 16; i++)
        {
            //BoxCollider2D BackgroundColliderl = Background.GetComponent<BoxCollider2D>();
            //Rigidbody2D BackGroundRigidBody2D = Background.GetComponent<Rigidbody2D>();
            width = 0;
            //width = BackgroundColliderl.size.x;
            //BackGroundRigidBody2D.velocity = new Vector2(-Speed, 0);
            GameObject tree = Instantiate(TreePrefab);
            GameObject block = Instantiate(BlockPrefab);
            //tree.GetComponent<NetworkObject>().Spawn();
            //block.GetComponent<NetworkObject>().Spawn();
            _trees.Add(tree);
            _blocks.Add(block);

            tree.transform.position = new Vector3(TreeDistance * i, -4.8f, 0f);
            tree.transform.rotation = Quaternion.Euler(0, 0, 90);

            block.transform.position = new Vector3(BlockDistance * i, Random.Range(-4.6f, 0.2f), 0);

            if (i == 4 | i == 14)
            {
                GameObject upgrade = Instantiate(SpeedUpgrade);
                //upgrade.GetComponent<NetworkObject>().Spawn();

                _blocks.Add(upgrade);
                upgrade.transform.position = new Vector3(UpgradeDistance * i * 3f, Random.Range(-4f, -1.2f), 0);
            }

            if (i == 6 || i == 16)
            {
                GameObject jump = Instantiate(JumpUpgrade);
                _blocks.Add(jump);
                jump.transform.position = new Vector3(UpgradeDistance2 * i * 3f, Random.Range(-4f, -1.2f), 0);
            }
        }
    }

    void Update()
    {
        if (Background.transform.position.x < -width)
        {
            Reposition();
        }

        Speed += Time.deltaTime * 0.2f;
        BlockDistance = Random.Range(5f, 15f);
        UpgradeDistance = Random.Range(5f, 15f);
        UpgradeDistance2 = Random.Range(4f, 16f);
        Vector2 backgroundOffset = new Vector2(Time.deltaTime * Speed, 0);


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

        foreach (GameObject jump in _upgradesJump)
        {
            jump.transform.position -= new Vector3(Time.deltaTime * Speed, 1f, 1f);
            if (jump.transform.position.x < -UpgradeDistance2 * (_upgradesJump.Count / 2.5f))
            {
                jump.transform.position += new Vector3(UpgradeDistance2 * _upgradesJump.Count, 1f, 1f);
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

        foreach (GameObject upgrade in _upgradesJump)
        {
            //upgrade.GetComponent<NetworkObject>().Despawn(true);
            Destroy(upgrade);
        }

        Start();
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);
        Background.transform.position = (Vector2) transform.position + vector;
    }


    public void StopGame()
    {
        _stop = true;
    }
}