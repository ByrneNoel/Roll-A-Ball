using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    bool _movingUp = true;
    Vector3 _startPoint, _endPoint, _target;
    [SerializeField] float _floorWaitTime = 1f;
    [SerializeField] float _yOffset = 5f;
    [SerializeField] float _speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _startPoint = transform.position;
        _endPoint = transform.position + new Vector3(0, _yOffset, 0);
        _target = _endPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (_floorWaitTime > 0)
        {
            _floorWaitTime -= Time.deltaTime;
            return;
        }

        Vector3 newPos = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        transform.position = newPos;
        

        if (Vector3.Distance(transform.position, _target) < 0.01f)
        {
            _floorWaitTime = 1;
            toggleTarget();
        }
    }

    void toggleTarget()
    {
        _target = (_movingUp) ? _endPoint : _startPoint;
        _movingUp = !_movingUp;
    }
}
