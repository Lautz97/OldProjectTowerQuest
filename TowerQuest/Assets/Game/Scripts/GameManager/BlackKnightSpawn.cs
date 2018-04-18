using UnityEngine;
public class BlackKnightSpawn : MonoBehaviour 
{

    [SerializeField]
    GameObject blackBlock;

    GameObject bkc;

    void Awake()
    {
        if (!CheckContainer())
        {
            bkc = new GameObject("BKContainer");
            bkc.transform.position = new Vector3(0, 0, 0);
        }
    }

    public void Spawn(Vector3 spawnPos)
    {
        GameObject jibk = Instantiate(blackBlock, spawnPos, Quaternion.identity);
        jibk.transform.parent = bkc.transform;
        //add here the enemy behaviour script
    }

    bool CheckContainer()
    {
        bkc = GameObject.Find("BKC");
        if (bkc != null)
            return false;
        else
            return true;
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/