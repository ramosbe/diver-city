using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    //public GameObject gamePause;
    public static bool gamePaused;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
                
                
            }
            else
            {
                PauseGame();
                
            }
        }
    }

    public void PauseGame()
    {
        music.Pause();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        music.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        // to be completed later
        Application.Quit();
        Debug.Log("Quit button Pressed");
    }

}
