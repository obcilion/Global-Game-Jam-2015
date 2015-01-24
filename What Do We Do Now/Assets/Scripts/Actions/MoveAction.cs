using UnityEngine;
using System;

public class MoveAction : MonoBehaviour, IAction
{
    private Action _callback;
    public void Perform(Action callback, GameObject targetShapee)
    {
        _callback = callback;
        Debug.Log("Performing Move Action");

    }

    private void FixedUpdate()
    {
        
    }
}
