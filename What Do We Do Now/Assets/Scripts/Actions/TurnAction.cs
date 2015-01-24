using UnityEngine;
using System;

public class TurnAction : MonoBehaviour, IAction
{
    public void Perform(Action callback)
    {
        Debug.Log("Performing Turn Action");
        gameObject.GetComponent<ShapeeBase>().Direction *= -1;
        callback();
    }
}
