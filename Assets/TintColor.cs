using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color tintColor;
    private float tintFadeSpeed;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tintColor = new Color(255, 255, 255, 255);
        tintFadeSpeed = 5f;
    }

    void Update()
    {
        if(tintColor.r <= 255)
            tintColor.r = Mathf.Clamp01(tintColor.r + tintFadeSpeed * Time.deltaTime);
        
        if(tintColor.g <= 255)
            tintColor.g = Mathf.Clamp01(tintColor.g + tintFadeSpeed * Time.deltaTime);
        
        if(tintColor.b <= 255)
            tintColor.b = Mathf.Clamp01(tintColor.b + tintFadeSpeed * Time.deltaTime);

        if(tintColor.a <= 255)
            tintColor.a = Mathf.Clamp01(tintColor.a + tintFadeSpeed * Time.deltaTime);

        spriteRenderer.color = tintColor;
    }

    public void SetTintColor(Color tintColor)
    {
        this.tintColor = tintColor;
    }

    public void SetTintFadeSpeed(float tintFadeSpeed)
    {
        this.tintFadeSpeed = tintFadeSpeed;
    }


}
