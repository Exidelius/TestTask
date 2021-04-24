using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : State
{
    public Red(SphereController sphereController) : base(sphereController)
    {

    }

    public override IEnumerator Start()
    {
        SphereController.SetColor(Color.red);
        yield break;
    }

    public override IEnumerator ChangeColor()
    {
        yield return new WaitForEndOfFrame();

        if (SphereController.GetGroundColor().Equals(Color.green))
        {
            SphereController.SetState(new Green(SphereController));
        }
        else
        {
            SphereController.SetState(this);
        }
    }
}
