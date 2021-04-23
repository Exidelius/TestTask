using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectProperties : MonoBehaviour
{
    public Mesh pointMesh;
    
    public float speed;

    private Material playerMaterial;

    private Vector3 targetPosition;
    private Vector3 basePosition;

    private List<Point> targetPoints;

    private void Start()
    {
        basePosition = new Vector3(1, 1, 1) * float.MinValue;

        targetPosition = basePosition;

        targetPoints = new List<Point>();

        playerMaterial = GetComponent<MeshRenderer>().materials[0];
    }

    private void Update()
    {
        if (targetPosition != basePosition)
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
            targetPosition = targetPoints[0].GetPosition();
        }
    }

    public void SetNewTargetPosition(Vector3 position)
    {
        Point newPoint = new Point(position, pointMesh);

        if (targetPoints.Count != 0)
        {
            newPoint.SetPreviousPoint(targetPoints[targetPoints.Count - 1].GetPosition());
        }

        targetPoints.Add(newPoint);
    }

    private void MoveToCurrentTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }

    private void RemoveCurrentTargetPosition()
    {
        targetPosition = basePosition;

        targetPoints[0].RemovePoint();
        targetPoints.Remove(targetPoints[0]);

        if (targetPoints.Count != 0)
            targetPoints[0].RemovePreviousPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Color groundColor = other.gameObject.GetComponent<MeshRenderer>().materials[0].color;

            if (groundColor.Equals(Color.red))
            {
                if (playerMaterial.color.Equals(Color.white))
                {
                    playerMaterial.color = groundColor;
                }
                else if (playerMaterial.color.Equals(Color.blue))
                {
                    playerMaterial.color = groundColor;
                }
            }
            else if (groundColor.Equals(Color.green))
            {
                if (playerMaterial.color.Equals(Color.red))
                {
                    playerMaterial.color = groundColor;
                }
            }
            else if (groundColor.Equals(Color.blue))
            {
                if (playerMaterial.color.Equals(Color.green))
                {
                    playerMaterial.color = groundColor;
                }
            }
        }
    }
}