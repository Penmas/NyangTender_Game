using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePage : MonoBehaviour
{
    public GameObject RecipTotal;
    public GameObject RecipeBook;
    public GameObject[] Recipe;
    public GameObject[] RecipeLock;
    public GameObject[] RecipeButton;
    public GameObject ButtonLeft;
    public GameObject ButtonRight;

    public int PageLeaf;
    public bool isPageOpen;

    public void Start()
    {
        PageLeaf = 0;
    }

    public void Update()
    {
        if(isPageOpen)
        {
            PageLeafManager();
        }
        RecipeLockManager();


    }
    // Start is called before the first frame update
    public void OnButtonMiaojito()
    {
        if(!isPageOpen)
        {
           // Debug.Log("묘히토 레시피 보기");
            for (int i = 0; i < 6; i++)
            {
                Recipe[i].SetActive(false);
            }
            RecipTotal.SetActive(true);
            Recipe[0].SetActive(true);
            isPageOpen = true;
            GameManager.isRecipePage = true;


        }
        PageLeaf = 0;
    }

    public void OnButtonCatrose()
    {
        if (!isPageOpen)
        {
            //Debug.Log("캣로즈 레시피 보기");
            for (int i = 0; i < 6; i++)
            {
                Recipe[i].SetActive(false);
            }
            RecipTotal.SetActive(true);
            Recipe[1].SetActive(true);
            isPageOpen = true;
            GameManager.isRecipePage = true;


        }
        PageLeaf = 1;
    }

    public void OnButtonSidecat()
    {
        if (!isPageOpen)
        {
           // Debug.Log("사이드캣 레시피 보기");
            for (int i = 0; i < 6; i++)
            {
                Recipe[i].SetActive(false);
            }
            RecipTotal.SetActive(true);
            Recipe[2].SetActive(true);
            isPageOpen = true;
            GameManager.isRecipePage = true;


        }
        PageLeaf = 2;
    }

    public void OnButtonNyangtini()
    {
        if (!isPageOpen)
        {
        //    Debug.Log("냥티니 레시피 보기");
            for (int i = 0; i < 6; i++)
            {
                Recipe[i].SetActive(false);
            }
            RecipTotal.SetActive(true);
            Recipe[3].SetActive(true);
            isPageOpen = true;
            GameManager.isRecipePage = true;


        }
        PageLeaf = 3;
    }

    public void OnButtonBlueRaccoon()
    {
        if (!isPageOpen)
        {
       //     Debug.Log("블루라쿤 레시피 보기");
            for (int i = 0; i < 6; i++)
            {
                Recipe[i].SetActive(false);
            }
            RecipTotal.SetActive(true);
            Recipe[4].SetActive(true);
            isPageOpen = true;
            GameManager.isRecipePage = true;


        }
        PageLeaf = 4;
    }

    public void OnButtonChruLibre()
    {
        if (!isPageOpen)
        {
        //    Debug.Log("츄르리브레 레시피 보기");
            for (int i = 0; i < 6; i++)
            {
                Recipe[i].SetActive(false);
            }
            RecipTotal.SetActive(true);
            Recipe[5].SetActive(true);
            isPageOpen = true;
            GameManager.isRecipePage = true;


        }
        PageLeaf = 5;
    }

    public void OnButtonPageClose()
    {
        MainButton.isRecipeBookOpen = false;
        MainButton.isAniPageOpend = false;
        isPageOpen = false;        
        RecipTotal.SetActive(false);
        RecipeBook.SetActive(false);
        GameManager.isTouch = true;


    }


    public void PageLeafManager()
    {

        switch(PageLeaf)
        {
            case 0:
                for (int i = 0; i < 6; i++)
                {
                    Recipe[i].SetActive(false);
                }
                RecipTotal.SetActive(true);
                Recipe[0].SetActive(true);
                break;
            case 1:
                for (int i = 0; i < 6; i++)
                {
                    Recipe[i].SetActive(false);
                }
                RecipTotal.SetActive(true);
                Recipe[1].SetActive(true);
                break;
            case 2:
                for (int i = 0; i < 6; i++)
                {
                    Recipe[i].SetActive(false);
                }
                RecipTotal.SetActive(true);
                Recipe[2].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < 6; i++)
                {
                    Recipe[i].SetActive(false);
                }
                RecipTotal.SetActive(true);
                Recipe[3].SetActive(true);
                break;
            case 4:
                for (int i = 0; i < 6; i++)
                {
                    Recipe[i].SetActive(false);
                }
                RecipTotal.SetActive(true);
                Recipe[4].SetActive(true);
                break;
            case 5:
                for (int i = 0; i < 6; i++)
                {
                    Recipe[i].SetActive(false);
                }
                RecipTotal.SetActive(true);
                Recipe[5].SetActive(true);
                break;
        }

        if (PageLeaf == 0)
        {
            ButtonLeft.SetActive(false);
        }
        else
        {
            ButtonLeft.SetActive(true);
        }

        if(PageLeaf >= (makeCocktail.CocktialNum))
        {
            ButtonRight.SetActive(false);
        }
        else
        {
            ButtonRight.SetActive(true);
        }
    }


    public void OnButtonPageLeafPlus()
    {
        PageLeaf++;
        GameManager.isRecipePage = true;


    }

    public void OnButtonPageLeafM()
    {

        PageLeaf--;
        GameManager.isRecipePage = true;


    }


    void RecipeLockManager()
    {
        if(GameManager.upgradeRecipe == 0)
        {
            RecipeButton[0].SetActive(false);
            RecipeButton[1].SetActive(false);
            RecipeButton[2].SetActive(false);

            RecipeLock[0].SetActive(true);
            RecipeLock[1].SetActive(true);
            RecipeLock[2].SetActive(true);
        }
        else if(GameManager.upgradeRecipe == 1)
        {
            RecipeButton[0].SetActive(true);
            RecipeButton[1].SetActive(false);
            RecipeButton[2].SetActive(false);

            RecipeLock[0].SetActive(false);
            RecipeLock[1].SetActive(true);
            RecipeLock[2].SetActive(true);
        }
        else if(GameManager.upgradeRecipe == 2)
        {
            RecipeButton[0].SetActive(true);
            RecipeButton[1].SetActive(true);
            RecipeButton[2].SetActive(false);

            RecipeLock[0].SetActive(false);
            RecipeLock[1].SetActive(false);
            RecipeLock[2].SetActive(true);
        }
        else if(GameManager.upgradeRecipe >= 3)
        {
            RecipeButton[0].SetActive(true);
            RecipeButton[1].SetActive(true);
            RecipeButton[2].SetActive(true);

            RecipeLock[0].SetActive(false);
            RecipeLock[1].SetActive(false);
            RecipeLock[2].SetActive(false);
        }
    }
}
