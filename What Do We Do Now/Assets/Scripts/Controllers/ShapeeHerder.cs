using UnityEngine;
using System.Collections.Generic;
using System;


public class ShapeeHerder
{
    private ShapeeBase _currentSelectedShapee;

    public List<ShapeeBase> ShapeesInScene { get; private set; } // Contains all shapees in scene
    public List<ShapeeBase> ShapeesWithActionsLeft { get; private set; }
    public List<ShapeeBase> ShapeesWithoutActionsLeft { get; private set; }

    public ShapeeBase CurrentSelectedShapee
    {
        get
        {
            return _currentSelectedShapee;
        }
        set
        {
            if (value == _currentSelectedShapee)
            {
                return;
            }

            _currentSelectedShapee = value;
        }
    }

    private Action _allActionsDoneCallback;
    private int _shapeesMoving;

    public ShapeeHerder()
    {
        ShapeesInScene = new List<ShapeeBase>();
    }

    public void Reset()
    {
        ShapeesWithActionsLeft = new List<ShapeeBase>();
        ShapeesWithoutActionsLeft = new List<ShapeeBase>();
        _shapeesMoving = 0;
        CurrentSelectedShapee = null;
        _allActionsDoneCallback = null;
        Debug.Log("ShapeeHerder reset");
    }

    public void SpawnShapee(GameObject prefab, Vector3 position)
    {
        var shapee = (GameObject)GameObject.Instantiate(prefab, position, prefab.transform.rotation);
        var shapeeScript = shapee.GetComponent<ShapeeBase>();
        ShapeesInScene.Add(shapeeScript);
        shapeeScript.OutOfActions += NoActionsLeft;
        CurrentSelectedShapee = shapeeScript;
    }

    public void PerformActions(Action allActionsDone)
    {
        _allActionsDoneCallback = allActionsDone;
        _shapeesMoving = ShapeesInScene.Count;
        foreach (var shapee in ShapeesInScene)
        {
            ShapeesWithActionsLeft.Add(shapee);
            shapee.PerformNextAction(ActionDone);
        }
    }

    public void PerformActions()
    {
        _shapeesMoving = ShapeesWithActionsLeft.Count;
        foreach (var shapee in ShapeesWithActionsLeft)
        {
            shapee.PerformNextAction(ActionDone);
        }
    }

    public void ActionDone(ShapeeBase shapee)
    {
        _shapeesMoving--;
        if (_shapeesMoving <= 0)
        {
            Debug.Log("All shapees done with current action");
            foreach (var s in ShapeesWithoutActionsLeft)
            {
                ShapeesWithActionsLeft.Remove(s);
            }
            PerformActions();
        }
    }

    public void NoActionsLeft(ShapeeBase shapee)
    {
        ShapeesWithoutActionsLeft.Add(shapee);
    }


}
