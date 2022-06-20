

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeCocktail : MonoBehaviour
{
    // Start is called before the first frame update

    //내가 넣은 재료들
    public int[] MyCocktail = new int[5]; //재료 1~4, 셰이킹(1) or 젓기(2)

    //칵테일 현재 개수
    public static int CocktialNum;

    public static int CocktailIngredient = 4;

    //레시피 재료        진, 럼, 시럽, 큐라소
    private int[] Miaojito              = { 0, 3, 1, 0, 2 };        //묘히토
    private int[] CatRose               = { 1, 0, 2, 2, 1 };        //캣로즈
    private int[] Sidecat               = { 1, 0, 2, 3, 2 };        //사이드캣
    private int[] Nyangtini             = { 4, 3, 0, 0, 2 };        //냥티니
    private int[] BlueRaccoon           = { 0, 2, 2, 4, 1 };        //블루라쿤
    private int[] ChurLibre             = { 0, 5, 2, 1, 2 };        //츄르 리브레

    //레시피 일치 확인
    //칵테일 종류 는 6개이며 순서대로 묘히토, 캣로즈, 사이드캣, 냥티니, 블루라쿤, 츄르 리브레
    private  int[] MyRecipeCheck = { 0, 0, 0, 0, 0, 0 };
    private int isCocktailMake = 0;
    public static bool[] WhatCocktail = { false, false, false, false, false, false };

    public static bool isMess;

    //칵테일 완성 가시적으로 보여주기
    public GameObject AnimPage;
    public GameObject Anim;
    public GameObject[] CocktailSee;

    private bool isStartAnim;
    private bool isSeeCocktail;
    private bool isAnimStart;
    private bool isCloseSeeCocktail;
    private bool isMessPageSee;
    public static bool CocktailSpwanStart;
    private bool FadePage;
    // Update is called once per frame
    void Update()
    {
        MakeCocktail();
        if (MakerButton.CheckStart == 1)
        {
           // Debug.Log("완성확인 실행");
            isAnimStart = true;
            MyCocktailCheck();
            CocktailKind();
            MakerButton.CheckStart = 0;
            Invoke("CocktailCheckReset", 5f);
            
        }

        if(isAnimStart)
        {
            AnimStart();            
            
        }
        CocktialNum = 2 + GameManager.upgradeRecipe;
    }

    public void MakeCocktail()
    {
        MyCocktail[0] = IngredientController.Gin_fill;
        MyCocktail[1] = IngredientController.Rum_fill;
        MyCocktail[2] = IngredientController.Syrup_fill;
        MyCocktail[3] = IngredientController.Curacao_fill;
        MyCocktail[4] = MakerButton.MyAction;
    }

    public void MyCocktailCheck()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Miaojito[i] == MyCocktail[i])
            {
                MyRecipeCheck[0]++;
            }
        }
      //  Debug.Log("묘히토 확인" + " " + MyRecipeCheck[0]);

        for (int i = 0; i < 5; i++)
        {
            if (CatRose[i] == MyCocktail[i])
            {
                MyRecipeCheck[1]++;
            }
        }
      //  Debug.Log("캣로즈 확인" + " " + MyRecipeCheck[1]);

        for (int i = 0; i < 5; i++)
        {
            if (Sidecat[i] == MyCocktail[i])
            {
                MyRecipeCheck[2]++;
            }
        }
     //   Debug.Log("사이드캣 확인" + " " + MyRecipeCheck[2]);

        if(CocktialNum >= 3)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Nyangtini[i] == MyCocktail[i])
                {
                    MyRecipeCheck[3]++;
                }
            }
        //    Debug.Log("냥티니 확인" + " " + MyRecipeCheck[3]);

        }

        if(CocktialNum >= 4)
        {
            for (int i = 0; i < 5; i++)
            {
                if (BlueRaccoon[i] == MyCocktail[i])
                {
                    MyRecipeCheck[4]++;
                }
            }
       //     Debug.Log("블루라쿤 확인" + " " + MyRecipeCheck[4]);
        }
        
        if(CocktialNum >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                if (ChurLibre[i] == MyCocktail[i])
                {
                    MyRecipeCheck[5]++;
                }
            }
           // Debug.Log("츄르 리브레 확인" + " " + MyRecipeCheck[5]);
        }
        







        //Debug.Log("레시피 체크");
    }

    public void CocktailKind()
    {

        for (int i = 0; i < CocktialNum + 1; i++)
        {
            if (MyRecipeCheck[i] == (CocktailIngredient + 1))
            {
                //Debug.Log(i + 1 + "번술 완성");
                WhatCocktail[i] = true;
                CocktailManager.MyCocktailNum = i;
            }
        }

        for (int i = 0; i < CocktialNum + 1; i++)
        {
            if (WhatCocktail[i] == true)
            {
                isCocktailMake++;
            }
        }

        if (isCocktailMake == 0)
        {
            //Debug.Log("엉망진창인 술 완성");
            isMess = true;
            isMessPageSee = true;
            CocktailSpawn.CocktailComplete = true;
            isCocktailMake = 0;
        }
        else
        {
           // Debug.Log("술 제대로 완성 됨");
            CocktailSpawn.CocktailComplete = true;
            isCocktailMake = 0;
            Invoke("CocktailFindReset", 4f);
        }

    }


    public void CocktailCheckReset()
    {
        for (int i = 0; i < 6; i++)
        {
            MyRecipeCheck[i] = 0;

        }

      //  Debug.Log("레시피 체크 초기화");
    }

    public void CocktailFindReset()
    {
        for (int i = 0; i < 6; i++)
        {
            WhatCocktail[i] = false;
        }
        isMess = false;

    }

    public void AnimStart()
    {
        
        if(!isStartAnim)
        {
            AnimPage.SetActive(true);
            Anim.SetActive(true);
            isStartAnim = true;
            StartCoroutine(_WaitingTime());
            
        }
        
                    
                
            
        

        if(isSeeCocktail)
        {
           // Debug.Log("칵테일 제작된 것 보이게 하기");
            for (int i = 0; i < 6; i++)
            {
                if (WhatCocktail[i] == true)
                {
                    CocktailSee[i].SetActive(true);
                    //Debug.Log("칵테일 보이기 : " + i);
                }

                
            }
            if (isMessPageSee == true)
            {
                CocktailSee[6].SetActive(true);
             //   Debug.Log("엉망진창인 술 보여줌");
            }

            StartCoroutine(_WaitingTimeCockailOut());
            isSeeCocktail = false;


        }

        if (FadePage)
        {

            for (int i = 0; i < 7; i++)
            {
                CocktailSee[i].SetActive(false);
            }

            FadeReset();
            FadePage = false;
        }
    }


    void FadeReset()
    {
      //  Debug.Log("셰이커 페이지 닫기");
        AnimPage.SetActive(false);
        isAnimStart = false;
        CocktailSpwanStart = true;
        isMessPageSee = false;
        isSeeCocktail = false;
        FadePage = false;
        isStartAnim = false;



    }
    IEnumerator _WaitingTime()
    {
        yield return new WaitForSeconds(2f);
        Anim.SetActive(false);
        isSeeCocktail = true;
       // Debug.Log("셰이커 사라짐");
        yield return null;
    }

    IEnumerator _WaitingTimeCockailOut()
    {
        
        yield return new WaitForSeconds(2f);
       // Debug.Log("셰이커 페이지 사라짐");
        FadePage = true;
        
    }
}
