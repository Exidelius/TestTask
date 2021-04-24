using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected SphereController SphereController;

    public State(SphereController sphereController)
    {
        SphereController = sphereController;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator ChangeColor()
    {
        yield break;
    }
}
