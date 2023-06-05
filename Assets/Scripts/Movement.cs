using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    // resultados mas realistas, se añade una fuerza externa que se agrega segun las leyes fisicas de unity

    // no utilizamos las velocidades actuales porque eso generaria un efecto exponencial
public void force_up(float force, Rigidbody2D rigid, ForceMode2D forceMode){
    rigid.AddForce(new Vector2(0, force), forceMode);
}

public void force_left(float force, Rigidbody2D rigid, ForceMode2D forceMode){
    rigid.AddForce(new Vector2(-force, 0), forceMode);
}

public void force_down(float force, Rigidbody2D rigid, ForceMode2D forceMode){
    rigid.AddForce(new Vector2(0, -force), forceMode);
}

public void force_right(float force, Rigidbody2D rigid, ForceMode2D forceMode){
    rigid.AddForce(new Vector2(force, 0), forceMode);
}
    // velocidades, no hay aceleracion ni agregacion de fuerzas, resultados mas esperados y menos variables, se sigue trabajando con fisicas

    public void velocity_up(float force, Rigidbody2D rigid){
       rigid.velocity = new Vector2(rigid.velocity.x,force);
    }
    public void velocity_left(float force, Rigidbody2D rigid){
        rigid.velocity = new Vector2(-force,rigid.velocity.y);
    }
    public void velocity_down(float force, Rigidbody2D rigid){
        rigid.velocity = new Vector2(rigid.velocity.x,-force);
    }
    public void velocity_right(float force, Rigidbody2D rigid){
        rigid.velocity = new Vector2(force,rigid.velocity.y);
    }
}
