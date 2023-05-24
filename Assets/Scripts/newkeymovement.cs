using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newkeymovement : MonoBehaviour
{

    [SerializeField] KeyCode keyup ;
    [SerializeField] KeyCode keyleft;
    [SerializeField] KeyCode keydown;
    [SerializeField] KeyCode keyright;
    [SerializeField] KeyCode keydash;


    [SerializeField] float horizontal;
    [SerializeField] float jump;
    [SerializeField] float descend;
    [SerializeField] float dash;

    Movement movementscript;
    Rigidbody2D rigid;


    Transform t;
    Vector3 p;
    private void Awake(){
        t = GetComponent<Transform>();

    }
    void Mover(Transform t, Vector3 p){
        t.position = p;
    
    }
    // Start is called before the first frame update
    void Start()
    {
        movementscript = GameObject.FindObjectOfType<Movement>();
        rigid = GetComponent<Rigidbody2D>();
        
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    public LayerMask groundLayer;
    
    bool isGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value)) {
            return true;
        }
        else {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown( keyup )&& isGrounded())
        {
            movementscript.force_up(jump,rigid);
        }
        if(Input.GetKey( keyleft )&& isGrounded())
        {
            movementscript.force_left(horizontal,rigid);
            // Flip ();
            // facingRight = false;
        }
        if(Input.GetKey( keyright )&& isGrounded())
        {
            movementscript.force_right(horizontal,rigid);

        }       
        if(Input.GetKey( keydown ))
        {
            movementscript.force_down(descend,rigid);
        }


    
    }




}
