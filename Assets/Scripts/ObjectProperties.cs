using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectProperties : MonoBehaviour
{
    public GameObject pointObject;
    
    public float speed;

    private Material _playerMaterial;

    private Vector3 _targetPosition;
    private Vector3 _basePosition;

    private List<Point> _targetPoints;

    private void Start()
    {
        _basePosition = new Vector3(1, 1, 1) * float.MinValue;

        _targetPosition = _basePosition;

        _targetPoints = new List<Point>();

        _playerMaterial = GetComponent<MeshRenderer>().materials[0];
    }

    private void Update()
    {
        if (_targetPosition != _basePosition)
        {
            if (!transform.position.Equals(_targetPosition))
            {
                MoveToCurrentTargetPosition();
            }
            else
            {
                RemoveCurrentTargetPosition();
            }
        }
        else if (_targetPoints.Count != 0)
        {
            _targetPosition = _targetPoints[0].GetPosition();
        }
    }

    public void SetNewTargetPosition(Vector3 position)
    {
        Point newPoint = Instantiate(pointObject, position, Quaternion.identity).GetComponent<Point>();
        newPoint.InitPoint(position);

        if (_targetPoints.Count != 0)
        {
            newPoint.SetPreviousPoint(_targetPoints[_targetPoints.Count - 1].GetPosition());
        }

        _targetPoints.Add(newPoint);
    }

    private void MoveToCurrentTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * speed);
    }

    private void RemoveCurrentTargetPosition()
    {
        _targetPosition = _basePosition;

        Point pointToDelete = _targetPoints[0];

        _targetPoints.Remove(pointToDelete);
        pointToDelete.RemovePoint();

        if (_targetPoints.Count != 0)
            _targetPoints[0].RemoveLine();
    }


    // Переделать под StateMachine
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Color groundColor = other.gameObject.GetComponent<MeshRenderer>().materials[0].color;

            if (groundColor.Equals(Color.red))
            {
                if (_playerMaterial.color.Equals(Color.white))
                {
                    _playerMaterial.color = groundColor;
                }
                else if (_playerMaterial.color.Equals(Color.blue))
                {
                    _playerMaterial.color = groundColor;
                }
            }
            else if (groundColor.Equals(Color.green))
            {
                if (_playerMaterial.color.Equals(Color.red))
                {
                    _playerMaterial.color = groundColor;
                }
            }
            else if (groundColor.Equals(Color.blue))
            {
                if (_playerMaterial.color.Equals(Color.green))
                {
                    _playerMaterial.color = groundColor;
                }
            }
        }
    }
}