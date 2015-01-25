using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour 
{
	bool mainMusicPlaying = false;

    public void ChangeLevel(int level)
    {
        Application.LoadLevel(level);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

	private void Update() {
		if (!mainMusicPlaying) {
			if (AudioManager.FabricLoaded) {
				mainMusicPlaying = true;
				AudioManager.PlaySound("MX/Main_Loop");
				Debug.Log("play the music!");
			}
		}
	}
}
