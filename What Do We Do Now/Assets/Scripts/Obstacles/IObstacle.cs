using UnityEngine;
using System;

public interface IObstacle
{
    void Activate(Action callback);
}
