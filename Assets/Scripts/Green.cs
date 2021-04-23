using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : State
{
    public Green(ObjectProperties objectProperties) : base(objectProperties)
    {

    }

    public override IEnumerator Start()
    {
        ObjectProperties.SetColor(Color.green);
        yield break;
    }


    public override IEnumerator ChangeColor()
    {
        yield return new WaitForEndOfFrame();

        if (ObjectProperties.GetGroundColor().Equals(Color.blue))
        {
            ObjectProperties.SetState(new Blue(ObjectProperties));
        }
        else
        {
            ObjectProperties.SetState(this);
        }
    }
}
