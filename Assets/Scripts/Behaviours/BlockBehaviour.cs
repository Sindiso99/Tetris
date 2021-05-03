using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    protected  Vector3 leftVector = new Vector3(-1, 0, 0);
    protected  Vector3 rightVector = new Vector3(1, 0, 0);
    protected  Vector3 normalDownVector = new Vector3(0, -1, 0);
    protected  Vector3 upVector = new Vector3(0, 1, 0);
    protected  Vector3 rotation = new Vector3(0, 0, 90);
    protected float rateOfFall = 0f;
    public bool falling = true;
    public GameObject shape;
    public SandBoxBehaviour sandBoxBehaviour;
    private BlockCreator dropper;
    protected InputReader _inputReader;
    public CommandProcessor _commandProcessor;

    void Start()
    {
        sandBoxBehaviour = FindObjectOfType<SandBoxBehaviour>();
        dropper = FindObjectOfType<BlockCreator>();
        _inputReader = GetComponent<InputReader>();
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            rateOfFall += Time.deltaTime;
            var direction = _inputReader.ReadInput();

            if (direction == upVector)
            {
                rotate();
            }
            if (direction == leftVector)
            {
                shift(leftVector);
            }
            else if (direction == rightVector)
            {
                shift(rightVector);
            }
            if (direction == normalDownVector)
            {
                fall();
            }
            else if (rateOfFall > SandBoxBehaviour.normalDropSpeed)
            {
                fall();
            }
            //Object falls at a constant rate

            
        }
        
    }

    public virtual void fall()
    {
        gameObject.transform.Translate(normalDownVector);
        rateOfFall = 0f;
        if (!checkValidTransform())
        {
            gameObject.transform.Translate(upVector);
            addCells();
            sandBoxBehaviour.CheckRows();
            dropper.dropBlock();
            falling = false;
        }
    }

    public void shift(Vector3 direction)
    {
        var moveCommand = new Shift(shape, direction);
        _commandProcessor.ExecuteCommand(moveCommand);
        if (!checkValidTransform())
        {
            _commandProcessor.Undo();
        }
    }

    public virtual void rotate()
    {
        var moveCommand= new Rotate(shape, rotation);
        _commandProcessor.ExecuteCommand(moveCommand);
        if (!checkValidTransform())
        {
            _commandProcessor.Undo();
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

    public bool isFalling()
    {
        return falling;
    }

}
