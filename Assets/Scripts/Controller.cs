using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectProperties))]
public class Controller : MonoBehaviour
{
    private ObjectProperties _op;

    private GameObject _camera;

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _op = GetComponent<ObjectProperties>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Moving"))
        {
            _op.SetNewTargetPosition(GetInputPosition());
        }
    }

    private Vector3 GetInputPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.transform.position.y));
        position.y = transform.position.y;

        return position;
    }
}
