using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public Vector3 newPosition = new Vector3(-107, -5, 0);

    public float movementSpeed = 5;
    private float imputHorizontal;

    public bool jump = false;

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
        transform.position += new Vector3(imputHorizontal, 0, 0) * movementSpeed * Time.deltaTime;

        if(jump == true)
        {
            Debug.Log("estoy saltando");
        }
        else if(jump == false)
        {
            Debug.Log("estoy en el suelo");
        }


    }
}
