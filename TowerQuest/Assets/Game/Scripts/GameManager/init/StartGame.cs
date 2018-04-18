using UnityEngine;
public class StartGame : MonoBehaviour 
{
    //pawn reference
    [SerializeField]
    GameObject pawn = null;

    //main cam reference
    GameObject Mcam;

    void Start () 
	{
        //setta la reference della camera
        Mcam = GameObject.FindGameObjectWithTag("MainCamera");
        
        //instanzia il pawn
        StartPawn();

        //pauseButton
        float XSE = Mcam.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height;
        float YSE = Mcam.GetComponent<Camera>().orthographicSize;
        gameObject.GetComponent<AddPauseButton>().AddButton(XSE, YSE);

        //distruggi il game init
        Smash();
	}
	
	void StartPawn()
    {
        //crea l'istanza del player
        Instantiate(pawn, new Vector3(0, -1.5f, 0), Quaternion.identity);
        //aggiungi alla camera lo script che la fa stare al passo con il player
        Mcam.AddComponent<FollowPlayerY>();
        //dai potere allo script che spawna casualmente le prossime piattaforme
        GameObject.Find("GameManager").GetComponent<PlatSpawn>().enabled = true;
    }

    void Smash()
    {
        Destroy(gameObject);
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/