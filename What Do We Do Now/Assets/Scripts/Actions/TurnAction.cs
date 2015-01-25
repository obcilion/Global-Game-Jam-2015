using UnityEngine;
using System;

public class TurnAction : MonoBehaviour, IAction
{
    public void Perform(Action callback)
    {
        Debug.Log("Performing Turn Action");

		// play a sound
		Debug.Log("Play a turn sound");
        AudioManager.PlaySound("FX/Character/Turn",gameObject);

        gameObject.GetComponent<ShapeeBase>().Direction *= -1;
        callback();
    }
}
