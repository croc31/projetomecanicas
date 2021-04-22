using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{

    public string objectTag = "Player";
    public bool hasStartPos = true;
    public string startPosTag = "StartPos";

    private GameObject[] objects;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();

        objects = GameObject.FindGameObjectsWithTag(objectTag);
        if(objects.Length > 1)
        {
            Destroy(objects[1]);
        }
    }

    void FindStartPos()
    {
        if(hasStartPos)
        {
            transform.position = GameObject.FindWithTag(startPosTag).transform.position;
        }
    }
}
