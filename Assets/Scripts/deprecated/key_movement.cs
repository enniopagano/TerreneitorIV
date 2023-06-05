using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_movement : MonoBehaviour
{
    [SerializeField] KeyCode _up;
    [SerializeField] KeyCode _left;
    [SerializeField] KeyCode _down;
    [SerializeField] KeyCode _right;
    [SerializeField] KeyCode _jump;

    [SerializeField] float _step;
    Transform t;
    Vector3 p;
    private void Awake(){
        t = GetComponent<Transform>();
        // Mateo.HorizontalBounce();

    }
    void Mover(Transform t, Vector3 p){
        t.position = p;
    
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown( _up ))
        {
            
            p=new Vector3(t.position.x, t.position.y + _step);
            Mover(t,p);
        }
        if(Input.GetKeyDown( _left ))
        {
            p=new Vector3(t.position.x - _step, t.position.y );
            Mover(t,p);
        }
        if(Input.GetKeyDown( _right ))
        {
            p=new Vector3(t.position.x  + _step, t.position.y );
            Mover(t,p);        }
        if(Input.GetKeyDown( _down ))
        {
            p=new Vector3(t.position.x  , t.position.y - _step );
            Mover(t,p);            }
        // if(t.position.y <= -4.36f)
        // {
        //     p=new Vector3(t.position.x  , -4.35f );
        //     Mover(t,p);            
        // }
        // if(t.position.y <= -4.36f)
        // {
        //     p=new Vector3(t.position.x  , -4.35f );
        //     Mover(t,p);            
        // }
        // if(t.position.y >= 4.36f)
        // {
        //     p=new Vector3(t.position.x  , 4.35f );
        //     Mover(t,p);            
        // }
    }
}
