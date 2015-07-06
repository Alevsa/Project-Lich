using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour 
{
    private bool fadeIn, fadeOut;
    private float AlphaFadeValue = 255f;
    public float FadeTime = 0.01f;

    private Image fader;

	// Use this for initialization
	void Start () 
    {
        fadeIn = true;
        fadeOut = false;
        AlphaFadeValue = 255f;
        fader = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (fadeIn)
        {
            AlphaFadeValue = Mathf.Clamp01(AlphaFadeValue - (Time.deltaTime / FadeTime));
            fader.color = new Color(0, 0, 0, AlphaFadeValue);
        }
        
        if(fadeOut)
        {
            AlphaFadeValue = Mathf.Clamp01(AlphaFadeValue + (Time.deltaTime / FadeTime));
            fader.color = new Color(0, 0, 0, AlphaFadeValue);
        }
	}

    public void fadeOutScene()
    {
        fadeOut = true;
        fadeIn = false;
    }
}
