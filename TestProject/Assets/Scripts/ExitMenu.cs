using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    private const int SceneBuildIndex = 1;

    public void PlayGameAgain()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Button pressed");
        Application.Quit();
    }
}
