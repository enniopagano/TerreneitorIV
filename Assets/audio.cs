using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource source;
    private Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
       if(t.position.x < -23){
            
            source.Play();
        }
    }
}
