using System;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    public Transform player;
    private bool alive = true;   //FOR PLAYERMOVEMENT SCRIPT

    private void OnTriggerEnter2D (Collider2D collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider2D>().CompareTag("deathZone"))
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Collider2D>().CompareTag("enemy"))
        {
            Death();
        }
    }
    private void Death()
    {
        alive = false;
        Invoke("Rebirth", 1f);

    }
    private void Rebirth()
    {
        alive = true;
        player.position = respawnPoint.position;
    }
    //CALLED BY PLAYERMOVEMENT and FrogRespawn
    public bool IsAlive()
    {
        return alive;
    }

}
