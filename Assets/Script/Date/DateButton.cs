using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateButton : MonoBehaviour
{

    public GameObject UpgradePage;
    public GameObject myPage;
    // Start is called before the first frame update
    public void NextDayButton()
    {
        GameManager.isTouch = true;

        GameManager.GameSave();
        IngredientController.Gin_fill = 0;
        IngredientController.Rum_fill = 0;
        IngredientController.Syrup_fill = 0;
        IngredientController.Curacao_fill = 0;
        MakerButton.MyAction = 0;

        DateManager.isShopClose = false;
        DateManager.isNextDayStart = true;

        DateManager.DayBuleRacconSell = 0;
        DateManager.DayCatroseSell = 0;
        DateManager.DayChurLibreSell = 0;
        DateManager.DayMiaojitoSell = 0;
        DateManager.DayNyangtiniSell = 0;
        DateManager.DaySidecatSell = 0;


        DateManager.DayGinUsed = 0;
        DateManager.DayCuracaoUsed = 0;
        DateManager.DayRumUsed = 0;

        DateManager.DaySyrupUsed = 0;

        DateManager.DayRevenue = 0;

        DateManager.DayTotal = 0;


        GameManager.MyDay++;

        DateText.Mytimer = 0;
        myPage.SetActive(false);
        UpgradePage.SetActive(false);
        DateText.isTextOut = false;

        CustomerSpawn.CustomerNum = 0;
        GameManager.bgmStart = true;
        DateText.isTextOutOver = false;
        GameManager.GameSave();
    }

    public void UpgradeButton()
    {
        GameManager.isTouch = true;

        UpgradePage.SetActive(true);
        myPage.SetActive(false);
    }
}
