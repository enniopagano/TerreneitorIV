using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void force_up(float force, Rigidbody2D rigid){
       rigid.AddForce(new Vector2(0,force),ForceMode2D.Impulse);
    }
    public void force_left(float force, Rigidbody2D rigid){
        rigid.AddForce(new Vector2(force,0),ForceMode2D.Impulse);
    }
    public void force_down(float force, Rigidbody2D rigid){
        rigid.AddForce(new Vector2(0,-force),ForceMode2D.Impulse);
    }
    public void force_right(float force, Rigidbody2D rigid){
        rigid.AddForce(new Vector2(force,0),ForceMode2D.Impulse);
    }
}
