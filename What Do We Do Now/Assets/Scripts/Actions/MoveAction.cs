using UnityEngine;
using System.Collections;
using System;

public class MoveAction : IAction
{
    public void Perform(Action callback)
    {
        Debug.Log("Performing Move Action");
        //move shit
        callback();
    }
}
