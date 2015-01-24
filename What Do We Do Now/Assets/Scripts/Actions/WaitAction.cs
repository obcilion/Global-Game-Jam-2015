using UnityEngine;
using System;

public class WaitAction : MonoBehaviour, IAction
{
    public void Perform(Action callback)
    {
        Debug.Log("Performing Wait Action");
        callback();
    }
}
