using UnityEngine;
public class TimeElapsed : MonoBehaviour 
{

    #region Variables

    //reference al game manager script di gestione del gioco
    GameManager gm;

    //tooltip chiarificatore (help for me)
    [Tooltip("Check elapsed time and store it into playerPrefs each frame in timeSecs,timeMins,timeHours."
             + "\n" +
             "Base time in this method => vector3."
             + "\n" +
             "All methods are private to get the time call 'getTime'."
             + "\n" +
             "Contains a method to even show time in gui but needs to be improved.")]

    //x for secs y for mins z for hours
    Vector3 elapsedTime;

    //azzeramento di debug
    bool zero = false;

    #endregion

    #region UnityBaseMethods

    private void Awake()
    {
        //trova il game manager
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        //se la booleana di debug è zero azzera il counter
        if (zero)
        {
            PlayerPrefs.DeleteKey("timeSecs");
            PlayerPrefs.DeleteKey("timeMins");
            PlayerPrefs.DeleteKey("timeHours");
            zero = false;
        }

        //controlla se le variabili esistono se non esistono creale e settale a zero
        #region playerPrefsCreations
        if (!PlayerPrefs.HasKey("timeSecs"))
        {
            PlayerPrefs.SetInt("timeSecs", 0);
        }
        if (!PlayerPrefs.HasKey("timeMins"))
        {
            PlayerPrefs.SetInt("timeMins", 0);
        }
        if (!PlayerPrefs.HasKey("timeHours"))
        {
            PlayerPrefs.SetInt("timeHours", 0);
        }
        #endregion

        //setta le variabili locali
        elapsedTime = new Vector3(PlayerPrefs.GetInt("timeSecs"), PlayerPrefs.GetInt("timeMins"), PlayerPrefs.GetInt("timeHours"));
    }

    //ogni secondo se il gioco non è in pausa aggiorna il timer
    private void FixedUpdate()
    {
        if (!gm.IsPaused())
        {
            //call timer update
            TimerUpdater();
        }
    }

    #endregion

    #region CustomMethods

    //vector 3 pubblico per sapere da quanto stai giocando
    public Vector3 getTime()
    {
        return elapsedTime;
    }

    //update time vars
    private void TimerUpdater()
    {
        //aggiungi un secondo
        elapsedTime.x += Time.deltaTime;
        //aggiornamento minuti e ore
        if (elapsedTime.x >= 60)
        {
            elapsedTime.y++;
            elapsedTime.x = 0;
        }
        if (elapsedTime.y >= 60)
        {
            elapsedTime.z++;
            elapsedTime.y = 0;
        }

        //store vector in player prefs
        SaveTime();
    }

    /*
    public void ShowTime(bool pause)
    {
        if (pause)
        {
            gameObject.GetComponent<GUIText>().text = elapsedTime.z + " : " + elapsedTime.y + " : " + (int)elapsedTime.x;
        }
        else if (!pause)
        {
            //toglie il testo della pausa
            gameObject.GetComponent<GUIText>().text = "";
        }
    }
    */

    //salva il tempo in player prefs
    private void SaveTime()
    {
        //store vars
        PlayerPrefs.SetInt("timeSecs", (int)elapsedTime.x);
        PlayerPrefs.SetInt("timeMins", (int)elapsedTime.y);
        PlayerPrefs.SetInt("timeHours", (int)elapsedTime.z);
    }

    #endregion

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
