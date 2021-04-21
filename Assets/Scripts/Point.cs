using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Vector3 previousPointPosition;
    public Vector3 pointPosition;

    GameObject point;

    private LineRenderer lr;
    private Mesh m;

    public Color lineColor;
    private Material renderMaterial;

    public Point(Vector3 position)
    {
        pointPosition = position;

        point = new GameObject("Point");
        point.transform.position = pointPosition;

        renderMaterial =new Material(Shader.Find("Legacy Shaders/Transparent/Bumped Diffuse"));

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
        lr.materials[0].color = lineColor;
        lr.SetWidth(0.1f, 0.1f);

        lr.SetPosition(0, previousPointPosition);
        lr.SetPosition(1, pointPosition);
    }

    private void CreatePoint()
    {
        
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
