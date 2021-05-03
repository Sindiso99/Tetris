using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject nextBlock;
    public int nextIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        nextBlock = getRandomBlock();
        dropBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dropBlock()
    {
        Instantiate(nextBlock,transform.position, Quaternion.identity);
        nextBlock = getRandomBlock();
        FindObjectOfType<NextBlock>().ShowNext(nextIndex);

    }

    public GameObject getRandomBlock()
    {
        float randomBlock = Random.Range(0, 1f);
        randomBlock *= blocks.Length;
        nextIndex = Mathf.FloorToInt(randomBlock);
        return blocks[nextIndex];
    }
}
