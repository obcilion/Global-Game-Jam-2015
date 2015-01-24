using UnityEngine;
using DaikonForge.Tween;
using System;

public class MoveAction : IAction
{
    private float _tweenDuration = .5f;
    private float _moveDistance = 5f;

    private TweenEasingCallback _easing = TweenEasingFunctions.GetFunction(EasingType.QuadEaseInOut);

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
            .SetEasing(_easing)
            .OnStopped(sender => callback())
            .Play();

    }
}
