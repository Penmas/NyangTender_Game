using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonRestart()
    {
        CustomerSpawn.CustomerNum = 0;
        
        GameManager.isTouch = true;
        IngredientController.Gin_fill = 0;
        IngredientController.Rum_fill = 0;
        IngredientController.Syrup_fill = 0;
        IngredientController.Curacao_fill = 0;
        MakerButton.MyAction = 0;

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


        DateText.Mytimer = 0;
        DateText.isTextOut = false;

        GameManager.bgmStart = true;
        GameManager.GameReset();
        GameManager.GameRoad();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnButtonMain()
    {
        CustomerSpawn.CustomerNum = 0;

        GameManager.isTouch = true;
        IngredientController.Gin_fill = 0;
        IngredientController.Rum_fill = 0;
        IngredientController.Syrup_fill = 0;
        IngredientController.Curacao_fill = 0;
        MakerButton.MyAction = 0;

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


        DateText.Mytimer = 0;
        DateText.isTextOut = false;

        GameManager.bgmStart = true;
        GameManager.GameReset();
        GameManager.GameRoad();
        SceneManager.LoadScene("Start");
    }
}
