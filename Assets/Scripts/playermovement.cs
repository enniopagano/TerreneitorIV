using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

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

    public GameObject particles;


    Movement movementscript;
    Personaje personajescript;
    Rigidbody2D rigid;

    // estado de los punteros de salto
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;

    public float maxSpeed;


    // Audio

    public AudioSource source; // Fuente del audio a.k.a de donde sale el sonido

    public AudioClip[] PasosEnPiedra; // array de audios
    public AudioClip SaltoEnPiedra;
    public AudioClip AterrizajeEnPiedra;

    AudioClip RandomClip(AudioClip[] audioClipArray){
        return audioClipArray[Random.Range(0, audioClipArray.Length-1)]; // funcion que devuelve un audio aleatorio dentro de una lista
    }

    // prueba
    public float xDistanceThreshold = 2f;
    public float yDistanceThreshold = 1f;

    private Vector3 lastPosition;
    // prueba

    private RaycastHit2D floorRaycast;
    private int jumpCount;
    private int dashCount;

    
    private Transform t;
    private void Awake(){
        t = GetComponent<Transform>();
        source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        particles.SetActive(false);
        
        movementscript = GameObject.FindObjectOfType<Movement>(); // buscamos el script movement
        personajescript = GameObject.FindObjectOfType<Personaje>();
        
        rigid = GetComponent<Rigidbody2D>();
        
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation; // hacemos que el rigidbody no pueda rotar

        // iniciamos las variables como si nada estuviera presionado
        moveUp = false;
        moveRight = false; 
        moveDown = false;
        moveLeft = false;

        jumpCount = 0;
        dashCount = 0;

        lastPosition = transform.position;

    }
    // Update se llama 1 vez por frame
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
        Scene scene = SceneManager.GetActiveScene();
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
        if(t.position.y < -22){
            personajescript.Destruir_Personaje(true);
        }
        
        if(t.position.x >= 105 && scene.name =="Nivel(1)"){
            SceneManager.LoadScene("Nivel(2)");
            Debug.Log("Deberia Cargar");
        }
        
        if (lastPosition.y < transform.position.y){
            lastPosition.y = transform.position.y;
        }
        // if(t.position.x < -16){
        //     Debug
        //     source.Play();
        // }
    }
    
    
    private bool isGrounded(){
        if(floorRaycast){
            //Debug.Log("it is grounded");    
        float xDistanceMoved = Mathf.Abs(transform.position.x - lastPosition.x);
        if (xDistanceMoved >= xDistanceThreshold)
        {
            AudioSource.PlayClipAtPoint(RandomClip(PasosEnPiedra), transform.position);
            lastPosition.x = transform.position.x;
        }
            jumpCount = 0;
            dashCount = 0;
            return true;
        }
        else{
            //Debug.Log("it is not grounded");
            return false;
        }
    }

    private async Task setFalse(){
        await Task.Delay(1500);
        particles.SetActive(false);
    }

    // si la distancia entre el punto maximo de altura y el piso es mayor a yDistanceThreshold
    private void groundValidation(){
        if(floorRaycast){
        float yDistanceMoved = Mathf.Abs(transform.position.y - lastPosition.y);
        if (yDistanceMoved >= yDistanceThreshold){
        // Debug.Log("yDistanceMoved" + yDistanceMoved);
            AudioSource.PlayClipAtPoint(AterrizajeEnPiedra, transform.position);
            particles.SetActive(true);
            setFalse();
        }
        lastPosition.y = transform.position.y;
            rigid.drag = 10f;
            rigid.gravityScale = 0;
        }else{
            rigid.drag = 0f;
            rigid.gravityScale = ToSingle(1.4);
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
        AudioSource.PlayClipAtPoint(SaltoEnPiedra, transform.position);
    }
}
public void left(){
    if (isGrounded() ){
        GetComponent<SpriteRenderer>().flipX = true;
        //movementscript.velocity_left(horizontalForce,rigid);
        movementscript.force_left(horizontalForce,rigid, ForceMode2D.Force);
    }else{ // si esta en el aite, que se mueva poco
        movementscript.force_left(ToSingle(horizontalForce*0.02),rigid, ForceMode2D.Force);
    }
}
public void right(){
    if (isGrounded()){
        GetComponent<SpriteRenderer>().flipX = false;
        //movementscript.velocity_right(ToSingle(horizontalForce*0.5),rigid);
        movementscript.force_right(horizontalForce,rigid, ForceMode2D.Force);
    }else{ // si esta en el aire, que se mueva poco
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
