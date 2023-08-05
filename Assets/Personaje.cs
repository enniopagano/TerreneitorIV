using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    // Start is called before the first frame update
    Transform t;
    public AudioSource source_enemigo;
    void Awake(){
        source_enemigo = GetComponent<AudioSource>();
        t = GetComponent<Transform>();
    }
    public void Destruir_Personaje(bool condicional){
        if(condicional){
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }else{
            Debug.Log("loool");
        }
    }
    // Update is called once per frame
    // public void Sonido_enenmigo(){
    //     source_enemigo.Play();
    // }
    void Update()
    {
        //  if(t.position.x => -23 ){
        //      Sonido_enenmigo();
        // }
    }
}
