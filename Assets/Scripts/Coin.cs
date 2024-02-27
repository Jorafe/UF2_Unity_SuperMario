using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

     private AudioSource source;

     public AudioClip coinSound;

    private BoxCollider2D boxCollider;

    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Puntos puntos;


    // Start is called before the first frame update
    void Awake()
    {
     source = GetComponent<AudioSource>();
    }

 

    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if(collider.gameObject.tag == "Player")
    {
        puntos.SumarPuntos(cantidadPuntos);
       source.PlayOneShot(coinSound);
       Destroy(gameObject, 0.5f);
    }

    }

}
