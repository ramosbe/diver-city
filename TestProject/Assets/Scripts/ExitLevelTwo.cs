using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelTwo : MonoBehaviour
{
    private bool playerInRange;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerInRange)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player in range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player left range");
            playerInRange = false;
        }
    }
}
