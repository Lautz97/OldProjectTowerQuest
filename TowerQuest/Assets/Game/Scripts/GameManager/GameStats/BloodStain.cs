using UnityEngine;
public class BloodStain : MonoBehaviour 
{

    bool gotAStain;

    ScoreSystem SS;

    [SerializeField]
    float stainSpawn;

    public GameObject stain;

    [SerializeField]
    int coinsToGet;

	void Awake () 
	{
        gotAStain = true;

        SS = gameObject.GetComponent<ScoreSystem>();

        coinsToGet = PlayerPrefs.GetInt("bloodyCoins");
        stainSpawn = PlayerPrefs.GetFloat("deathHeight");

    }
	
	
	
	void Update () 
	{

        if (stainSpawn <= SS.GetTravelled() && stain != null)
        {
            GameObject.Find("GameManager").GetComponent<PlatSpawn>().SetPlat(stain);
            stain = null;
        }
	
	}

    public bool CreateBloodStain()
    {
        return gotAStain;
    }
    public void BloodStainActive(bool active)
    {
        if (active)
        {
            gotAStain = true;
        }
        if (!active)
        {
            gotAStain = false;
        }
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/