using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Enemigo : MonoBehaviour
{
    public Mounstro mounstro;
    public SpriteRenderer spriteRenderer;
   
    void Awake(){

    }
    public Image imagen;
    float vida;
    int min = 1;
    int max = 3;
    int numeroAleatorio;
   void Start(){
    vida = 100;
    numeroAleatorio = Random.Range(min,max);
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    Debug.Log("salio el numero: "+numeroAleatorio);
    if (numeroAleatorio == 1)
    {
        spriteRenderer.sprite = mounstro.imagen1;
        Debug.Log("LO cambio a imagen1");
    }
    if(numeroAleatorio == 2){
        spriteRenderer.sprite = mounstro.imagen2;
        Debug.Log("Lo cambio a imagen2");
    }
        }
    public void TomarDaño(float daño){
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        }
    }
    
    private void Deteccion (){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, 3);
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
