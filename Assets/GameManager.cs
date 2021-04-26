using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public float respawnTime;
    public int iLevelToRespawn = 1;
    private Transform respawnPoint;

    private float respawnTimeStart;
    private bool respawn;

    public void Update()
    {
        CheckRespawn();
    }

    public void Respawn()
    {
        respawnTimeStart = Time.time;
        respawn = true;
    }

    void SearchSpawnPoint()
    {
        respawnPoint = GameObject.FindWithTag("SpawnPos").transform;
    }

    public void CheckRespawn()
    {
        if(Time.time >= respawnTimeStart - respawnTime && respawn)
        {
            Debug.Log("Respawning player...");
            LoadLevel.LoadScene(iLevelToRespawn);
            SearchSpawnPoint();
            Instantiate(player, respawnPoint);
            respawn = false;
        }
    }
}
