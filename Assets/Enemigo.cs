using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(2);
        }
    }
    
    private void Deteccion (){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, 1);
        foreach( Collider2D colisionador in objetos){
            Personaje Personaje = colisionador.transform.GetComponent<Personaje>();
            if (Personaje != null){

                Personaje.Destruir_Personaje(true);
            }
        }
    }
    void Update (){
        Deteccion();
    }
}
