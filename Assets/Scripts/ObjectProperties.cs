using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    public Vector3 positionToMove;
    public List<Vector3> positionsToMove;

    private void Start()
    {
        
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
        transform.position = Vector3.MoveTowards(transform.position, positionToMove, Time.deltaTime * 5f);
    }

    private void RemoveCurrentTargetPosition()
    {
        positionsToMove.Remove(positionToMove);
        positionToMove = Vector3.zero;
    }

    private void DrawLine()
    {

    }
}
