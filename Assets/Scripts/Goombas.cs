using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goombas : MonoBehaviour
{
    public Rigidbody2D rBody;

    private AudioSource source;

    private BoxCollider2D boxCollider;

    public AudioClip deathSound;

    public float enemySpeed = 5;

    public float enemyDirection = 1;

    //rBodyGet = component<Rigidbody2D>();
    //source = <GetComponent>();

    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(enemyDirection * enemySpeed, rBody.velocity.y);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3 ||collision.gameObject.tag == "Goomba")
    
        if(enemyDirection == 1)
        {
            enemyDirection = -1;
        }
        else if(enemyDirection == -1)
        {
            enemyDirection = 1;
        } 
        if(collision.gameObject.tag == "Player")
    {
       Destroy(collision.gameObject);
       SceneManager.LoadScene("Game Over");
    }
   
    }

    public void GoombaDeth()
    {
        source.PlayOneShot(deathSound);
        boxCollider.enabled = false;
        rBody.gravityScale = 0;
        enemyDirection = 0;
        Destroy(gameObject);
    }
    
    }

   
 
    

