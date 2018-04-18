using UnityEngine;
public class CoinSpawn : MonoBehaviour
{
    #region Variables

    //Screen Limit
    float topSL, leftSL, rightSL;
    //cameraoffset
    float topOFF, leftOFF, rightOff;
    //offset sull'asse Y tra la prossima piattaforma e quella appena creata
    float nextCoin = 0;

    //reference alla piattaforma da creare
    [SerializeField]
    GameObject coin;

    //reference alla main camera
    GameObject Mcam;

    //contenitore delle piattaforme e variabile di appoggio per la creazione della nuova piattaforma
    GameObject coinContainer;
    GameObject nc;

    //spawnRange
    float lowYSpawn = 5, highYSpawn = 10f;

    #endregion

    #region unityBaseMethods

    private void Awake()
    {
        //crea il contenitore per le piattaforme
        coinContainer = new GameObject("coins");
        //posiziona il contenitore a centro mondo
        coinContainer.transform.position = new Vector3(0, 0, 0);

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

        rightSL = rightOff + Mcam.transform.position.x;

        leftSL = leftOFF + Mcam.transform.position.x;

        #endregion
        
    }

    private void Update()
    {
        //aggiorna la posizione della cima dello schermo
        topSL = topOFF + Mcam.transform.position.y;
        //se la cima dello schermo si trova o ha superato la posizione della nuova piattaforma....
        if (nextCoin <= topSL)
        {
            //...chiama la funzione di istanza
            Spawn();
            highYSpawn++;
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
        nc = Instantiate(coin, new Vector3(xPos, topSL + 0.5f, 0), Quaternion.identity);
        //setta la piattaforma appena creata come ''figlia'' del platContainer
        nc.transform.parent = coinContainer.transform;

        //scegli dove posizionare la prossima piattaforma tra un tot a e il massimo range di salto
        nextCoin = topSL + Random.Range(lowYSpawn, highYSpawn);

    }

    //usare diversi tipi di piattaforme al posto delle solite normali
    public void SetCoin(GameObject newCoin)
    {
        coin = newCoin;
    }

    //cambia il range di distanza tra le piattaforme in verticale
    public void SetYSpawnLimits(float newLowYSpawnLimit, float newHighYSpawnLimit)
    {
        lowYSpawn = newLowYSpawnLimit;
        highYSpawn = newHighYSpawnLimit;
    }

    public void Again()
    {
        //scegli randomicamente tra i due limiti sopra una posizione a caso
        float xPos = Random.Range(leftSL, rightSL);

        //istanzia una piattaforma in cima lo schermo alla posizione randomica precalcolata
        nc = Instantiate(coin, new Vector3(xPos, topSL + 0.5f, 0), Quaternion.identity);
        //setta la piattaforma appena creata come ''figlia'' del platContainer
        nc.transform.parent = coinContainer.transform;

        //scegli dove posizionare la prossima piattaforma tra un tot a e il massimo range di salto
        nextCoin = topSL + Random.Range(lowYSpawn, highYSpawn);
    }

    #endregion

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
