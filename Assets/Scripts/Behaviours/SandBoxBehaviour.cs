using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBoxBehaviour : MonoBehaviour
{
    public static float normalDropSpeed = 1f;
    public static float fasterDropSpeed = 0.05f;
    public static int borderWidth = 20;
    public static int borderHeight = 14;
    public static Transform[,] cells = new Transform[borderWidth, borderHeight];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CheckRows()
    {
        for (int i = borderHeight -1; i >= 0; i--)
        {
            if (completeRow(i))
            {
                deleteRow(i);
                moveDown(i);
            }
        }
    }

    public void deleteRow(int i)
    {
        for (int j = 0; j < borderWidth; j++)
        {
            Destroy(cells[j, i].gameObject);
            cells[j, i] = null;
        }
    }

    private bool completeRow(int i)
    {
        for(int j = 0; j<borderWidth; j++)
        {
            if (cells[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void moveDown(int i)
    {
        for(int y = i; y < borderHeight; y++)
        {
            for (int j = 0; j < borderWidth; j++)
            {
                if(cells[j,y] != null)
                {
                    cells[j, y - 1] = cells[j, y];
                    cells[j, y] = null;
                    cells[j, y - 1].gameObject.transform.position -= new Vector3(0, 1, 0);
                }
            
            }
            }
    }
    
    public void deleteAround(int xCoord, int yCoord)
    {
        
        for (int x = -1; x < 2; x++)
        {
            int curX = xCoord + x;
            if (curX > 0 && curX < borderWidth)
            {
                deleteColumn(curX, yCoord);
            }
        }
    }

    public void deleteColumn(int xCoord, int yCoord)
    {
        for (int y = yCoord; y < borderHeight && y - yCoord > -3 && y >= 0; y--)
        {
            if(cells[xCoord,y] != null)
            {
                Destroy(cells[xCoord, y].gameObject);
                cells[xCoord, y] = null;
            }
        }
    }
}
