using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Vector3 _previousPointPosition;
    private Vector3 _pointPosition;

    private Material _pointMaterial;

    private LineRenderer _lr;

    public void InitPoint(Vector3 position)
    {
        _pointPosition = position;

        _pointMaterial = GetComponent<MeshRenderer>().materials[0];

        _pointMaterial.color = _pointMaterial.color;
    }

    public void SetPreviousPoint(Vector3 previousPosition)
    {
        _previousPointPosition = previousPosition;

        DrawLine();
    }

    private void DrawLine()
    {
        _lr = gameObject.AddComponent<LineRenderer>();

        _lr.materials.SetValue(_pointMaterial, 0);
        _lr.startWidth = 0.1f;
        _lr.endWidth = 0.1f;

        _lr.SetPosition(0, _previousPointPosition);
        _lr.SetPosition(1, _pointPosition);
    }

    public void RemovePoint()
    {
        Destroy(gameObject);
    }

    public void RemoveLine()
    {
        Destroy(_lr);
    }

    public Vector3 GetPosition()
    {
        return _pointPosition;
    }
}