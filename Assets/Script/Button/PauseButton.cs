using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    int ClickCount = 0;
    public GameObject PauseMenuInter;
    public static bool isPauseMenuOpen;


    public void Update()
    {
        if(!isPauseMenuOpen)
        {
            Pause();
        }
    }
    public void Pause()
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
           // Debug.Log("일시정지");
            PauseMenuInter.SetActive(true);
            isPauseMenuOpen = true;
            CancelInvoke("DoubleClick");
            Stop();
            DoubleClick();

        }
    }

    public void DoubleClick()
    {
        ClickCount = 0;
    }


    public void OnButtonQuti()
    {
        go();
        DoubleClick();
        isPauseMenuOpen = false;
        Application.Quit();
       // Debug.Log("게임 종료");
        GameManager.isTouch = true;
        DateManager.isShopOpend = false;
        DateManager.DayRevenue = 0;
        DateManager.DayChurLibreSell = 0;
        DateManager.DayBuleRacconSell = 0;
        DateManager.DaySidecatSell = 0;
        DateManager.DayMiaojitoSell = 0;
        DateManager.DayCatroseSell = 0;
        DateManager.DayNyangtiniSell = 0;
        DateManager.DayCuracaoUsed = 0;
        DateManager.DaySyrupUsed = 0;
        DateManager.DayRumUsed = 0;
        DateManager.DayGinUsed = 0;
    }


    public void OnButtonMainBack()
    {
        go();
        DoubleClick();
        isPauseMenuOpen = false;
        SceneManager.LoadScene("Start");
      //  Debug.Log("메인화면으로 돌아가기");
        DateManager.isShopOpend = false;
        GameManager.isTouch = true;
        DateManager.DayRevenue = 0;
        DateManager.DayChurLibreSell = 0;
        DateManager.DayBuleRacconSell = 0;
        DateManager.DaySidecatSell = 0;
        DateManager.DayMiaojitoSell = 0;
        DateManager.DayCatroseSell = 0;
        DateManager.DayNyangtiniSell = 0;
        DateManager.DayCuracaoUsed = 0;
        DateManager.DaySyrupUsed = 0;
        DateManager.DayRumUsed = 0;
        DateManager.DayGinUsed = 0;
    }

    public void OnButtonClose()
    {
        GameManager.isTouch = true;

      //  Debug.Log("일시정지 해제");
        go();
        DoubleClick();
        isPauseMenuOpen = false;
        PauseMenuInter.SetActive(false);
    }


    public void Stop()
    {
        Time.timeScale = 0f;
    }

    public void go()
    {
        Time.timeScale = 1f;
    }
}
