/***using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MI DEVO RIPRENDERE IL BLOCCO : MonoBehaviour
{
    #region variables

    //screen edges
    float XSE;

    #region references
    //camera reference         
    GameObject Mcam;

    //reference al rigidbody2D
    Rigidbody2D rb2d;
    
    //ref position x
    float posx;
    
    //stamina
    float stamina, maxStam = 25, staminaDec = 10, staminaInc = 2.5f;
    
    //pausa ref
    GameManager GM;
    
    //coloriiiiii
    Color normalColor;

    [SerializeField]
    Color lockColor;
    
    #endregion

    //potenza di salto e velocità di spostamento consigliate 500 e 20; :D
    [SerializeField]
    float moveSpeed, jumpForce = 500;
    
    //direzione ed intesità del movimento
    float dirAndInt;
    
    //variabile che definisce se il player è in collisione con il terreno
    bool grounded;

    //sto bloccando?
    bool block = false;
    
    #endregion

    #region methods 

    private void Awake()
    {
        #region assignment
        //set reference to main cam
        Mcam = GameObject.FindGameObjectWithTag("MainCamera");

        //reference to the rigidbody 2D
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        #endregion

        //reference al game manager
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //a quanto ammonta la max stamina
        maxStam = gameObject.GetComponent<PlayerStat>().GetMStamina();
        //massimizza la stamina
        stamina = maxStam;
        //di che colore è il player
        normalColor = gameObject.GetComponent<SpriteRenderer>().color;

        #region platform log
        if (Application.isMobilePlatform) { Debug.Log("DUMMY MOBILE"); }
        else if (Application.isEditor) { Debug.Log("DUMMY EDITOR"); }
        #endregion

        UpdateStamina();
    }

    private void FixedUpdate()
    {
        #region camera edges settings
        XSE = Mcam.GetComponent<CheckScreenLimits>().horEdge;
        #endregion

        #region direction and intensity on hor. axe
        //prendi rirezione e indensità del movimento sull'asse X dall'accellerometro
        if (Application.isMobilePlatform)
        {
            dirAndInt = Input.acceleration.x;
        }else if (Application.isEditor)
        {
            dirAndInt = Input.GetAxis("Horizontal");
        }
        //imposta la VELOCITY sull'asse orizzontale senza modificare quella sull'asse verticale
        rb2d.velocity = new Vector3(dirAndInt * moveSpeed, rb2d.velocity.y);
        #endregion

        #region autoJump
        //se poggiato a terra
        if (grounded)
        {
            //salta automaticamente
            rb2d.AddForce(Vector2.up * jumpForce);
            //se salto non collido più con il terreno
            grounded = false;
        }
        #endregion

        #region wrap
        //ref to position
        posx = transform.position.x;
        //Wrap player... works better than expected
        if (posx < -XSE || posx > XSE)
        {
            Wrap();
        }
        #endregion


        UpdateStamina();

        if (!GM.IsPaused())
        {
            CheckBlock();
            Block();
        }
    }

    #region OnCollisionEnter w/ ground
    //rileva le collisioni
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //se il collisore ha il tag ground
        if (collision.collider.tag == ("Plat") && rb2d.velocity.y < 0.5) 
        {
            //quindi sono poggiato a terra
            grounded = true;
        }
    }
    #endregion

    private void Wrap()
    {
        if (posx < -XSE)
        {
            transform.position = new Vector3(XSE, transform.position.y, transform.position.z);
        }
        if( posx > XSE)
        {
            transform.position = new Vector3(-XSE, transform.position.y, transform.position.z);
        }
    }

    //ogni volta che viene chiamato aggiorna la variabile locale della stamina
    private void UpdateStamina()
    {
        stamina = gameObject.GetComponent<PlayerStat>().GetStamina(); 
    }

    //ogni olta che viene chiamato aggiorna il valore originale della stamina
    private void SetStamina(float stamQ)
    {
        gameObject.GetComponent<PlayerStat>().AddStamina(stamQ);
    }

    //properFunciont to block
    private void Block()
    {
        if (block && stamina >= 0) 
        {
            SetStamina(-staminaDec * Time.deltaTime);
            gameObject.GetComponent<Collider2D>().isTrigger = block;
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
            gameObject.GetComponent<SpriteRenderer>().color = lockColor;
        }else if (!block || stamina <= 0)
        {
            block = false;
            if (stamina < maxStam)
            {
                SetStamina(staminaInc * Time.deltaTime);
            }
            gameObject.GetComponent<Collider2D>().isTrigger = block;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.GetComponent<SpriteRenderer>().color = normalColor;
        }
    }

    //controlla se il giocatore sta toccando lo schermo o se dall'editor arrivano input
    private void CheckBlock()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                block = true;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                block = false;
            }
        }
        if (Application.isEditor)
        {
            DebugBlock();
        }
        
    }

    //input di debug dall'editor
    private void DebugBlock()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            block = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            block = false;
        }
    }

    #endregion
}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/

