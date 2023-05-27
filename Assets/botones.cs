using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    public void Force_up (float force, Rigidbody2D rigid){
       rigid.AddForce(new Vector2(0,force),ForceMode2D.Impulse);
    }
    public void Force_left(float force, Rigidbody2D rigid){
        rigid.AddForce(new Vector2(force,0),ForceMode2D.Impulse);
    }
    public void Force_down(float force, Rigidbody2D rigid){
        rigid.AddForce(new Vector2(0,-force),ForceMode2D.Impulse);
    }
    public void Force_right(float force, Rigidbody2D rigid){
        rigid.AddForce(new Vector2(force,0),ForceMode2D.Impulse);
    }
}
