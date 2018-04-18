using UnityEngine;
public class ShowPCH : MonoBehaviour 
{

    #region Variables
    //prende lo script che regola lo scoring
    ScoreSystem SS;

    //variabili locali di displaying
    int curScore = 0;
    int hiScore = 0;

    int coins = 0;

    float travelled = 0;
    float topTravelled = 0;

    //strinda di debug
    string textToDis;

    #endregion

    private void Awake () 
	{
        //trova lo score system
        SS = GameObject.Find("GameStats").GetComponent<ScoreSystem>();
	}
	
	private void Update () 
	{
        if(curScore < SS.GetCurrScore())
        {
            //prendi ogni ciclo di update le variabili aggiornare dallo score system
            GetValues();

            //debug method per mostrare i valori
            DisplayValues();
        }
	}

    //aggiorna i valori dallo score system
    private void GetValues()
    {
        curScore = SS.GetCurrScore();
        hiScore = SS.GetHiScore();

        coins = SS.GetCoins();

        travelled = SS.GetTravelled();
        topTravelled = SS.GetTopTravelled();
    }

    //display dei valori di debug
    public void DisplayValues()
    {
        textToDis = "Current Score : " + curScore +
            "\n"
            + "Highest Score : " + hiScore +
            "\n"
            + "Coins Collected : " + coins +
            "\n"
            + "Distance Travelled : " + travelled +
            "\n"
            + "Top Distance Travelled : " + topTravelled;
        Debug.Log(textToDis);
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/