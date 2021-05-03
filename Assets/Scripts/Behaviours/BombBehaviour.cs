using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private BlockBehaviour _blockBehaviour;
    void Start()
    {
        _blockBehaviour = GetComponent<BlockBehaviour>();
        /*sandBoxBehaviour = FindObjectOfType<SandBoxBehaviour>();
        _inputReader = GetComponent<InputReader>();
        _commandProcessor = GetComponent<CommandProcessor>();*/
    }

    void Update()
    {
        Destroy();
    }
    public void Destroy()
    {
        if (!_blockBehaviour.falling)
        {
            var moveCommand = new Detonate(_blockBehaviour.shape, _blockBehaviour.sandBoxBehaviour);
            _blockBehaviour._commandProcessor.ExecuteCommand(moveCommand);
            Destroy(_blockBehaviour.gameObject);
        }
    }
        /*if (falling)
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
*/
        
    

   /* public override void fall()
    {
        gameObject.transform.Translate(normalDownVector);
        rateOfFall = 0f;
        if (!checkValidTransform())
        {
            falling = false;
            gameObject.transform.Translate(upVector);
            addCells();
            sandBoxBehaviour.CheckRows();
            rotate();
            FindObjectOfType<BlockCreator>().dropBlock();
        }
    }*/
    /*public override void rotate()
    {
        sandBoxBehaviour.CheckRows();
        var moveCommand = new Detonate(shape, sandBoxBehaviour);
        _commandProcessor.ExecuteCommand(moveCommand);
    }*/
}
