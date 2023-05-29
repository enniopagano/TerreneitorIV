using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // teclas del teclado para cada movimiento
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyDown = KeyCode.S;
    public KeyCode keyRight = KeyCode.D;
    public KeyCode keyWalk = KeyCode.LeftControl;
    public KeyCode keyDash = KeyCode.LeftShift;

    // la fuerza aplicada a cada uno de los movimientos
    [SerializeField] float horizontalForce;
    [SerializeField] float jumpForce;
    [SerializeField] float descendForce;
    [SerializeField] float dashForce;

    // numero de movimientos que queramos
    [SerializeField] int jumpNumber;
    [SerializeField] int dashNumber;


    // capa con la que se verificara si el pj esta en contacto con un objeto solido donde se podra recargar movimientos como saltos o dashes o se podra mover.
    [SerializeField] LayerMask floorLayer;

    public Vector3 boxSize;
    public float boxDistance;


    Movement movementscript;
    Rigidbody2D rigid;

    // estado de los punteros de salto
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;

    public float maxSpeed;

    private RaycastHit2D floorRaycast;
    private int jumpCount;
    private int dashCount;



    private void Awake(){
        //t = GetComponent<Transform>();

    }
    // Start is called before the first frame update
    void Start()
    {
        movementscript = GameObject.FindObjectOfType<Movement>(); // buscamos el script movement
        
        rigid = GetComponent<Rigidbody2D>();
        
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation; // hacemos que el rigidbody no pueda rotar

        // iniciamos las variables como si nada estuviera presionado
        moveUp = false;
        moveRight = false; 
        moveDown = false;
        moveLeft = false;

        jumpCount = 0;
        dashCount = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown( keyUp )){
            moveUp = true;
        }
        if(Input.GetKeyDown( keyLeft )){
            moveLeft = true;
        }
        if(Input.GetKeyDown( keyRight )){
            moveRight = true;
        }
        if(Input.GetKeyDown( keyDown )){
            moveDown = true;
        }
        if(Input.GetKeyUp( keyUp )){
            moveUp = false;
        }
        if(Input.GetKeyUp( keyLeft )){
            moveLeft = false;
        }
        if(Input.GetKeyUp( keyRight )){
            moveRight = false;
        }
        if(Input.GetKeyUp( keyDown )){
            moveDown = false;
        }

        groundValidation();
    }
    // el fixupdate nos da un resultado reproducible no dependiente del hardware, por tanto nos es util para la simulacion de fisicas
    void FixedUpdate(){ 
        floorRaycast = Physics2D.BoxCast(transform.position, boxSize, 0f, -transform.up, boxDistance, floorLayer);

    
        if(moveUp){
            up();
            moveUp = false;
            // moveUp false para que cuando se pulse el boton solo salte una vez por click
        }
        if(moveLeft){
            left();
        }
        if(moveRight){
            right();
        }       
        if(moveDown){
            down();
        }
        rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
    }
    
    
    private bool isGrounded(){
        if(floorRaycast){        
            jumpCount = 0;
            dashCount = 0;
            //Debug.Log("it is grounded");    
            return true;
        }
        else{
            //Debug.Log("it is not grounded");
            return false;
        }
    }
    private void groundValidation(){
        if(floorRaycast){
            rigid.drag = 6f;
        }else{
            rigid.drag = 0f;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawCube(transform.position-transform.up*boxDistance,boxSize);
    }



bool countValidator(int count , int number){
    if(count < number){
        //Debug.Log("true, count is " + count + " and number is " + number);
        return true;
    }else{
        //Debug.Log("False, count is " + count + " and number is " + number);
        return false;
    }
}

public void up(){
    if (isGrounded()||countValidator(jumpCount,jumpNumber)){
        jumpCount++;
        movementscript.force_up(jumpForce,rigid,ForceMode2D.Impulse);
    }
}
public void left(){
    if (isGrounded() ){
        GetComponent<SpriteRenderer>().flipX = true;
        //movementscript.velocity_left(horizontalForce,rigid);
        movementscript.force_left(horizontalForce,rigid, ForceMode2D.Force);
    }else{
        movementscript.force_left(ToSingle(horizontalForce*0.02),rigid, ForceMode2D.Force);
    }
}
public void right(){
    if (isGrounded()){
        GetComponent<SpriteRenderer>().flipX = false;
        //movementscript.velocity_right(ToSingle(horizontalForce*0.5),rigid);
        movementscript.force_right(horizontalForce,rigid, ForceMode2D.Force);
    }else{ // si esta en el aire, que se pueda mover poco
        movementscript.force_right(ToSingle(horizontalForce*0.02),rigid, ForceMode2D.Force);
    }
}
public void down(){
    movementscript.force_down(descendForce,rigid,ForceMode2D.Impulse);
}

// las siguientes funciones fueron creadas principalmente para los botones por que tienen un evento de apretar y otro de soltar.
    public void PointerDownUp(){
        moveUp = true;
    }
    public void PointerUpUp(){
        moveUp = false;
    }
    public void PointerDownRight(){
        moveRight = true;
    }
    public void PointerUpRight(){
        moveRight = false;
    }
    public void PointerDownDown(){
        moveDown = true;
    }
 
    public void PointerUpDown(){
        moveDown = false;
    }
    public void PointerDownLeft(){
        moveLeft = true;
    }
 
    public void PointerUpLeft(){
        moveLeft = false;
    }
 
 // una funcion que convierte doubles a floats porque c# se pone a hacer doubles al hacer operaciones simples
public static float ToSingle(double value)
{
     return (float)value;
}

}
