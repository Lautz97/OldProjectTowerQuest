using UnityEngine;
public class PlatSpawn : MonoBehaviour 
{
    #region Variables

    //Screen Limit
    float topSL, leftSL, rightSL;
    //cameraoffset
    float topOFF, leftOFF, rightOff;
    //offset sull'asse Y tra la prossima piattaforma e quella appena creata
    float nextPlat = 0;

    //reference alla piattaforma da creare
    GameObject plat;

    [SerializeField]
    GameObject standardPlat;

    //reference alla main camera
    GameObject Mcam;

    //contenitore delle piattaforme e variabile di appoggio per la creazione della nuova piattaforma
    GameObject platContainer;
    GameObject np;

    //spawnRange
    float lowYSpawn = 0, highYSpawn = 2f;

    #endregion

    #region unityBaseMethods

    private void Awake()
    {
        //seleziona la prima plat come quella standard
        plat = standardPlat;

        //crea il contenitore per le piattaforme
        platContainer = new GameObject("platforms");
        //posiziona il contenitore a centro mondo
        platContainer.transform.position = new Vector3(0, 0, 0);

        //trova la main camera
        Mcam = GameObject.FindGameObjectWithTag("MainCamera");

        #region camera offest

        topOFF = PlayerPrefs.GetFloat("UpperSL");
        rightOff = PlayerPrefs.GetFloat("RightSL");
        leftOFF = PlayerPrefs.GetFloat("LeftSL");

        #endregion

        //setta i limiti schermo prendendoli da screenlimits e riformattando quello di base utile solo per questo metodo
        #region limiti schermo

        topSL = topOFF + Mcam.transform.position.y;

        float botSL = PlayerPrefs.GetFloat("LowerSL") + Mcam.transform.position.y;

        rightSL = rightOff + Mcam.transform.position.x;

        leftSL = leftOFF + Mcam.transform.position.x;

        #endregion

        //ciclo di spawn per le prime sei piattaforme
        for (int i = 1; i < 5; i++)
        {
            //crea la piattaforma
            np = Instantiate(plat, new Vector3(0, botSL + 1 + i * 2, 0), Quaternion.identity);
            //settala come figlia del contenitore
            np.transform.parent = platContainer.transform;
        }
    }

    private void Update()
    {
        //aggiorna la posizione della cima dello schermo
        topSL = topOFF + Mcam.transform.position.y;
        //se la cima dello schermo si trova o ha superato la posizione della nuova piattaforma....
        if (nextPlat <= topSL)
        {
            //...chiama la funzione di istanza
            Spawn();
            if (plat != standardPlat)
            {
                plat = standardPlat;
            }
        }
    }

    #endregion

    #region CustomMethods

    //metodo per istanziare la nuova piattaforma
    private void Spawn()
    {
        //trova limite destro schermo
        rightSL = rightOff + Mcam.transform.position.x;
        //specchialo per trovare il limite sinitro
        leftSL = -rightSL;

        //scegli randomicamente tra i due limiti sopra una posizione a caso
        float xPos = Random.Range(leftSL, rightSL);

        //istanzia una piattaforma in cima lo schermo alla posizione randomica precalcolata
        np = Instantiate(plat, new Vector3(xPos, topSL + 0.5f, 0), Quaternion.identity);
        //setta la piattaforma appena creata come ''figlia'' del platContainer
        np.transform.parent = platContainer.transform;

        //scegli dove posizionare la prossima piattaforma tra un tot a e il massimo range di salto
        nextPlat = topSL + Random.Range(lowYSpawn, highYSpawn);

        gameObject.GetComponent<Hardening>().HardeningMechs(lowYSpawn, highYSpawn);

    }

    //usare diversi tipi di piattaforme al posto delle solite normali
    public void SetPlat(GameObject newPlat)
    {
        plat = newPlat;
    }

    //store della precedente piattaforma
    public GameObject GetPlat()
    {
        return plat;
    }

    //cambia il range di distanza tra le piattaforme in verticale
    public void SetYSpawnLimits(float newLowYSpawnLimit, float newHighYSpawnLimit)
    {
        lowYSpawn = newLowYSpawnLimit;
        highYSpawn = newHighYSpawnLimit;
    }
    
    #endregion

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
