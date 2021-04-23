using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected ObjectProperties ObjectProperties;

    public State(ObjectProperties objectProperties)
    {
        ObjectProperties = objectProperties;
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
