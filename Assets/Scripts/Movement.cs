using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigid;
    public float thrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = Getcomponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void force_up(float force){
       rigid.AddForce(0,force,0,ForceMode.Impulse);
    }
    public void force_left(float force){
        rigid.AddForce(force,0,0,ForceMode.Impulse);
    }
    public void force_down(float force){
        rigid.AddForce(0,-force,0,ForceMode.Impulse);
    }
    public void force_right(float force){
        rigid.Addforce(-force,0,0,Forcemode.Impulse);
    }
}
