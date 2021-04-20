using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //inicia o jogo quando o botão de play for pressionado
    public void PlayGame()
    {
        SceneManager.LoadScene("Fase_0");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
