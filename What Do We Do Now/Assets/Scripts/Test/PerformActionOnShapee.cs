using UnityEngine;
using System.Collections;

public class PerformActionOnShapee : MonoBehaviour
{

    private ShapeeBase _myLittleShapee;


    public void PerformNextAction()
    {
        _myLittleShapee.PerformNextAction(CallbackTest);
    }

    private void CallbackTest()
    {
#if DEBUG
        Debug.Log("Callback from " + _myLittleShapee.name);
#endif
    }

    // Use this for initialization
    void Start()
    {
        _myLittleShapee = GetComponent<ShapeeBase>();
    }
}
