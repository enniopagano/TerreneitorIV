using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour
{
    [SerializeField] Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            anim.SetTrigger("Idle");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Ataque");
        }
    }
}
