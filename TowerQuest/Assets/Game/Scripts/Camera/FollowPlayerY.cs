using UnityEngine;
public class FollowPlayerY : MonoBehaviour 
{

    //reference al player transform
    Transform playerTransform;

    //my y ref
    float y;

    private void Start()
    {
        //trova il player e chiedi una ref. al suo transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        //get my Y
        y = playerTransform.position.y;

        //se player supera Y of main camera
        if (y > transform.position.y)
        {
            //no sto io sopra
            NeverBehind();
        }
    }

    private void NeverBehind()
    {
        //main camera sale al livello più alto del player
        transform.position = new Vector3(0, y, -10);
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/