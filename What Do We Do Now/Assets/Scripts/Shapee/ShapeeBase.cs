using UnityEngine;
using System.Collections.Generic;
using System;

public class ShapeeBase : MonoBehaviour
{
    public Queue<IAction> ActionQueue { get; private set; }
    public bool IsDead { get; private set; }

    private Action<ShapeeBase> _actionCompleteCallback;

    public void Reset()
    {
        ActionQueue = new Queue<IAction>();
        IsDead = false;
    }

    public void PerformNextAction(Action<ShapeeBase> callback)
    {
        _actionCompleteCallback = callback;
        ActionQueue.Dequeue().Perform(ActionComplete);
    }

    private void Awake()
    {
        Reset();
    }

    private void ActionComplete()
    {
        _actionCompleteCallback(this);
    }
}
