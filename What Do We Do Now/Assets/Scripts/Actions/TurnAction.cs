using UnityEngine;
using System;

public class TurnAction : MonoBehaviour, IAction
{
    private Action _callback;
    private bool _isMoving = false;
    private int _direction = 1;

    public void Perform(Action callback)
    {
        _callback = callback;

        Debug.Log("Performing Turn Action");

    }

    private void FixedUpdate()
    {

    }
}
