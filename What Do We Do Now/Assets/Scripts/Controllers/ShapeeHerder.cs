using UnityEngine;
using System.Collections.Generic;
using System;

public class ShapeeHerder
{
    public List<GameObject> ShapeesInScene { get; private set; } // Contains all shapees in scene
    public List<ShapeeBase> MovingShapees { get; private set; } // Moving Shapees with more actions left
    public List<ShapeeBase> IdleShapees { get; private set; } // Shapees who have no more actions

    private Action _allActionsDoneCallback;

    /// <summary>
    /// Initializes class
    /// </summary>
    /// <returns>success of initialization</returns>
    public bool Initialize()
    {
        ShapeesInScene = new List<GameObject>();
        MovingShapees = new List<ShapeeBase>();
        IdleShapees = new List<ShapeeBase>();

        Debug.Log("ShapeeHerder initialized");
        return true;
    }

    public void PerformAllActions(Action allActionsDoneCallback)
    {
        _allActionsDoneCallback = allActionsDoneCallback;
        foreach (var shapee in ShapeesInScene)
        {
            MovingShapees.Add(shapee.GetComponent<ShapeeBase>());
        }
        StartActions();
    }

    public void StartActions()
    {
        foreach (var shapee in MovingShapees)
        {
            shapee.PerformNextAction(ActionComplete);
        }
    }

    /// <summary>
    /// Called when a shapee finishes its action. Calls next action on shapee if <c>ActionQueue</c> is not empty
    /// </summary>
    /// <param name="shapee">The shapee calling</param>
    public void ActionComplete(ShapeeBase shapee)
    {
        if (shapee.ActionQueue.Count > 0)
        {
            shapee.PerformNextAction(ActionComplete);
        }
        else
        {
            IdleShapees.Add(shapee);

            if (IdleShapees.Count != MovingShapees.Count) return;

            Debug.Log("All shapees done moving");
            IdleShapees.Clear();
            MovingShapees.Clear();
            _allActionsDoneCallback();
        }
    }
}
