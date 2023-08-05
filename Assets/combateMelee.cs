using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class combateMelee : MonoBehaviour
{
    Animator animador;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    public AudioSource source;
    void Start()
    {
        animador = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    private void Golpe (){
        source.Play();
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radioGolpe);
        foreach( Collider2D colisionador in objetos){
            Enemigo enemigoTemporal = colisionador.transform.GetComponent<Enemigo>();
            if (enemigoTemporal != null){

                enemigoTemporal.TomarDaño(dañoGolpe);
            }
        }

    }

    // void OnTriggerEnter2D(Collider2D colisionador){

    // }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioGolpe);
        Debug.Log(transform.position);
    }

    // Start is called before the first frame update

    // Update is called once per frame
    public void Atacar(){
        animador.SetTrigger("ataque");
        Golpe();
    }
    void Update()
    {

    }
}
