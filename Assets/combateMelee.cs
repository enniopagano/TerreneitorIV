using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
public class combateMelee : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    public AudioSource source;
    public AudioClip[] AtaquesaAire;
    public AudioClip[] AtaquesaEnemigo;
        AudioClip RandomClip(AudioClip[] audioClipArray){
        return audioClipArray[Random.Range(0, audioClipArray.Length-1)];
    }
    public void Awake(){
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    private void Golpe (){
    anim.SetBool("Ataque",true);
    anim.Play("Asalto");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radioGolpe);
        foreach( Collider2D colisionador in objetos){
            Enemigo enemigoTemporal = colisionador.transform.GetComponent<Enemigo>();
            if (enemigoTemporal != null){
                enemigoTemporal.TomarDaño(dañoGolpe);
                source.PlayOneShot(RandomClip(AtaquesaEnemigo));
            }
                        source.PlayOneShot(RandomClip(AtaquesaAire));
        }

    }

    // void OnTriggerEnter2D(Collider2D colisionador){

    // }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioGolpe);
        Debug.Log(transform.position);
    }

    // Start is called before the first frame update

    // Update is called once per frame
    public void Atacar(){
        // anim.Play("Asalto");
        Golpe();
    }
    void Update()
    {
if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque"))
        {
            anim.SetBool("Ataque",false);
        }
    }
}
