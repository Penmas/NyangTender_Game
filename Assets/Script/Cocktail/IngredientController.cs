using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientController : MonoBehaviour
{

    //재료값 설정
    public int GinPrice;           //진
    public int RumPrice;           //럼
    public int SyrupPrice;         //시럽
    public int CuracaoPrice;       //큐라소

    public static int Gin_fill = 0;
    public static int Rum_fill = 0;
    public static int Syrup_fill = 0;
    public static int Curacao_fill = 0;


    public GameObject[] Fill_Gin;
    public GameObject[] Fill_Rum;
    public GameObject[] Fill_Syrup;
    public GameObject[] Fill_Curacao;

    public GameObject GameManagerObj;
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        GinPrice            = GameManager.PriceGin;
        RumPrice            = GameManager.PriceRum;
        SyrupPrice          = GameManager.PriceSyrup;
        CuracaoPrice        = GameManager.PriceCuracao;
        resetMaker();

        GameManagerObj = GameObject.FindWithTag("GameManagerObj");
        manager = GameManagerObj.GetComponent<GameManager>();
    }

    private void Update()
    {
        InputIngredient();
    }




    public void resetMaker()
    {
        Gin_fill = 0;
        Rum_fill = 0;
        Syrup_fill = 0;
        Curacao_fill = 0;
        
    }
    public void InputIngredient()
    {
        GinActive();
        RumActive();
        SyrupActive();
        CuracaoActive();
    }



    public void GinActive()
    {
        if (Gin_fill == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Fill_Gin[i].SetActive(false);
            }
        }
        else if (Gin_fill == 1)
        {
            for (int i = 0; i < Gin_fill; i++)
            {
                Fill_Gin[i].SetActive(true);
            }
        }
        else if (Gin_fill == 2)
        {
            for (int i = 0; i < Gin_fill; i++)
            {
                Fill_Gin[i].SetActive(true);
            }
        }
        else if (Gin_fill == 3)
        {
            for (int i = 0; i < Gin_fill; i++)
            {
                Fill_Gin[i].SetActive(true);
            }
        }
        else if (Gin_fill == 4)
        {
            for (int i = 0; i < Gin_fill; i++)
            {
                Fill_Gin[i].SetActive(true);
            }
        }
        else if (Gin_fill == 5)
        {
            for (int i = 0; i < Gin_fill; i++)
            {
                Fill_Gin[i].SetActive(true);
            }
        }
    }
    public void RumActive()
    {
        if (Rum_fill == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Fill_Rum[i].SetActive(false);
            }
        }
        else if (Rum_fill == 1)
        {
            for (int i = 0; i < Rum_fill; i++)
            {
                Fill_Rum[i].SetActive(true);
            }
        }
        else if (Rum_fill == 2)
        {
            for (int i = 0; i < Rum_fill; i++)
            {
                Fill_Rum[i].SetActive(true);
            }
        }
        else if (Rum_fill == 3)
        {
            for (int i = 0; i < Rum_fill; i++)
            {
                Fill_Rum[i].SetActive(true);
            }
        }
        else if (Rum_fill == 4)
        {
            for (int i = 0; i < Rum_fill; i++)
            {
                Fill_Rum[i].SetActive(true);
            }
        }
        else if (Rum_fill == 5)
        {
            for (int i = 0; i < Rum_fill; i++)
            {
                Fill_Rum[i].SetActive(true);
            }
        }
    }
    public void SyrupActive()
    {
        if (Syrup_fill == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Fill_Syrup[i].SetActive(false);
            }
        }
        else if (Syrup_fill == 1)
        {
            for (int i = 0; i < Syrup_fill; i++)
            {
                Fill_Syrup[i].SetActive(true);
            }
        }
        else if (Syrup_fill == 2)
        {
            for (int i = 0; i < Syrup_fill; i++)
            {
                Fill_Syrup[i].SetActive(true);
            }
        }
        else if (Syrup_fill == 3)
        {
            for (int i = 0; i < Syrup_fill; i++)
            {
                Fill_Syrup[i].SetActive(true);
            }
        }
        else if (Syrup_fill == 4)
        {
            for (int i = 0; i < Syrup_fill; i++)
            {
                Fill_Syrup[i].SetActive(true);
            }
        }
        else if (Syrup_fill == 5)
        {
            for (int i = 0; i < Syrup_fill; i++)
            {
                Fill_Syrup[i].SetActive(true);
            }
        }
    }
    public void CuracaoActive()
    {
        if (Curacao_fill == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Fill_Curacao[i].SetActive(false);
            }
        }
        else if (Curacao_fill == 1)
        {
            for (int i = 0; i < Curacao_fill; i++)
            {
                Fill_Curacao[i].SetActive(true);
            }
        }
        else if (Curacao_fill == 2)
        {
            for (int i = 0; i < Curacao_fill; i++)
            {
                Fill_Curacao[i].SetActive(true);
            }
        }
        else if (Curacao_fill == 3)
        {
            for (int i = 0; i < Curacao_fill; i++)
            {
                Fill_Curacao[i].SetActive(true);
            }
        }
        else if (Curacao_fill == 4)
        {
            for (int i = 0; i < Curacao_fill; i++)
            {
                Fill_Curacao[i].SetActive(true);
            }
        }
        else if (Curacao_fill == 5)
        {
            for (int i = 0; i < Curacao_fill; i++)
            {
                Fill_Curacao[i].SetActive(true);
            }
        }
    }

    //칵테일 재료 넣기 버튼
    public void GinFiles()
    {
        if(Gin_fill <= 4 && (GameManager.PriceGin <= GameManager.myMoney))
        {
            Gin_fill++;
          //  Debug.Log("진 : " + Gin_fill);
            GameManager.myMoney -= GinPrice;
            DateManager.DayGinUsed++;
            manager.SfxPlay(GameManager.sfx.AddCocktail);
        
        }
    }

    public void RumFiles()
    {
        if (Rum_fill <= 4 && (GameManager.PriceRum <= GameManager.myMoney))
        {
            Rum_fill++;
          //  Debug.Log("럼 : " + Rum_fill);
            GameManager.myMoney -= RumPrice;
            DateManager.DayRumUsed++;
            manager.SfxPlay(GameManager.sfx.AddCocktail);
        }
    }

    public void SyrupFiles()
    {
        if (Syrup_fill <= 4 && (GameManager.PriceSyrup <= GameManager.myMoney))
        {
            Syrup_fill++;
            //Debug.Log("시럽 : " + Syrup_fill);
            GameManager.myMoney -= SyrupPrice;
            DateManager.DaySyrupUsed++;
            manager.SfxPlay(GameManager.sfx.AddCocktail);
        }
    }

    public void CuracaoFiles()
    {
        if (Curacao_fill <= 4 && (GameManager.PriceCuracao <= GameManager.myMoney))
        {
            Curacao_fill++;
           // Debug.Log("큐라소 :" + Curacao_fill);
            GameManager.myMoney -= CuracaoPrice;
            DateManager.DayCuracaoUsed++;
            manager.SfxPlay(GameManager.sfx.AddCocktail);
        }
    }



}
