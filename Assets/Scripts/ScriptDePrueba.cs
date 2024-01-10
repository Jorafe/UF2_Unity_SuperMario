using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDePrueba : MonoBehaviour
{

    public int livesCharacter = 3;
    public int livesCharacter2 = 4;
    public float numeroDecimal = 4.5f;
    public string nameCharacter = "Mario";
    public bool interruptor = true;
    

    // Start is called before the first frame update
    void Start()
    {
        livesCharacter = 10;
        numeroDecimal = 7.54f;
        nameCharacter = "Luigy";
        interruptor = false;

        int suma = livesCharacter + livesCharacter2;
        Debug.Log(suma);
        string sumaTextos = nameCharacter + "Warrio";
        Debug.Log(sumaTextos);

      Debug.Log(nameCharacter);
      Debug.Log(livesCharacter);
      Debug.Log(numeroDecimal);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
