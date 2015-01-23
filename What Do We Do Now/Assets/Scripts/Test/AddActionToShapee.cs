using UnityEngine;
using System.Collections;

public class AddActionToShapee : MonoBehaviour
{

    private ShapeeBase _myLittleShapee;


    public void AddMoveToShapee()
    {
        _myLittleShapee.ActionQueue.Enqueue(new MoveAction());
    }

    // Use this for initialization
    private void Start()
    {
        _myLittleShapee = GetComponent<ShapeeBase>();
    }
}
