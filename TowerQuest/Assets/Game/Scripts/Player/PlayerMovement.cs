using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour 
{

    //potenza di salto de velocità di spostamento consigliate 500 e 20; :D
    [SerializeField]
    float moveSpeed = 20, jumpForce = 400;

    //reference al rigidbody2D
    Rigidbody2D rb2d;

    //variabile che definisce se il player è in collisione con il terreno
    bool grounded;

    //direzione ed intesità del movimento
    float dirAndInt;

    //pos x per il wrapping
    float posx;
    //xse per il wrapping
    float XSE;

    void Awake () 
	{
        //setta la reference al rigidbody
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        
        #region platform log
        if (Application.isMobilePlatform) { Debug.Log("DUMMY MOBILE"); }
        else if (Application.isEditor) { Debug.Log("DUMMY EDITOR"); }
        #endregion
    }

    private void Start()
    {
        GameObject Mcam = GameObject.FindGameObjectWithTag("MainCamera");
        //settaXSE
        XSE = Mcam.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height;
    }

    void FixedUpdate () 
	{

        #region direction and intensity on hor. axe

        //prendi rirezione e indensità del movimento sull'asse X dall'accellerometro
        if (Application.isMobilePlatform)
        {
            dirAndInt = Input.acceleration.x;
        }
        else if (Application.isEditor)
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

    }

    #region OnCollisionEnter w/ ground
    //rileva le collisioni
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //se il collisore ha il tag ground
        if (collision.collider.tag == ("Plat") && rb2d.velocity.y < 0.5f)
        {
            //quindi sono poggiato a terra
            grounded = true;
        }
    }
    #endregion

    #region wrap

    private void Wrap()
    {
        if (posx < -XSE + 0.9f) 
        {
            transform.position = new Vector3(XSE, transform.position.y, transform.position.z);
        }
        if (posx > XSE - 0.9f) 
        {
            transform.position = new Vector3(-XSE, transform.position.y, transform.position.z);
        }
    }

    #endregion

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
