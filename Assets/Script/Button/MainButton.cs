using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour
{
    public GameObject RecipeBook;
    public GameObject Maker;

    public Image Recip;

    public Sprite RecipBookOn;
    public Sprite RecipBookOff;
    public static bool isRecipeBookOpen;
    public static bool isAniPageOpend;

    public void Update()
    {
        if(DateManager.isDateExit)
        {
            RecipeBook.SetActive(false);
            Maker.SetActive(false);
            isAniPageOpend = false;
            isRecipeBookOpen = false;
        }

        if(isRecipeBookOpen)
        {
            Recip.sprite = RecipBookOn;
            //Debug.Log("페이지 열기");
        }
        else
        {
            Recip.sprite = RecipBookOff;
            //Debug.Log("페이지 닫기");
        }
    }
    public void OnButtonRecipeOpen()
    {
        if(!isAniPageOpend && !PauseButton.isPauseMenuOpen)
        {
            RecipeBook.SetActive(true);
           // Debug.Log("레시피 북 열기");
            isAniPageOpend = true;
            isRecipeBookOpen = true;
            //Recip.sprite = RecipBookOn;
            GameManager.isTouch = true;
        }
    }
    public void OnButtonMakerOpen()
    {
        if (!isAniPageOpend && !PauseButton.isPauseMenuOpen)
        {
            Maker.SetActive(true);
            //Debug.Log("칵테일 메이커 열기");
            isRecipeBookOpen = false ;
            isAniPageOpend = true;
            GameManager.isTouch = true;

        }
    }
}
