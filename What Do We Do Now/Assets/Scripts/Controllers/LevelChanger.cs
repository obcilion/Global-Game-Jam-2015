using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour 
{
    public void ChangeLevel(int level)
    {
        Application.LoadLevel(level);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
