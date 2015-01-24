using UnityEngine;
using DaikonForge.Tween;
using System;

public class MoveAction : IAction
{
    private float _tweenDuration = 1f;
    private float _moveDistance = 5f;

    public void Perform(Action callback, GameObject targetShapee)
    {

        Debug.Log("Performing Move Action");
        //move shit

        // todo:
        //  tween position
        targetShapee.transform.TweenPosition()
            .SetEndValue(new Vector3(
                targetShapee.transform.position.x + _moveDistance,
                targetShapee.transform.position.y,
                targetShapee.transform.position.z))
            .SetDuration(_tweenDuration)
            .OnStopped(sender => callback())
            .Play();

    }
}
