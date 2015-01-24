using UnityEngine;
using System.Collections.Generic;
using System;

public class ShapeeBase : MonoBehaviour
{
    public Queue<IAction> ActionQueue { get; set; }
    public bool IsDead { get; private set; }
    public int Direction; // 1 for right, -1 for left

    private Action<ShapeeBase> _actionCompleteCallback;

    public void Reset()
    {
        ActionQueue = new Queue<IAction>();
        IsDead = false;
        Direction = 1;
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
