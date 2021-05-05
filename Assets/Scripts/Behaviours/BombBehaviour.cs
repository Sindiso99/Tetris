using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private BlockBehaviour _blockBehaviour;
    void Start()
    {
        _blockBehaviour = GetComponent<BlockBehaviour>();
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
       
}
