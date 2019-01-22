using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenFade : MonoBehaviour {

    public Image splashImage;
    public Text introText;
    public string levelToLoad;

	// Use this for initialization
	IEnumerator Start () {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        introText.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(levelToLoad);

	}
	
    void FadeIn()
    {
        introText.CrossFadeAlpha(1.0f, 1.5f, false);
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        introText.CrossFadeAlpha(0.0f, 2.5f, false);
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
        
    }
}
