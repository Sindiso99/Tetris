using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeBlockMovement : BlockBehaviour
{
    public bool moving = true;
    // Start is called before the first frame update
    void Start()
    {
        _inputReader = GetComponent<InputReader>();
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = _inputReader.ReadInput();

        if(moving == true)
        {
            if (direction == leftVector)
            {
                direction = new Vector3(-20, 0, 0);
                shift(leftVector);
            }
            else if (direction == rightVector)
            {
                direction = new Vector3(20, 0, 0);
                shift(rightVector);
            }
            else if (direction == normalDownVector)
            {
                direction = new Vector3(0, -2, 0);
                shift(direction);
            }
        } else
        {
            if (direction == upVector)
            {
                rotate();
            }
        }
        
     }

    public override void shift(Vector3 direction)
    {
        var moveCommand = new Shift(shape, direction);
        _commandProcessor.ExecuteCommand(moveCommand);
    }

    public override void rotate()
    {
        var moveCommand = new Rotate(shape, rotation);
        _commandProcessor.ExecuteCommand(moveCommand);
    }


}
