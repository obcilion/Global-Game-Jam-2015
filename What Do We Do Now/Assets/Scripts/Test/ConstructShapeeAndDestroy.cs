using System;
using System.Collections.Generic;

using UnityEngine;
using System.Collections;


public class ConstructShapeeAndDestroy : MonoBehaviour
{


    private GameObject _trianglePrefab;

    public Transform SpawnTarget;

    public List<ShapeeBase> ActiveShapees { get; set; } 


    public void CreateShapeeWithAction(int actionNum)
    {
        var shapee = Instantiate(_trianglePrefab, SpawnTarget.position, Quaternion.identity) as GameObject;
        var shapeeScript = shapee.GetComponent<ShapeeBase>();


        switch (actionNum)
        {
            case 0:
                shapeeScript.ActionQueue.Enqueue(shapee.AddComponent<MoveAction>());
                break;
            default:
#if DEBUG
                Debug.LogWarning("Could not identify ActionType.");
#endif
                break;
        }

        ActiveShapees.Add(shapeeScript);

        shapee.name = "Shapee_" + ActiveShapees.Count;
    }

    public void CallPerformOnActiveShapees()
    {
        foreach (var shappie in ActiveShapees)
        {
#if DEBUG
            Debug.Log("PerformNextAction called on " + shappie.name);
#endif
            shappie.PerformNextAction(PerformCompleteCallback);
        }


    }

    private void PerformCompleteCallback(ShapeeBase sender)
    {
#if DEBUG
        Debug.Log("PerformCompleteCallback from " + sender.name);
#endif
    }

    private void Awake()
    {
        _trianglePrefab = Resources.Load<GameObject>("Prefabs/Shapee_Triangle");
        ActiveShapees = new List<ShapeeBase>();
    }

}
