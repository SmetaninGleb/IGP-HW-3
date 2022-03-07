using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float ZERO_CLAMP_VALUE = 0.01f;

    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _maxAngleSpeed = 90f;
    [SerializeField] private float _acceleration = 30f;
    [SerializeField] private float _angleAcceleration = 270f;

    private float _currentSpeed = 0f;
    private float _currentAngleSpeed = 0f;

    public float SpeedRatio => _currentSpeed / _maxSpeed;
    public float AngleSpeedRatio => _currentAngleSpeed / _maxAngleSpeed;

    private void Update()
    {
        ProcessRotation();
        ProcessMoving();
    }

    private void ProcessMoving()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) - ZERO_CLAMP_VALUE < 0f)
        {
            if (_currentSpeed > 0f)
            {
                _currentSpeed -= Mathf.Min(_acceleration * Time.deltaTime, _currentSpeed);
            } else
            {
                _currentSpeed += Mathf.Min(_acceleration * Time.deltaTime, -_currentSpeed);
            }
        } else
        {
            _currentSpeed += Input.GetAxis("Vertical") * _acceleration * Time.deltaTime;
        }
        _currentSpeed = Mathf.Clamp(_currentSpeed, -_maxSpeed, _maxSpeed);
        float distance = _currentSpeed * Time.deltaTime;
        transform.position += transform.forward * distance;
    }

    private void ProcessRotation()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) - ZERO_CLAMP_VALUE < 0f)
        {
            if (_currentAngleSpeed > 0f)
            {
                _currentAngleSpeed -= Mathf.Min(_currentAngleSpeed, _angleAcceleration * Time.deltaTime);
            } else
            {
                _currentAngleSpeed += Mathf.Min(-_currentAngleSpeed, _angleAcceleration * Time.deltaTime);
            }
        } else
        {
            _currentAngleSpeed += Input.GetAxis("Horizontal") * _angleAcceleration * Time.deltaTime;
        }
        _currentAngleSpeed = Mathf.Clamp(_currentAngleSpeed, -_maxAngleSpeed, _maxAngleSpeed);
        float degrees = _currentAngleSpeed * Time.deltaTime;
        transform.Rotate(0f, degrees, 0f);
    }
}
