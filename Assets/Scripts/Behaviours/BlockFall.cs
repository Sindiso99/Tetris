using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFall : MonoBehaviour
{
    protected  Vector3 leftVector = new Vector3(-1, 0, 0);
    protected  Vector3 rightVector = new Vector3(1, 0, 0);
    protected  Vector3 normalDownVector = new Vector3(0, -1, 0);
    protected  Vector3 upVector = new Vector3(0, 1, 0);
    private  Vector3 rotation = new Vector3(0, 0, 90);
    protected float rateOfFall = 0f;
    protected bool falling = true;
    public GameObject shape;
    protected SandBoxBehaviour sandBoxBehaviour;


    void Start()
    {
        sandBoxBehaviour = FindObjectOfType<SandBoxBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            rateOfFall += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                fall();
            }
            else if (rateOfFall > SandBoxBehaviour.normalDropSpeed)
            {
                fall();
            }
            //Object falls at a constant rate

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                shift(leftVector);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                shift(rightVector);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rotate(rotation);
            }
        }
        
    }

    public void fall()
    {
        gameObject.transform.Translate(normalDownVector);
        rateOfFall = 0f;
        if (!checkValidTransform())
        {
            falling = false;
            gameObject.transform.Translate(upVector);
            addCells();
            sandBoxBehaviour.CheckRows();
            FindObjectOfType<BlockCreator>().dropBlock();
        }
    }

    public void shift(Vector3 direction)
    {
        gameObject.transform.position += direction;
        if (!checkValidTransform())
        {
            gameObject.transform.position -= direction;
        }
    }

    public virtual void rotate(Vector3 degrees)
    {
        shape.transform.Rotate(degrees);
        if (!checkValidTransform())
        {
            shape.transform.Rotate(degrees * -1);
        }
    }
    public bool checkValidTransform()
    {
        foreach (Transform block in shape.transform)
        {
            int xCoord = Mathf.FloorToInt(block.transform.position.x);
            int yCoord = Mathf.FloorToInt(block.transform.position.y);

            if (xCoord >= SandBoxBehaviour.borderWidth
                || yCoord >= SandBoxBehaviour.borderHeight
                || xCoord < 0
                || yCoord < 0)
            {
                return false;
            }
                if (SandBoxBehaviour.cells[xCoord, yCoord] != null)
                {
                    return false;
                }
        }
        return true;
    }

    public virtual void addCells()
    {
        foreach (Transform block in shape.transform)
        {
            SandBoxBehaviour.cells[Mathf.FloorToInt(block.transform.position.x), Mathf.FloorToInt(block.transform.position.y)] = block;
        }
    }
}
