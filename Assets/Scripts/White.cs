using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White : State
{
    public White(ObjectProperties objectProperties) : base(objectProperties)
    {

    }

    public override IEnumerator Start()
    {
        ObjectProperties.SetColor(Color.white);
        yield break;
    }

    public override IEnumerator ChangeColor()
    {
        yield return new WaitForEndOfFrame();

        if (ObjectProperties.GetGroundColor().Equals(Color.red))
        {
            ObjectProperties.SetState(new Red(ObjectProperties));
        }
        else
        {
            ObjectProperties.SetState(this);
        }
    }
}


