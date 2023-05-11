using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void force_up(float force, Rigidbody2D rigid){
       rigid.AddForce(0,force,0,ForceMode.Impulse);
    }
    public void force_left(float force, Rigidbody2D rigid){
        rigid.AddForce(force,0,0,ForceMode.Impulse);
    }
    public void force_down(float force, Rigidbody2D rigid){
        rigid.AddForce(0,-force,0,ForceMode.Impulse);
    }
    public void force_right(float force, Rigidbody2D rigid){
        rigid.Addforce(-force,0,0,Forcemode.Impulse);
    }
}
