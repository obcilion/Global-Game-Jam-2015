using UnityEngine;
using System.Collections.Generic;
using System;

public class ShapeeBase : MonoBehaviour
{
    public Queue<IAction> ActionQueue { get; private set; }
    public bool IsDead { get; private set; }
    public event Action<ShapeeBase> OutOfActions;

    private int _direction;
    public int Direction //  -1 for left, 1 for right
    {
        get { return _direction; }
        set
        {
            if (value != -1 && value != 1)
            {
                return;
            }
            _direction = value;
        }
    } 

    private Action<ShapeeBase> _actionCompleteCallback;

    public void Reset()
    {
        Debug.Log("Resetting Shapee");
        ActionQueue = new Queue<IAction>();
        IsDead = false;
        Direction = 1;
    }

    public void PerformNextAction(Action<ShapeeBase> callback)
    {
        _actionCompleteCallback = callback;

        if (ActionQueue.Count > 0)
        {
            ActionQueue.Dequeue().Perform(ActionComplete);
            Debug.Log("Performinc action, " + ActionQueue.Count + " actions left");
        }
        else if (OutOfActions != null)
        {
            OutOfActions(this);
        }
    }

    private void Awake()
    {
        Reset();
    }

    private void Update()
    {
        if (IsDead)
        {
            ActionQueue.Clear();
            if (OutOfActions != null)
            {
                OutOfActions(this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.layer)
        {
            case 10:        // obstacles
            	// play a sound for death
            	AudioManager.PlaySound("FX/Character/Death", gameObject);
                IsDead = true;
                break;
            case 11:        // exit
                Debug.Log("SUCCESS!");
                break;
        }
    }

    private void ActionComplete()
    {
        _actionCompleteCallback(this);
    }
}
