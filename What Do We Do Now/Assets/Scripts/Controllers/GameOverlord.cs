using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ActionDistributer))]
public class GameOverlord : MonoBehaviour
{
	bool mainMusicPlaying = false;

    public enum GameState
    {
        Planning = 0,
        Execution
    }

    private ShapeeHerder _shapeeHerder;
    private ActionDistributer _actionDistributer;
    [SerializeField] private List<GameObject> _shapees;

    public GameState CurrentGameState { get; private set; }

    public void SpawnShapee()
    {
        _shapeeHerder.SpawnShapee(_shapees[0],new Vector3(-4,2,0));
    }

    public void PerformActions()
    {
        Debug.Log("Performing actions on shapees");
        if (CurrentGameState == GameState.Execution)
        {
            return;
        }
        CurrentGameState = GameState.Execution;
        _shapeeHerder.PerformActions(ShapeesDoneMoving);
    }

    private void ShapeesDoneMoving()
    {
        Debug.Log("Shapee actions done, changing state to planning");
        CurrentGameState = GameState.Planning;
    }

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this);

		// Load the Fabric manager by loading up the Audio scene!
		AudioManager.LoadFabric();

        _shapeeHerder = new ShapeeHerder();
        _shapeeHerder.Reset();

        _actionDistributer = gameObject.GetComponent<ActionDistributer>();
        _actionDistributer.Herder = _shapeeHerder;
    }

    // Update is called once per frame
    void Update()
    {
		if (!mainMusicPlaying) {
			if (AudioManager.FabricLoaded) {
				mainMusicPlaying = true;
//				AudioManager.PlaySound("MX/Music_Loop");
				Debug.Log("play the music!");
			}
		}
    }
}
