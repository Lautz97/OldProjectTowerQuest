using UnityEngine;
public class CoinTriggerCheck : MonoBehaviour 
{
    
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("Plat"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("GameManager").GetComponent<CoinSpawn>().Again();
            Destroy(gameObject);
        }
        if (coll.CompareTag("Player"))
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<BlockAndStamina>().isBlocking())
            {
                ScoreSystem SS = GameObject.Find("GameStats").GetComponent<ScoreSystem>();
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                SS.AddACoin(SS.GetCurrScore() / 10);
                Destroy(gameObject);
            }
        }
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/