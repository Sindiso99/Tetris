using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected GameObject shape;

    public Command(GameObject shape)
    {
        this.shape = shape;
    }

    public abstract void Execute();
    public abstract void Undo();
}
