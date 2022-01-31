using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    public GameObject[] RoadPrefabs;
    private List<GameObject> currentBlocks=new List<GameObject>();
    private Vector3 StartPosition;
    private float blockLength;
    public GameObject StartBlock;
    public PlayerController PlayerPosition;
    void Start()
    {
        blockLength = StartBlock.transform.GetComponent<BoxCollider>().bounds.size.z;
        StartPosition = StartBlock.transform.position;
        Destroy(StartBlock);
    }

    void LateUpdate()
    {
        
        CheckForSpawn();
    }


    void SpawnBlock()
    {
        Vector3 blockPosition;
        if (currentBlocks.Count == 0)
        {
            blockPosition = StartPosition;
        }
        else
        {
            blockPosition = currentBlocks[currentBlocks.Count - 1].transform.position + new Vector3(0,0,blockLength);
        }

        GameObject Block;
        Block = Instantiate(RoadPrefabs[UnityEngine.Random.Range(0, RoadPrefabs.Length)], transform);
        Block.transform.position = blockPosition;
        currentBlocks.Add(Block);
    }

    void CheckForSpawn()
    {
        if (currentBlocks.Count < 10)
        {
            SpawnBlock();
        }

        if (PlayerPosition.transform.position.z- currentBlocks[0].transform.position.z > blockLength)
        {
            DestroyBlock();
        }
    }

    void DestroyBlock()
    {
        Destroy(currentBlocks[0].gameObject);
        currentBlocks.RemoveAt(0);
    }
}


