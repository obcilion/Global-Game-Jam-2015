using UnityEngine;
using System;

public class JumpAction : MonoBehaviour, IAction
{
    private Action _callback;
    private bool _isMoving = false;
    private int _direction = 1;

    [SerializeField] private bool _jump; //used to trigger this behaviour in the editor
    private float _height;
    private float _distance;

    public void Perform(Action callback)
    {
        _callback = callback;
        Debug.Log("Performing Jump Action");
        _direction = gameObject.GetComponent<ShapeeBase>().Direction;
        var jumpVector = new Vector2(_distance * _direction, _height);
        rigidbody2D.AddForce(jumpVector, ForceMode2D.Impulse);
        rigidbody2D.AddTorque(UnityEngine.Random.Range(0f, 1f));
        _isMoving = true;
    }

    private void Awake()
    {
        _height = 6.5f;
        _distance = 2.5f;
    }

    private void Update()
    {
        if (_jump)
        {
            Perform(null);
            _jump = false;
        }

        if (_isMoving && rigidbody2D.velocity.sqrMagnitude <= 0.1f && (Mathf.Abs(rigidbody2D.angularVelocity) <= 0.01f))
        {
            Debug.Log("Done jumping");
            _isMoving = false;
            if (_callback != null)
            {
                _callback();
            }
        }
    }
}
