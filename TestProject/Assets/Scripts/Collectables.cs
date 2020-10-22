using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    public int cherryCounter;

    private void Start()
    {
        cherryCounter = 0;
    }

    private void OnTriggerEnter2D (Collider2D collisionInfo)
    {
      if (collisionInfo.GetComponent<Collider2D>().CompareTag("collectable"))
        {
            Destroy(collisionInfo.gameObject);
            Invoke("IncreaseCherryCounter", 0.1f);
        }
    }

    private void IncreaseCherryCounter()
    {
        cherryCounter++;
    }
}
