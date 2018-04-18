using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour 
{
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.autorotateToPortrait = true;
    }

    bool pause = false;

    //alla morte del player viene chiama questa funzione
    public void Reload()
    {
        SceneManager.LoadSceneAsync("lvl");
    }

    //metti in pausa e chiama il pause script
    public void Pause()
    {
        pause = !pause;
        gameObject.GetComponent<PauseScript>().Pause(pause);
    }

    //controllo della pausa
    public bool IsPaused()
    {
        return pause;
    }

    public void Quit()
    {
        if (Application.isEditor)
        {
            Debug.Log("Quit Editor");
        }
        GameObject.Find("GameStats").GetComponent<ScoreSystem>().NOHERO();
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        Application.Quit();
    }
}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/