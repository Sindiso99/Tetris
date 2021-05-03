using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private Vector3 direction;
    public Vector3 ReadInput()
    {
        float x = 0;
        float y = 0;
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y = -1;
        }
        //Object falls at a constant rate

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y = 1;
        }

        if (x != 0 || y!= 0)
        {
            direction = new Vector3(x, y, 0);
            return direction;
        } else
        {
            return Vector3.zero;
        }
    }
}
