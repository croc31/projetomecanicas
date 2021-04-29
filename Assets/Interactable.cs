using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    private bool hasInvoke;
    public bool noKeyNeed;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public SpriteRenderer rederer;
     
    private void Update()
    {
        if (!hasInvoke && isInRange && (Input.GetKeyDown(interactKey) || noKeyNeed))
        {
            interactAction.Invoke();
            hasInvoke = true;
        }
        else if(hasInvoke && (!isInRange || Input.GetKeyDown(interactKey)))
        {
            interactAction.Invoke();
            hasInvoke = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }

    }
}
