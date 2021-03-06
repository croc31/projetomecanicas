using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    public Animator transition;
    public int transitionTime;
    public bool useIntergerToLoad = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collisionGameObject = other.gameObject;
        if(collisionGameObject.name == "Player")
        {
            CallLoad();
        }
    }

    public void CallLoad()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        if(useIntergerToLoad)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }

    public static void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
