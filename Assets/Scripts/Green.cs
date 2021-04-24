using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : State
{
    public Green(SphereController sphereController) : base(sphereController)
    {

    }

    public override IEnumerator Start()
    {
        SphereController.SetColor(Color.green);
        yield break;
    }


    public override IEnumerator ChangeColor()
    {
        yield return new WaitForEndOfFrame();

        if (SphereController.GetGroundColor().Equals(Color.blue))
        {
            SphereController.SetState(new Blue(SphereController));
        }
        else
        {
            SphereController.SetState(this);
        }
    }
}
