using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroFade : MonoBehaviour
{
    public static bool isFadeOut;
    public static bool isFadeInStart;
    public float fadeSequece;
    public Image BlackPage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_FadeOutOn());
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeInStart)
        {
            StartCoroutine(_FadeInOn());
            isFadeInStart = false;
        }
    }

    IEnumerator _FadeOutOn()
    {
        fadeSequece = 1;
        while(fadeSequece >= 0)
        {
            fadeSequece -= 0.05f;
            yield return new WaitForSeconds(0.01f);
            BlackPage.color = new Color(0, 0, 0, fadeSequece);

        }

        isFadeOut = true;
    }

    IEnumerator _FadeInOn()
    {
        while(fadeSequece <= 1)
        {
            fadeSequece += 0.05f;
            yield return new WaitForSeconds(0.01f);
            BlackPage.color = new Color(0, 0, 0, fadeSequece);
        }
        //GameManager.bgmStart = true;
        GameManager.myMoney = 30000;
        SceneManager.LoadScene("Main");
    }
}
