using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    void Awake(){

    }
    float vida;

   void Start(){
    vida = 100;
    }
    public void TomarDaño(float daño){
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
