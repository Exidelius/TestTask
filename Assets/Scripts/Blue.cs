using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : State
{
    public Blue(SphereController sphereController) : base(sphereController)
    {

    }

    public override IEnumerator Start()
    {
        SphereController.SetColor(Color.blue);
        yield break;
    }


    public override IEnumerator ChangeColor()
    {
        yield return new WaitForEndOfFrame();

        if (SphereController.GetGroundColor().Equals(Color.red))
            SphereController.SetState(new Red(SphereController));
    }
}