using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectProperties))]
public class Controller : MonoBehaviour
{
    ObjectProperties op;


    private void Start()
    {
        op = GetComponent<ObjectProperties>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Moving"))
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