using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereController : StateMachine
{
    public GameObject pointObject;

    public float speed;

    private float _cameraHeight;

    private Color _groundColor;

    private Material _playerMaterial;

    private Vector3 _targetPosition;
    private Vector3 _basePosition;

    private List<Point> _targetPoints;

    private void Start()
    {
        _cameraHeight = GameObject.FindGameObjectWithTag("MainCamera").transform.position.y;

        _basePosition = new Vector3(1, 1, 1) * float.MinValue;
        _targetPosition = _basePosition;
        _targetPoints = new List<Point>();

        _groundColor = Color.white;
        _playerMaterial = GetComponent<MeshRenderer>().materials[0];

        SetState(new White(this));
    }

    private void Update()
    {
        if (Input.GetButtonDown("Moving"))
        {
            SetNewTargetPosition(GetInputPosition());
        }

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

        private Vector3 GetInputPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraHeight));
        position.y = transform.position.y;

        return position;
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

    public void SetColor(Color color)
    {
        _playerMaterial.color = color;
    }

    public Color GetGroundColor()
    {
        return _groundColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            _groundColor = other.gameObject.GetComponent<MeshRenderer>().materials[0].color;

            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        StartCoroutine(State.ChangeColor());
    }
}