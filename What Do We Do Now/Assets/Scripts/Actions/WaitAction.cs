using UnityEngine;
using System;

public class WaitAction : MonoBehaviour, IAction
{
    private Action _callback;
    private bool _isMoving = false;
    private int _direction = 1;

    public void Perform(Action callback)
    {
        _callback = callback;

        Debug.Log("Performing Wait Action");

    }

    private void FixedUpdate()
    {

    }
}
