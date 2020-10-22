using System;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    public Transform player;
    private bool alive = true;

    private void OnTriggerEnter2D (Collider2D collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider2D>().CompareTag("deathZone"))
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
    public bool IsAlive()
    {
        return alive;
    }

}
