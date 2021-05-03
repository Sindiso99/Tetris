using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Rotate : Command
{
    private Vector3 rotation;

    public Rotate(GameObject shape, Vector3 rotation) : base(shape)
    {
        this.rotation = rotation;
    }
    public override void Execute()
    {
       shape.transform.Rotate(rotation);
    }

    public override void Undo()
    {
        shape.transform.Rotate(-rotation);
    }
}

