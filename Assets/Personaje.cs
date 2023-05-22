using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Destruir_Personaje(bool condicional){
        if(condicional){
            Destroy(this.gameObject);
        }else{
            Debug.Log("loool");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
