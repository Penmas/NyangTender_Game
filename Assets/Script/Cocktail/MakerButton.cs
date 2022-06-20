using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakerButton : MonoBehaviour
{
    //´Ý±â ¹öÆ°
    public GameObject Close;
    public static int MyAction;
    public static int CheckStart = 0;
    public static bool isMakeClick = false;

    public Button[] makeButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DateManager.isDateExit)
        {
            Close.SetActive(false);
        }
    }


    public void OnButtonSharking()
    {
        if(!isMakeClick)
        {
         //   Debug.Log("¼ÎÀÌÅ·");
            MyAction = 1;
            makeButtonClose();
            GameManager.isTouch = true;

        }

    }



    public void OnButtonStir()
    {
        if (!isMakeClick)
        {
          //  Debug.Log(" Á£±â");
            MyAction = 2;
            makeButtonClose();
            GameManager.isTouch = true;

        }

    }


    public void OnButtonComplete()
    {
        if(!CocktailSpawn.isCoktailOut)
        {
            CheckStart = 1;
            Invoke("resetIngredient", 1f);
          //  Debug.Log("¿Ï¼º");
            Close.SetActive(false);
            MainButton.isAniPageOpend = false;
            makeButtonOpen();
            GameManager.isTouch = true;
        }
        

    }

    public void OnButtonDesert()
    {
      //  Debug.Log("¹ö¸®±â");
        resetIngredient();
        makeButtonOpen();
        GameManager.isTouch = true;

    }

    public void OnButtonMakerClose()
    {
        Close.SetActive(false);
        MainButton.isAniPageOpend = false;
        GameManager.isTouch = true;

    }

    public void resetIngredient()
    {
        IngredientController.Gin_fill = 0;
        IngredientController.Rum_fill = 0;
        IngredientController.Syrup_fill = 0;
        IngredientController.Curacao_fill = 0;
        MyAction = 0;
        isMakeClick = false;
    }

    public void makeButtonClose()
    {
        makeButton[0].interactable = false;
        makeButton[1].interactable = false;
        makeButton[2].interactable = false;
        makeButton[3].interactable = false;
        makeButton[4].interactable = false;
        makeButton[5].interactable = false;
    }

    public void makeButtonOpen()
    {
        makeButton[0].interactable = true;
        makeButton[1].interactable = true;
        makeButton[2].interactable = true;
        makeButton[3].interactable = true;
        makeButton[4].interactable = true;
        makeButton[5].interactable = true;
    }

}
