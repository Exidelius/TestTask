using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectProperties : MonoBehaviour
{
    public float speed;

    public GameObject pointObject;

    private Material playerMaterial;

    private Vector3 targetPosition;

    private Dictionary<Color, Color> currentAndTargetColors;

    private List<Point> targetPoints;

    private void Start()
    {
        targetPosition = Vector3.zero;

        targetPoints = new List<Point>();

        playerMaterial = GetComponent<MeshRenderer>().materials[0];

        // Создание словаря для перехода между цветами
        currentAndTargetColors = new Dictionary<Color, Color>();
        currentAndTargetColors.Add(Color.white, Color.red);
        currentAndTargetColors.Add(Color.blue, Color.red);
        currentAndTargetColors.Add(Color.red, Color.green);
        currentAndTargetColors.Add(Color.green, Color.blue);
    }

    private void Update()
    {
        if (targetPosition != Vector3.zero)
        {
            if (!transform.position.Equals(targetPosition))
            {
                MoveToCurrentTargetPosition();
            }
            else
            {
                RemoveCurrentTargetPosition();
            }
        }
        else if (targetPoints.Count != 0)
        {
            targetPosition = targetPoints[0].pointPosition;
        }

        ChangeObjectColor();
    }

    public void SetNewTargetPosition(Vector3 position)
    {
        Point newPoint = new Point(position);

        if (targetPoints.Count != 0)
        {
            newPoint.SetPreviousPoint(targetPoints[targetPoints.Count - 1].pointPosition);
        }

        targetPoints.Add(newPoint);
    }

    private void MoveToCurrentTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }

    private void RemoveCurrentTargetPosition()
    {
        targetPosition = Vector3.zero;

        targetPoints[0].RemovePoint();
        targetPoints.Remove(targetPoints[0]);

        if (targetPoints.Count != 0)
            targetPoints[0].RemovePreviousPoint();

    }

    private Color GetGroundColor()
    {
        RaycastHit[] rc = Physics.RaycastAll(gameObject.transform.position, Vector3.down);
        for (int i = 0; i < rc.Length; i++)
        {
            if (rc[i].collider.tag == "Ground")
            {
                return rc[i].collider.gameObject.GetComponent<MeshRenderer>().materials[0].color;
            }
        }

        return Color.clear;
    }

    private void ChangeObjectColor()
    {
        Color groundColor = GetGroundColor();
        if (currentAndTargetColors[playerMaterial.color].Equals(groundColor))
        {
            playerMaterial.color = groundColor;
        }
    }
}
