using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause(){
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }
    public void Resume(){
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
