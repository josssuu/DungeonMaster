using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    public static Game Instance;

    public GameObject TreePrefab;
    public GameObject BlockPrefab;
    public float TreeDistance = 1f; 
    public float BlockDistance = 1f;

    public float Speed = 1f;
    private List<GameObject> _trees;
    private List<GameObject> _blocks;
    private bool _stop;

	void Start () {
        
        _stop = false;
        Instance = this;
        _trees = new List<GameObject>();
        _blocks = new List<GameObject>();
        for (int i = 0; i < 12; i++)
        {
            GameObject tree = GameObject.Instantiate(TreePrefab);
            GameObject block = GameObject.Instantiate(BlockPrefab);
            _trees.Add(tree);
            _blocks.Add(block);

            tree.transform.position = new Vector3(TreeDistance*i, -4.8f, 0f);
            tree.transform.rotation = Quaternion.Euler(0, 0, 90);

            block.transform.position = new Vector3(BlockDistance * i, Random.Range(-4.8f, 0f), 0);
        }
    }
	
	void Update () {
        
        {

            foreach (GameObject tree in _trees)
            {
                tree.transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
                
                if (tree.transform.position.x < -TreeDistance * (_trees.Count / 2f))
                {
                    

                    ScoreScript.scoreValue += 1;

                }
                if (tree.transform.position.x < -TreeDistance * (_trees.Count / 2f))
                {
                    tree.transform.position += new Vector3(TreeDistance * _trees.Count, 0f, 0f);
                }
            }
            
            foreach (GameObject block in _blocks)
            {
                block.transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
                if (block.transform.position.x < -BlockDistance * (_blocks.Count / 2f))
                {
                    block.transform.position += new Vector3(BlockDistance * _blocks.Count, 0f, 0f);
                }
            }
            
        }
	}

    public void Restart()
    {
        ScoreScript.scoreValue = 0;
        foreach (GameObject tree in _trees)
        {
            GameObject.Destroy(tree);
            
        }
        foreach (GameObject block in _blocks)
        {
            GameObject.Destroy(block);

        }
        Start();
    }
    
    
    public void StopGame()
    {
        _stop = true;
    }
}
