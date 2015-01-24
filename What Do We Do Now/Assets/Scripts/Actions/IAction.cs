using System;

using UnityEngine;

public interface IAction
{
    void Perform(Action callback, GameObject targetShapee);
}
