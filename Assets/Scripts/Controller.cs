using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectProperties))]
public class Controller : MonoBehaviour
{
    private ObjectProperties op;

    private void Start()
    {
        op = GetComponent<ObjectProperties>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Moving"))
        {
            op.SetNewTargetPosition(GetInputPosition());
        }
    }

    private Vector3 GetInputPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        position.y = transform.position.y;

        return position;
    }
}
