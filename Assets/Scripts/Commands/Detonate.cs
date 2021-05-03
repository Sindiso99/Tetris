using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Detonate : Command
{
    private SandBoxBehaviour sandBoxBehaviour;
    public Detonate(GameObject shape, SandBoxBehaviour sandBoxBehaviour) : base(shape)
    {
        this.sandBoxBehaviour = sandBoxBehaviour;
    }
    public override void Execute()
    {
        sandBoxBehaviour.deleteAround(Mathf.FloorToInt(shape.transform.position.x), Mathf.FloorToInt(shape.transform.position.y));
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}
