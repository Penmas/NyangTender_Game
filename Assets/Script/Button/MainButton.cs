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
            //Debug.Log("������ ����");
        }
        else
        {
            Recip.sprite = RecipBookOff;
            //Debug.Log("������ �ݱ�");
        }
    }
    public void OnButtonRecipeOpen()
    {
        if(!isAniPageOpend && !PauseButton.isPauseMenuOpen)
        {
            RecipeBook.SetActive(true);
           // Debug.Log("������ �� ����");
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
            //Debug.Log("Ĭ���� ����Ŀ ����");
            isRecipeBookOpen = false ;
            isAniPageOpend = true;
            GameManager.isTouch = true;

        }
    }
}
