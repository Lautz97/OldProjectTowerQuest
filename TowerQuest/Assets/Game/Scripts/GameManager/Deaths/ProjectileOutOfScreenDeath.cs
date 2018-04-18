using UnityEngine;
public class ProjectileOutOfScreenDeath : MonoBehaviour 
{
    #region Variables

    //variabili che regolano i limiti di schermo per il proietile
    float LY, HY, LX, HX;
    
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
        //Reference Assignment
        HY = PlayerPrefs.GetFloat("UpperSL") + Mcam.transform.position.y + 1;
        LY = PlayerPrefs.GetFloat("LowerSL") + Mcam.transform.position.y - 1;
        HX = PlayerPrefs.GetFloat("RightSL") + Mcam.transform.position.x + 1;
        LX = PlayerPrefs.GetFloat("LeftSL") + Mcam.transform.position.x - 1;

        //se supera la distanza prefissa
        if (gameObject.transform.position.y > HY)
        {
            //distruggi il possessore di questo script
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y < LY)
        {
            //distruggi il possessore di questo script
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x > HX)
        {
            //distruggi il possessore di questo script
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x < LX)
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