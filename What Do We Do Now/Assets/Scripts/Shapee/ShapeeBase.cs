using UnityEngine;
using System.Collections.Generic;
using System;

public class ShapeeBase : MonoBehaviour
{
    public Queue<IAction> ActionQueue { get; private set; }

    public void PerformAction(Action callback)
    {
        if (ActionQueue.Count == 0)
        {
            Debug.Log("No Actions in queue");
            callback();
            return;
        }

        ActionQueue.Dequeue().Perform(callback);
        return;
    }

    private void Awake()
    {
        ActionQueue = new Queue<IAction>();
    }
}
