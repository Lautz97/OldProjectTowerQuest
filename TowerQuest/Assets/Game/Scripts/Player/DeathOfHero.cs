using UnityEngine;
public class DeathOfHero : MonoBehaviour
{

    //se il player muore avverte il game LLLoader
    private void OnDestroy()
    {
        //salva la ref allo score system
        ScoreSystem SS = GameObject.Find("GameStats").GetComponent<ScoreSystem>();
        //avvisa tutte le plat che è morto... rip :'(
        SS.NOHERO();
        //aggiorna i coin per ora senza bloodstain
        SS.SaveCoins();
        //spegni camera
        GameObject.Find("Main Camera").GetComponent<FollowPlayerY>().enabled = true;
        //#reload
        GameObject.Find("GameManager").GetComponent<GameManager>().Reload();
    }
}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
