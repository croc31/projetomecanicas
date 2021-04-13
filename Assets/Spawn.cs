using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject entity;
    public int height = 10;
    public int width = 10;
    public int maxEntities = 5;
    public bool activated = true;
    public float delay = 5.0f;

    public bool alwaysShowGizmos = false;

    private List<GameObject> entities;
    private float xPos, yPos;
    private Transform anchor;

    // Start is called before the first frame update
    void Start()
    {
        entities = new List<GameObject>();
        anchor = GetComponent<Transform>();
        StartCoroutine(DropEnemy());
    }

    IEnumerator DropEnemy()
    {
        while(true)
        {
            CheckDestroyed();
            if(activated && entities.Count < maxEntities)
            {
                xPos = Random.Range(anchor.position.x - (width / 2), anchor.position.x + (width / 2));
                yPos = Random.Range(anchor.position.y - (height / 2), anchor.position.y + (height / 2));
                entities.Add(Instantiate(entity, new Vector3(xPos, yPos, 0.0f), Quaternion.identity));
                entities[entities.Count - 1].SetActive(true);
            }
            yield return new WaitForSeconds(delay);
        }
    }

    void CheckDestroyed()
    {
        for(var i = entities.Count - 1; i >= 0; --i)
        {
            if (entities[i] == null)
                entities.RemoveAt(i);
        }
    }

    void OnDrawGizmos()
    {
        if(!alwaysShowGizmos)
            return;
        if(anchor == null)
            return;

        Gizmos.DrawWireCube(anchor.position, new Vector3(width, height, 0));
    }

    void OnDrawGizmosSelected()
    {
        if(anchor == null)
            return;

        Gizmos.DrawWireCube(anchor.position, new Vector3(width, height, 0));
    }

}
