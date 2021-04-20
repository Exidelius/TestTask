using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectProperties : MonoBehaviour
{
    public float speed;

    private Vector3 positionToMove;
    private List<Vector3> positionsToMove;

    private void Start()
    {
        positionToMove = Vector3.zero;
        positionsToMove = new List<Vector3>();
    }

    private void Update()
    {
        if (positionToMove != Vector3.zero)
        {
            if (!transform.position.Equals(positionToMove))
            {
                MoveToCurrentTargetPosition();
            }
            else
            {
                RemoveCurrentTargetPosition();
            }
        }
        else if (positionsToMove.Count != 0)
        {
            positionToMove = positionsToMove[0];
        }
    }

    public void SetNewTargetPosition(Vector3 position)
    {
        positionsToMove.Add(position);
    }

    private void MoveToCurrentTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, positionToMove, Time.deltaTime * speed);
    }

    private void RemoveCurrentTargetPosition()
    {
        positionsToMove.Remove(positionToMove);
        positionToMove = Vector3.zero;
    }
}
