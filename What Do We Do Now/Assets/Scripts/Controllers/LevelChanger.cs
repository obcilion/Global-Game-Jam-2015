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
        // Load the Fabric manager by loading up the Audio scene!
        AudioManager.LoadFabric();
    }

    private void Start()
    {
        if (!mainMusicPlaying)
        {
            if (AudioManager.FabricLoaded)
            {
                mainMusicPlaying = true;
                AudioManager.PlaySound("MX/Main_Loop");
                Debug.Log("play the music!");
            }
        }
    }

	private void Update() 
    {
		
	}
}
