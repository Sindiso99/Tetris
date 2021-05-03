using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Shift : Command
{
    private Vector3 direction;
    public Shift(GameObject shape, Vector3 direction) : base(shape)
    {
        this.direction = direction;
    }
    public override void Execute()
    {
        shape.transform.position += direction;
    }

    public override void Undo()
    {
        shape.transform.position -= direction;
    }
}

