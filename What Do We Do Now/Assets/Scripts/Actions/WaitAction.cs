using UnityEngine;
using System;

public class WaitAction : MonoBehaviour, IAction
{
    public void Perform(Action callback)
    {
        Debug.Log("Performing Wait Action");

		// play a sound
		Debug.Log("Play a wait sound");
        AudioManager.PlaySound("FX/Character/Wait",gameObject);

        callback();
    }
}
