using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
    // https://youtu.be/yWCHaTwVblk?t=190   
 }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarVolumen(){
        Audiolistener.volume = volumeSlider.value;
        GuardarVolumen();
    }
    private void CargarVolumen(){
        volumeSlider.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    private void GuardarVolumen(){
        PlayerPrefs.SetFloat("musicVolume",volumeSlider.value);
    }

}
