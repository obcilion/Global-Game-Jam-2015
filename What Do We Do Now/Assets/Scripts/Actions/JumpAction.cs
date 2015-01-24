using UnityEngine;
using System;

public class JumpAction : MonoBehaviour, IAction
{
    private Action _callback;
    private bool _isMoving = false;
    private int _direction = 1;

    [SerializeField] private bool _jump; //used to trigger this behaviour in the editor
    [SerializeField] private float _height;
    [SerializeField] private float _distance;
    
    public void Perform(Action callback)
    {
        _callback = callback;
        Debug.Log("Performing Jump Action");
        _direction = gameObject.GetComponent<ShapeeBase>().Direction;
        Vector2 jumpVector = new Vector2(_distance * _direction, _height);
        rigidbody2D.AddForce(jumpVector,ForceMode2D.Impulse);
        _isMoving = true;
    }

    private void Update()
    {
        if (_jump)
        {
            Perform(null);
            _jump = false;
        }

        if (_isMoving && rigidbody2D.velocity.magnitude < 1)
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
