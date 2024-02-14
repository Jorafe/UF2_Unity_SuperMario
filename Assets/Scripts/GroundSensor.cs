using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;

    public Animator anim;
    
    MarioMovement MarioMovement;


    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        MarioMovement = GetComponentInParent<MarioMovement>();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.gameObject.tag == "Goomba")
        {
             MarioMovement.rBody.AddForce(Vector2.up * MarioMovement.jumpforce, ForceMode2D.Impulse); 
             anim.SetBool("isJumping", true);

            //Destroy(collider.gameObject);
            Goombas goomba = collider.gameObject.GetComponent<Goombas>();

            goomba.GoombaDeth();
        }

        isGrounded = true;
        anim.SetBool("isJumping", false);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
