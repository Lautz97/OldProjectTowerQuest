using UnityEngine;
public class OutScreenDeath : MonoBehaviour 
{

    #region Variables

    //variabile che regola l'altezza di destroy degli oggetti in scena (tutti)
    float h;

    //camera reference         
    GameObject Mcam;

    #endregion


    private void Awake()
    {
        //trova la main camera
        Mcam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        //setta il limite schermo
        h = PlayerPrefs.GetFloat("LowerSL") + Mcam.transform.position.y - 1;

        //se supera la distanza prefissa
        if (gameObject.transform.position.y < h)
        {
            //distruggi il possessore di questo script
            Destroy(gameObject);
        }
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/