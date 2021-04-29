using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{
    private string objectTag;
    private GameObject[] objects;

    void Start()
    {
        objectTag = gameObject.tag;
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (objectTag != null) {
            objects = GameObject.FindGameObjectsWithTag(objectTag);
            if (objects.Length > 1)
            {
                Destroy(objects[1]);
            }
        }
    }
}
