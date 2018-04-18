using UnityEngine;
public class PauseScript : MonoBehaviour
{
    [SerializeField]
    Color pauseC;                   //colore di background in pausa

    Color normalC;                  //colore di background in playtime

    [SerializeField]
    GameObject Mcam;                //ref alla camera

    private void Awake()
    {
        Mcam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            //azzera la timescale
            Time.timeScale = 0;

            //salva il colore di background
            normalC = Mcam.GetComponent<Camera>().backgroundColor;

            //setta il colore di pausa come background
            Mcam.GetComponent<Camera>().backgroundColor = pauseC;

            //Implementare gui function
        }
        else if (!pause)
        {
            //Implementare GUI function

            //resetta il colore di background
            Mcam.GetComponent<Camera>().backgroundColor = normalC;

            //ripristina il normale scorrere del tempo :D
            Time.timeScale = 1;
        }
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
