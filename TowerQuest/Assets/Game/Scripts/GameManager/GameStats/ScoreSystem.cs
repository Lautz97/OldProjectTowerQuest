using UnityEngine;

public class ScoreSystem : MonoBehaviour 
{
    [SerializeField]
    GameObject stainObj;
    #region Variables

    //internal curScore memory
    int curScore = 0;
    int hiScore = 0;

    float coins = 0;

    float travelled = 0;
    float topTravelled = 0;

    GameObject Mcam;

    bool stain = true;

    #endregion

    #region Methods
    private void Awake()
    {
        Mcam = GameObject.FindGameObjectWithTag("MainCamera");
        
        //crea topPlat key in pl prefs se non esiste
        if (!PlayerPrefs.HasKey("TopPlat"))
        {
            PlayerPrefs.SetInt("TopPlat", 0);
        }
        hiScore = PlayerPrefs.GetInt("TopPlat");

        //crea topTravelled key in pl prefs se non esiste
        if (!PlayerPrefs.HasKey("topTravelled"))
        {
            PlayerPrefs.SetFloat("topTravelled", 0);
        }
        topTravelled = PlayerPrefs.GetFloat("topTravelled");

        //crea coins key in pl prefs se non esiste
        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", 0);
        }
        coins = PlayerPrefs.GetInt("coins");

        stain = true;
        gameObject.AddComponent<BloodStain>();
        if(gameObject.GetComponent<BloodStain>().stain == null)
        {
            gameObject.GetComponent<BloodStain>().stain = stainObj;
        }
    }

    private void Update()
    {
        updateTravelled();

        if(stain != gameObject.GetComponent<BloodStain>().CreateBloodStain())
        {
            stain = !stain;
        }

    }
    
    private void updateTravelled()
    {
        if (alive)
        {
            if (Mcam.transform.position.y > travelled)
            {
                travelled = Mcam.transform.position.y;
                if (travelled > topTravelled)
                {
                    topTravelled = travelled;
                    PlayerPrefs.SetFloat("topTravelled", topTravelled);
                }
            }
        }
    }

    public float GetTravelled()
    {
        return travelled;
    }

    public float GetTopTravelled()
    {
        return topTravelled;
    }




    public void AddPoint()
    {
        if (alive)
        {
            curScore++;
            CheckHiScore(curScore);
        }
        
    }

    public int GetCurrScore()
    {
        return curScore;
    }




    //controlla lo score e aggiorna
    private void CheckHiScore(int currScore)
    {
        if (currScore > hiScore)
        {
            PlayerPrefs.SetInt("TopPlat", currScore);
            hiScore = currScore;
        }
    }

    public int GetHiScore()
    {
        return PlayerPrefs.GetInt("TopPlat");
    }




    //requesting alive character
    bool alive = true;
    //se chiamata dal player decreta la sua morte
    public bool NOHERO()
    {
        alive = false;
        return alive;
    }

    
    
    public void AddACoin(float coinValue)
    {
        if (alive)
        {
            coins += coinValue;
        }

    }

    public int GetCoins()
    {
        return (int) coins;
    }

    public void SaveCoins()
    {
        if (!stain)
        {
            PlayerPrefs.SetInt("coins", (int) coins);
            PlayerPrefs.SetInt("bloodyCoins", 0);
        }
        if (stain)
        {
            PlayerPrefs.SetInt("coins", 0);
            PlayerPrefs.SetInt("bloodyCoins", (int)coins);
            PlayerPrefs.SetFloat("deathHeight", travelled);
        }
    }
    
    #endregion

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/