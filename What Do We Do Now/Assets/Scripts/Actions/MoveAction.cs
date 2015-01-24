using UnityEngine;
using System;

public class MoveAction : MonoBehaviour, IAction
{
    public float Distance;
    public float Speed;
    public float Acceleration;
    [SerializeField]
    private bool _move; //used to trigger this behaviour in the editor

    private Action _callback;
    private bool _isMoving;
    private int _direction = 1;
    private float _timeToTravel = 0;
    private float _timeTraveled = 0;
    private Vector2 _velocity;

    public void Perform(Action callback)
    {
        Reset();
        _callback = callback;
        _direction = gameObject.GetComponent<ShapeeBase>().Direction;
        Debug.Log("Performing Move Action");
        _isMoving = true;
    }

    public void Reset()
    {
        _callback = null;
        _isMoving = false;
        _timeTraveled = 0;
        _velocity = new Vector2();
        _timeToTravel = Distance / Speed;
    }

    private void Awake()
    {
        Distance = 77;
        Speed = 5;
        Acceleration = 1;
        Reset();
    }

    private void FixedUpdate()
    {
        if (_move)
        {
            Perform(null);
            _move = false;
        }

        if (_isMoving)
        {
            if (_timeTraveled < _timeToTravel)
            {
                _timeTraveled += 0.1f;
                if (_velocity.magnitude < Speed)
                {
                    _velocity.x += Acceleration * _direction;
                }
                rigidbody2D.AddForce(_velocity, ForceMode2D.Force);
            }
            else if (rigidbody2D.velocity.sqrMagnitude <= 0.01f)
            {
                Debug.Log("Done moving");
                if (_callback != null) _callback();
                Reset();
            }
        }
    }
}
