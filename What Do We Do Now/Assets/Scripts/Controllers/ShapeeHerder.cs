using UnityEngine;
using System.Collections.Generic;
using System;

public class ShapeeHerder
{
    public List<ShapeeBase> ActiveShapees { get; private set; }

    private int _shapeesStarted = 0;
    private int _shapeesNotDone = 0;
    private int _shapeesDone = 0;

    private Action _allActionsCompleteCallback;

    /// <summary>
    /// Initializes class
    /// </summary>
    /// <returns>success of initialization</returns>
    public bool Initialize()
    {
        ActiveShapees = new List<ShapeeBase>();

        if (ActiveShapees.Count == 0)
        {
            Debug.LogError("Shapee list empty, add shapees before initializing!");
            return false;
        }

        foreach(var shapee in ActiveShapees)
        {
            shapee.OnActionQueueEmpty += OnShapeeOutOfActions;
        }

        Debug.Log("ShapeeHerder initialized");
        return true;
    }

    /// <summary>
    /// Performs next action on all active Shapees
    /// </summary>
    /// <param name="allActionsCompleteCallback">Called when all Shapees have acted</param>
    public void TellShapeesToPerformAction(Action allActionsCompleteCallback)
    {
        _allActionsCompleteCallback = allActionsCompleteCallback;
        foreach(var shapee in ActiveShapees)
        {
            shapee.PerformNextAction(ActionComplete);
        }
    }

    /// <summary>
    /// Called when a Shapee completes its action
    /// </summary>
    public void ActionComplete()
    {

    }

    public void OnShapeeOutOfActions()
    {
        Debug.LogWarning("Shapee out of actions!");
        ActionComplete();
    }
}
