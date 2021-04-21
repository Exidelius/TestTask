using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Vector3 previousPointPosition;
    public Vector3 pointPosition;

    private GameObject point;

    public Color lineColor;
    private Material renderMaterial;

    private LineRenderer lr;


    public Point(Vector3 position)
    {
        point = new GameObject("Point");

        pointPosition = position;

        //point = new GameObject("Point");
        point.transform.position = pointPosition;

        renderMaterial = new Material(Shader.Find("Standard"));

        lineColor = Color.cyan;
        renderMaterial.color = lineColor;

        CreatePoint();
    }

    public void SetPreviousPoint(Vector3 previousPosition)
    {
        previousPointPosition = previousPosition;

        DrawLine();
    }

    private void DrawLine()
    {
        lr = point.AddComponent<LineRenderer>();

        lr.materials.SetValue(renderMaterial, 0);
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        lr.SetPosition(0, previousPointPosition);
        lr.SetPosition(1, pointPosition);
    }

    private void CreatePoint()
    {
        //Debug.
    }

    public void RemovePoint()
    {
        // TODO днаюбхрэ назейр рнвйх
        Destroy(point);
    }

    public void RemovePreviousPoint()
    {
        Destroy(lr);
    }
}
