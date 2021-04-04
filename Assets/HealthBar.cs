using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //Modifica o valor máximo da vida
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //Atualiza a imagem da vida
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
