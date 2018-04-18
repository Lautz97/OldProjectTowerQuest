using UnityEngine;
public class PauseButtonScript : MonoBehaviour 
{
    
    private void OnMouseDown()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().Pause();
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/