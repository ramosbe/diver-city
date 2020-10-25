using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    public int cherryCounter;
    public bool counterOpen = true;

    private void Start()
    {
        cherryCounter = 0;
    }

    private void OnTriggerEnter2D (Collider2D collisionInfo)
    {
      if (collisionInfo.GetComponent<Collider2D>().CompareTag("collectable"))
        {
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
            Invoke("releaseCounter", 1f);
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
