using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : State
{
    public Red(ObjectProperties objectProperties) : base(objectProperties)
    {

    }

    public override IEnumerator Start()
    {
        ObjectProperties.SetColor(Color.red);
        yield break;
    }

    public override IEnumerator ChangeColor()
    {
        yield return new WaitForEndOfFrame();

        if (ObjectProperties.GetGroundColor().Equals(Color.green))
        {
            ObjectProperties.SetState(new Green(ObjectProperties));
        }
        else
        {
            ObjectProperties.SetState(this);
        }
    }
}
