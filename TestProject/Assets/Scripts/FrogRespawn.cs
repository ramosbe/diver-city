using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogRespawn : MonoBehaviour
{
    public Transform frog;
    public Transform respawnPoint; //use this to get spot for respawn
    public Respawn playerRespawn;
    private bool respawnLock = false;

    private void Start()
    {
        playerRespawn = GameObject.Find("player").GetComponent<Respawn>();
        frog.DetachChildren();
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerRespawn.IsAlive() && !respawnLock)
        {
            respawnLock = true;
            Invoke("RespawnFrog", 1f);
        }
    }
    private void RespawnFrog()
    {
        frog.position = respawnPoint.position;
        respawnLock = false;
        Debug.Log("respawnnnn");
    }
}
