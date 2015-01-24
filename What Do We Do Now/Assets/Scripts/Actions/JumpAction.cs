using UnityEngine;
using System;

public class JumpAction : MonoBehaviour, IAction
{
    private Action _callback;
    private bool _isMoving = false;
    private int _direction = 1;

    public void Perform(Action callback)
    {
        _callback = callback;

        Debug.Log("Performing Jump Action");

    }

    private void FixedUpdate()
    {

    }
}
