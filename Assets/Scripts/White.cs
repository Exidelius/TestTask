using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White : State
{
    public White(SphereController sphereController) : base(sphereController)
    {

    }

    public override IEnumerator Start()
    {
        SphereController.SetColor(Color.white);
        yield break;
    }

    public override IEnumerator ChangeColor()
    {
        yield return new WaitForEndOfFrame();

        if (SphereController.GetGroundColor().Equals(Color.red))
        {
            SphereController.SetState(new Red(SphereController));
        }
        else
        {
            SphereController.SetState(this);
        }
    }
}


