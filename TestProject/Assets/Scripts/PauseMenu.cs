using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadLevel01()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        if(sceneNumber == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        else if(sceneNumber == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            Debug.Log("SceneNumber: " + sceneNumber);
        }
    }

    public void LoadLevel02()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (sceneNumber == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (sceneNumber == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        else
        {
            Debug.Log("SceneNumber: " + sceneNumber);
        }
    }
}
