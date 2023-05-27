using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combateMelee : MonoBehaviour
{
    Animator animador;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    
    private void Golpe (){
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
    void Start()
    {
        animador = GetComponent<Animator>();
    }

    public void Ataque(){
        animador.SetTrigger("ataque");
        Golpe();
    }

    // Update is called once per frame
    void Update()
    {
        //  if (Input.GetMouseButtonDown(0))
        // {
        //     animador.SetTrigger("ataque");
        //     Golpe();
        // }
    }
}
