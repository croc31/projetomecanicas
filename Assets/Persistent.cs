using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{

    public string objectTag = "Player";
    private GameObject[] objects;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        objects = GameObject.FindGameObjectsWithTag(objectTag);
        if(objects.Length > 1)
        {
            Destroy(objects[1]);
        }
    }
}
