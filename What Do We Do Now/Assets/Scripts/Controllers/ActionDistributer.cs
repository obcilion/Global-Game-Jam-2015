using UnityEngine;


public enum ActionType
{
    Move,
    Jump,
    Turn,
    Wait
}

public class ActionDistributer : MonoBehaviour {


    public ShapeeHerder Herder { get; set; }


    public void GiveAction(ActionType action)
    {

        //  Check that the shapee is not filled up on actions already
        var currentShapee = Herder.CurrentSelectedShapee;

        //todo: Make a variable in ShapeeBase that defines the action-capacity of a shapee to check against.
        if (currentShapee.ActionQueue.Count >= 3)
        {
            return;
        }


        //  Add the action requested
        switch (action)
        {
            case ActionType.Move:
#if DEBUG
                Debug.Log("Adding MOVE action to " + currentShapee.name);
#endif
                currentShapee.ActionQueue.Enqueue(new MoveAction());
                break;
            case ActionType.Jump:
#if DEBUG
                Debug.Log("Adding JUMP action to " + currentShapee.name);
#endif
                break;
            case ActionType.Turn:
#if DEBUG
                Debug.Log("Adding TURN action to " + currentShapee.name);
#endif
                break;
            case ActionType.Wait:
#if DEBUG
                Debug.Log("Adding WAIT action to " + currentShapee.name);
#endif
                break;
        }
    }

    public void GiveAction(int actionIndex)
    {
        GiveAction((ActionType)actionIndex);
    }

}
