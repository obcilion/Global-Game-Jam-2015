using UnityEngine;
using DaikonForge.Tween;
using System;

public class MoveAction : MonoBehaviour, IAction
{
    private float _tweenDuration = 1f;
    private float _moveDistance = 5f;

    public void Perform(Action callback)
    {

        Debug.Log("Performing Move Action");
        //move shit

        // todo:
        //  tween position one unit
        transform.TweenPosition()
            .SetEndValue(new Vector3(transform.position.x + _moveDistance, transform.position.y, transform.position.z))
            .SetDuration(_tweenDuration)
            .OnStopped(sender => callback())
            .Play();

    }
}
