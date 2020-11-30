using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    public int cherryCounter;
    public bool counterOpen = true;
    public AudioSource[] collectSound; // array due to multiple audio components in player

    private void Start()
    {
        cherryCounter = 0;
        collectSound = GetComponents<AudioSource>();
    }

    private void OnTriggerEnter2D (Collider2D collisionInfo)
    {
      if (collisionInfo.GetComponent<Collider2D>().CompareTag("collectable"))
        {
            collectSound[0].Play(); // uses first audio component listed in player
            Destroy(collisionInfo.gameObject);
            IncreaseCherryCounter();
        }
    }

    private void IncreaseCherryCounter()
    {
        if (counterOpen)
        {
            cherryCounter++;
            counterOpen = false;
            Invoke("releaseCounter", 0.15f);
        }
    }
    private void releaseCounter()
    {
        counterOpen = true;
    }
    public int getCherryCounter()
    {
        return cherryCounter;
    }
}
