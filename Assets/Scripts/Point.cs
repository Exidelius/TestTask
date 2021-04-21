using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Vector3 previousPointPosition;
    public Vector3 pointPosition;

    private Mesh pointMesh;
    private GameObject point;
    private Vector3 pointScale;

    public Color lineColor;
    private Material renderMaterial;

    private LineRenderer lr;


    public Point(Vector3 position, Mesh mesh)
    {
        pointPosition = position;

        renderMaterial = new Material(Shader.Find("Standard"));

        lineColor = Color.cyan;
        renderMaterial.color = lineColor;

        pointMesh = mesh;

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
        point = new GameObject("Point");
        point.transform.position = pointPosition;
        pointScale = new Vector3(0.5f, 0.0001f, 0.5f);

        point.AddComponent<MeshFilter>().mesh = pointMesh;
        point.AddComponent<MeshRenderer>().material = renderMaterial;

        point.transform.localScale = pointScale;
    }

    public void RemovePoint()
    {
        Destroy(point);
    }

    public void RemovePreviousPoint()
    {
        Destroy(lr);
    }
}