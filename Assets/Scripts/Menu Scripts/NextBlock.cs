using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBlock : MonoBehaviour
{
    public GameObject[] blocks;
    private GameObject[] oldBlocks;
    // Start is called before the first frame update

    public void ShowNext(int index)
    {
        oldBlocks = GameObject.FindGameObjectsWithTag("Blank");
        foreach(GameObject oldBlock in oldBlocks)
        {
            Destroy(oldBlock);
        }
        
        Instantiate(blocks[index], transform.position, Quaternion.identity);
        
    }
}
