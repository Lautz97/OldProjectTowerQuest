using UnityEngine;
public class BlockAndStamina : MonoBehaviour {

    float stamina = 0;
    float staminaMax = 10;
    float staminaDec = 5;
    float staminaInc = 1;

    bool block = false;

    Color normalC;
    Color blockC= Color.green;

    GameObject Mcam;
	// Use this for initialization

    void Awake ()
    {
        stamina = staminaMax;
        normalC = gameObject.GetComponent<SpriteRenderer>().color;
        Mcam = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool pause = Mcam.GetComponent<GameManager>().IsPaused();
        if (!pause)
        {
            ReadBlock();
            Block(block,pause);
        }
	}

    void Block(bool blockVoid,bool ispaused)
    {
        if (!blockVoid || stamina <= 0 || ispaused)
        {
            if (gameObject.GetComponent<Collider2D>().isTrigger)
            {
                //gameObject.GetComponent<Collider2D>().isTrigger = false;
            }
            if (stamina < staminaMax)
            {
                stamina += staminaInc * Time.deltaTime;
            }
            if (gameObject.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePosition)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            if (gameObject.GetComponent<SpriteRenderer>().color == blockC)
            {
                gameObject.GetComponent<SpriteRenderer>().color = normalC;
            }
        }
        if (blockVoid && stamina > 0)
        {
            if (stamina <= 0.5f)
            {
                block = false;
                Block(block, ispaused);
            }
            if (stamina > 0)
            {
                stamina -= staminaDec * Time.deltaTime;
                if (!gameObject.GetComponent<Collider2D>().isTrigger)
                {
                    //gameObject.GetComponent<Collider2D>().isTrigger = true;
                }
                if (gameObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezePosition) 
                {
                    gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                }
                if (gameObject.GetComponent<SpriteRenderer>().color == normalC)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = blockC;
                }
            }
        }
    }

    void ReadBlock()
    {
        //debug

        if (Input.GetKeyDown(KeyCode.Space))
        {
            block = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            block = false;
        }

        //end debug

        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                block = true;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                block = false;
            }
        }
    }

    public bool isBlocking()
    {
        return block;
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
