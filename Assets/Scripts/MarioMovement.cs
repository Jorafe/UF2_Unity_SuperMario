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

    public Transform bulletSpawn;

    public GameObject bulletPrefab;

    private bool canShoot = true;

    public float timer;

    public float rateOffire = 1;

    public Transform hitBox;

    public float hitBoxRadius = 2;



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

        Jump();
        
        Movement();

        Shoot();

        if(Input.GetKeyDown(KeyCode.J))
        {
            //Attack();
            anim.SetTrigger("isAtaking");
        }

    }

    void FixedUpdate()
    {
       rBody.velocity = new Vector2(imputHorizontal * movementSpeed, rBody.velocity.y); 
    }
    void Jump()
    {
         if(Input.GetButtonDown("Jump") && sensor. isGrounded == true)
        {   
                rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse); 
                anim.SetBool("isJumping", true);
                source.PlayOneShot(jumpSound);
        }
    }
    void Movement()
    {
        if(imputHorizontal < 0)
        {
            //render.flipX = true;
            transform.rotation = Quaternion.Euler(0,180,0);
            anim.SetBool("isRunning", true);
        }
        else if(imputHorizontal > 0)
        {
            //render.flipX = false;
            transform.rotation = Quaternion.Euler(0,0,0);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    void Shoot()
    {
        if(!canShoot)
        {
            timer += Time.deltaTime;

            if(timer >= rateOffire)
            {
                canShoot = true;
                timer = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            canShoot = false;
        }
    }

    void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitBox.position,hitBoxRadius);

        foreach (Collider2D enemy in enemies)
        {
            if(enemy.gameObject.tag == "Goombas")
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}
