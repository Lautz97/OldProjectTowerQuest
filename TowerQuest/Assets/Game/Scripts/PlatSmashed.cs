using UnityEngine;
public class PlatSmashed : MonoBehaviour 
{

    private void OnDestroy()
    {
        GameObject.Find("GameStats").GetComponent<ScoreSystem>().AddPoint();
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/