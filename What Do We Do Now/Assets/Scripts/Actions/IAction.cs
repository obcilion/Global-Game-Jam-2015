using System;

public interface IAction
{
    void Perform(Action callback);
}
