using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    public GameObject[] blocks;
    // Start is called before the first frame update
    void Start()
    {
        dropBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dropBlock()
    {
        float randomBlock = Random.Range(0, 1f);
        randomBlock *= blocks.Length;
        Instantiate(blocks[Mathf.FloorToInt(randomBlock)],transform.position, Quaternion.identity);
    }
}
