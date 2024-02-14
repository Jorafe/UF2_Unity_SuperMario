using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public Rigidbody2D rBody;
    public GroundSensor sensor;
    public SpriteRenderer render;
    public Animator anim;
    AudioSource source;

    public Vector3 newPosition = new Vector3(-107, -5, 0);

    public float movementSpeed = 5;
    public float jumpforce = 10;
    private float imputHorizontal;

    public bool jump = false;

    public AudioClip jumpSound;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //teletransporta al personaje a la posicion de la variable newPosition
        //transform.position = newPosition;

    }

    // Update is called once per frame
    void Update()
    {
        imputHorizontal = Input.GetAxis("Horizontal");

        //transform.position = transform.position + new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        //transform.position += new Vector3(imputHorizontal, 0, 0) * movementSpeed * Time.deltaTime;

        /*if(jump == true)
        {
            Debug.Log("estoy saltando");
        }
        else if(jump == false)
        {
            Debug.Log("estoy en el suelo");
        }
        else
        {
            Debug.Log("gjfjtf")
        }*/

        if(Input.GetButtonDown("Jump") && sensor. isGrounded == true)
        {   
                rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse); 
                anim.SetBool("isJumping", true);
                source.PlayOneShot(jumpSound);
        }
        
        if(imputHorizontal < 0)
        {
            render.flipX = true;
            anim.SetBool("isRunning", true);
        }
        else if(imputHorizontal > 0)
        {
            render.flipX = false;
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }

    void FixedUpdate()
    {
       rBody.velocity = new Vector2(imputHorizontal * movementSpeed, rBody.velocity.y); 
    }
}
