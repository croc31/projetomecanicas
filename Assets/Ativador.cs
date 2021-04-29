using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativador : MonoBehaviour
{
    public GameObject objeto;
    public KeyCode key;

    private void Start()
    {
        objeto.SetActive(true);
        objeto.SetActive(false);
    }
    void Update()
    {
        if (key.ToString() != "None")
        {
            if (Input.GetKeyDown(key))
            {
                ChangeState();
            }
        }
    }

    public void ChangeState()
    {
        if (objeto.activeSelf)
        {
            objeto.SetActive(false);
        }
        else
        {
            objeto.SetActive(true);
        }
    }
}
