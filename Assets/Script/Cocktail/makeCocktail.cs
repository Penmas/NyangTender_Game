

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeCocktail : MonoBehaviour
{
    // Start is called before the first frame update

    //���� ���� ����
    public int[] MyCocktail = new int[5]; //��� 1~4, ����ŷ(1) or ����(2)

    //Ĭ���� ���� ����
    public static int CocktialNum;

    public static int CocktailIngredient = 4;

    //������ ���        ��, ��, �÷�, ť���
    private int[] Miaojito              = { 0, 3, 1, 0, 2 };        //������
    private int[] CatRose               = { 1, 0, 2, 2, 1 };        //Ĺ����
    private int[] Sidecat               = { 1, 0, 2, 3, 2 };        //���̵�Ĺ
    private int[] Nyangtini             = { 4, 3, 0, 0, 2 };        //��Ƽ��
    private int[] BlueRaccoon           = { 0, 2, 2, 4, 1 };        //������
    private int[] ChurLibre             = { 0, 5, 2, 1, 2 };        //�� ���극

    //������ ��ġ Ȯ��
    //Ĭ���� ���� �� 6���̸� ������� ������, Ĺ����, ���̵�Ĺ, ��Ƽ��, ������, �� ���극
    private  int[] MyRecipeCheck = { 0, 0, 0, 0, 0, 0 };
    private int isCocktailMake = 0;
    public static bool[] WhatCocktail = { false, false, false, false, false, false };

    public static bool isMess;

    //Ĭ���� �ϼ� ���������� �����ֱ�
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
           // Debug.Log("�ϼ�Ȯ�� ����");
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
      //  Debug.Log("������ Ȯ��" + " " + MyRecipeCheck[0]);

        for (int i = 0; i < 5; i++)
        {
            if (CatRose[i] == MyCocktail[i])
            {
                MyRecipeCheck[1]++;
            }
        }
      //  Debug.Log("Ĺ���� Ȯ��" + " " + MyRecipeCheck[1]);

        for (int i = 0; i < 5; i++)
        {
            if (Sidecat[i] == MyCocktail[i])
            {
                MyRecipeCheck[2]++;
            }
        }
     //   Debug.Log("���̵�Ĺ Ȯ��" + " " + MyRecipeCheck[2]);

        if(CocktialNum >= 3)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Nyangtini[i] == MyCocktail[i])
                {
                    MyRecipeCheck[3]++;
                }
            }
        //    Debug.Log("��Ƽ�� Ȯ��" + " " + MyRecipeCheck[3]);

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
       //     Debug.Log("������ Ȯ��" + " " + MyRecipeCheck[4]);
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
           // Debug.Log("�� ���극 Ȯ��" + " " + MyRecipeCheck[5]);
        }
        







        //Debug.Log("������ üũ");
    }

    public void CocktailKind()
    {

        for (int i = 0; i < CocktialNum + 1; i++)
        {
            if (MyRecipeCheck[i] == (CocktailIngredient + 1))
            {
                //Debug.Log(i + 1 + "���� �ϼ�");
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
            //Debug.Log("������â�� �� �ϼ�");
            isMess = true;
            isMessPageSee = true;
            CocktailSpawn.CocktailComplete = true;
            isCocktailMake = 0;
        }
        else
        {
           // Debug.Log("�� ����� �ϼ� ��");
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

      //  Debug.Log("������ üũ �ʱ�ȭ");
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
           // Debug.Log("Ĭ���� ���۵� �� ���̰� �ϱ�");
            for (int i = 0; i < 6; i++)
            {
                if (WhatCocktail[i] == true)
                {
                    CocktailSee[i].SetActive(true);
                    //Debug.Log("Ĭ���� ���̱� : " + i);
                }

                
            }
            if (isMessPageSee == true)
            {
                CocktailSee[6].SetActive(true);
             //   Debug.Log("������â�� �� ������");
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
      //  Debug.Log("����Ŀ ������ �ݱ�");
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
       // Debug.Log("����Ŀ �����");
        yield return null;
    }

    IEnumerator _WaitingTimeCockailOut()
    {
        
        yield return new WaitForSeconds(2f);
       // Debug.Log("����Ŀ ������ �����");
        FadePage = true;
        
    }
}
