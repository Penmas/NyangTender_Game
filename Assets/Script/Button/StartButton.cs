using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject RoadButtonUnlock;
    public GameObject RoadButtonLock;
    int ClickCount = 0;
    public Image BlackPage;
    public float FadeNum;
    public bool isFadeEnd;

    private void Start()
    {
        GameManager.GameRoad();
    }
    void Update()
    {
        Back();
        if (PlayerPrefs.HasKey("Day") && PlayerPrefs.GetInt("Day") >= 2)
        {
            GameManager.isHavePlayData = true;
        }
        else
        {
            GameManager.isHavePlayData = false;

        }

    }

    public void OnButtonStart()
    {
        StartCoroutine(_FadeSequenceSatrt());
        GameManager.isTutoOver = false;
        GameManager.isTouch = true;
      //  Debug.Log("시작");
        PlayerPrefs.SetInt("MyMoney", 30000);
        PlayerPrefs.SetInt("upgradeRecipe", 0);
        //PlayerPrefs.SetInt("upgradeTable", upgradeTable);
        PlayerPrefs.SetInt("upgradeTimer", 0);
        PlayerPrefs.SetInt("Day", 1);
        PlayerPrefs.Save();
        GameManager.GameRoad();

    }

    public void OnButtonRoad()
    {
        GameManager.GameRoad();
        StartCoroutine(_FadeSequenceRoad());
       // Debug.Log("이어하기");
        GameManager.isTouch = true;
        GameManager.isTutoOver = true;
        GameManager.bgmStart = true;


    }

    public void OnButtonQuit()
    {
      //  Debug.Log("종료");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void Back()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
            {
                Invoke("DoubleClick", 1.0f);
            }

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
    }

    public void DoubleClick()
    {
        ClickCount = 0;
    }

    IEnumerator _FadeSequenceSatrt()
    {

        while (FadeNum <= 1)
        {
           // Debug.Log(FadeNum);
            FadeNum += 0.05f;
            yield return new WaitForSeconds(0.01f);
            BlackPage.color = new Color(0, 0, 0, FadeNum);
        }
        isFadeEnd = true;
        SceneManager.LoadScene("IntroStory");
        GameManager.isIntroStart = true;
        yield return null;
    }

    IEnumerator _FadeSequenceRoad()
    {

        while(FadeNum <= 1)
        {
            Debug.Log(FadeNum);
            FadeNum += 0.05f;
            yield return new WaitForSeconds(0.01f);
            BlackPage.color = new Color(0, 0, 0, FadeNum);

            
        }
        isFadeEnd = true;
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
