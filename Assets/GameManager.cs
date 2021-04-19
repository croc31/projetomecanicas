using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject player;
    public float respawnTime;
    private CinemachineVirtualCamera camera;

    private float respawnTimeStart;
    private bool respawn;

    public void Start()
    {
        camera = GameObject.Find("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
    }

    public void Update()
    {
        CheckRespawn();
    }

    public void Respawn()
    {
        Debug.Log("Respaw call.");
        respawnTimeStart = Time.time;
        respawn = true;
    }

    public void CheckRespawn()
    {
        if(Time.time >= respawnTimeStart - respawnTime && respawn)
        {
            Debug.Log("Respawning player...");
            var playerTemp = Instantiate(player, respawnPoint);
            camera.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }
}
