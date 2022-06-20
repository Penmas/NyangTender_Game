using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeManager : MonoBehaviour
{

    public static int RecipeUpgradeNum;
    public static int TimeUpgradeNum;

    private int[] RecipeUpgradePrice = { 30000, 50000, 90000, 0 };
    private int[] TimeUpgradePrice = { 30000, 76000, 120000, 0};

    public Text RecipeUpgradeMoney;
    public Text timeUPgradeMoney;
    public Text NowRcipeUpgradeState;
    public Text NowTimeUpgradeState;

    public Button RecipeUpgradeButton;
    public Button TimeUpgradeButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.upgradeRecipe = RecipeUpgradeNum;
        GameManager.upgreadTimer = TimeUpgradeNum;

        if (RecipeUpgradeNum >= 3)
        {
            RecipeUpgradeMoney.text = " - ";
        }
        else
        {
            RecipeUpgradeMoney.text = RecipeUpgradePrice[RecipeUpgradeNum].ToString();
        }

        if (TimeUpgradeNum >= 3)
        {
            timeUPgradeMoney.text = " - ";
        }
        else
        {
            timeUPgradeMoney.text = TimeUpgradePrice[TimeUpgradeNum].ToString();
        }
        

        if (TimeUpgradeNum == 0)
        {
            NowTimeUpgradeState.text = "20:00 ~ 01:00";
        }
        else if(TimeUpgradeNum == 1)
        {
            NowTimeUpgradeState.text = "20:00 ~ 02:00";
        }
        else if(TimeUpgradeNum == 2)
        {
            NowTimeUpgradeState.text = "20:00 ~ 03:00";
        }
        NowRcipeUpgradeState.text = RecipeUpgradeNum.ToString() + "´Ü°è";
        
    }


    public void ButtonRecipeUpgrade()
    {
        

        if (RecipeUpgradeNum >= 3)
        {
            RecipeUpgradeButton.interactable = false;
                
        }
        else
        {
            if(RecipeUpgradePrice[RecipeUpgradeNum] <= GameManager.myMoney)
            {
                GameManager.isTouch = true;
                GameManager.myMoney = GameManager.myMoney - RecipeUpgradePrice[RecipeUpgradeNum];
                RecipeUpgradeNum++;
            }
            

        }
        

    }

    public void ButtonTimeUpgrade()
    {
        


        if (TimeUpgradeNum >= 3)
        {
            TimeUpgradeButton.interactable = false;

        }
        else
        {
            if (TimeUpgradePrice[TimeUpgradeNum] <= GameManager.myMoney)
            {
                GameManager.isTouch = true;
                GameManager.myMoney = GameManager.myMoney - TimeUpgradePrice[TimeUpgradeNum];
                TimeUpgradeNum++;
            }


        }
    }

    
}
