using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public int myOrder;
    public bool isOrder;
    private bool isBubbleOut;
    public GameObject MyBubble;
    public GameObject[] OrderBubble;
    public GameObject Great;
    public GameObject Bad;




    private bool isCockailIn;
    private int WhatCocktailIn;
    private int MyCockOrder;
    public bool Success;
    public bool NotSuccess;
    public bool isOut;
    public int MyTable;

    private int CustomerMoney;

    private int ok;
    private int bubbleOut;
    public int Order;

    public GameObject HappyEffet;
    public GameObject[] SadEffet;

    public SpriteRenderer HappySpRender;
    public SpriteRenderer SadSpRender;


    public float HappySequen;
    public int HappySequenNum;
    public float SadSequen;


    public bool isFadeStart;

    public float HappyRota;

    public bool isCatOut;

    // Start is called before the first frame update
    void Start()
    {
        ok = 0;
        bubbleOut = 0;
        MyTable = GetComponent<CustomerMoveIn>().TableNumber;
        HappySpRender.color = new Color(255, 255, 255, 0);
        //SadSpRender.color = new Color(255, 255, 255, 0);
        isFadeStart = true;

    }

    // Update is called once per frame
    void Update()
    {
       
        if(!DateManager.isDateExit)
        {
            CustomerOrderMoney();
            GetComponent<CustomerMoveIn>().isCustomerGoOut = isOut;

            if (!isBubbleOut)
            {
                Bubble();
            }


            if (isBubbleOut && ok == 0)
            {
                Invoke("BubbleFade", 1.8f);
                ok = 1;
                
               
            }

            if (Success)
            {
                if (isFadeStart)
                {
                    
                    HappySequen = HappySequen + 0.05f;
                   
                    HappyRota = 1500;

                    if(HappySequen >= 1)
                    {
                        HappyEffet.transform.Rotate(0, 0, 0);
                    }
                    else
                    {
                        HappyEffet.transform.Rotate(0, 0, HappyRota * Time.deltaTime);
                    }

                    HappySpRender.color = new Color(255, 255, 255, HappySequen);
                    StartCoroutine(_Fadeaiting());
                  //  Debug.Log("¿Ã∆Â∆Æ ∆‰¿ÃµÂ ¿€µø");
                }
            }

            if (GetComponent<CustomerMoveIn>().isCustomerSit == true && bubbleOut == 0)
            {
                CustomerOrderSelect();
                MyBubble.SetActive(true);
                bubbleOut = 1;
            }

            if (GetComponent<CustomerMoveIn>().isCustomerSit)
            {
                OrderInputCheck();
                //Debug.Log("æ…æ“¿Ω");
            }
        }
        else
        {
            BubbleFade();
        }
       

    }




    void CustomerOrderSelect()
    {
        myOrder = Random.Range(0, makeCocktail.CocktialNum + 1);
        MyCockOrder = myOrder;
        BubleOrderOut();
        GameManager.isCatorder = true;
        isOrder = true;
    }

    void CustomerOrderMoney()
    {
        switch(myOrder)
        {
            case 0:
                CustomerMoney = GameManager.PriceMiaojito;
                break;
            case 1:
                CustomerMoney = GameManager.PriceCatrose;
                break;
            case 2:
                CustomerMoney = GameManager.PriceSidecat;
                break;
            case 3:
                CustomerMoney = GameManager.PriceNyangtini;
                break;
            case 4:
                CustomerMoney = GameManager.PriceBlueRaccon;
                break;
            case 5:
                CustomerMoney = GameManager.PriceChurLibre;
                break;
        }
    }

    public void Bubble()
    {
        if(Success)
        {
            for (int i = 0; i < 6; i++)
            {
                OrderBubble[i].SetActive(false);
            }
            Great.SetActive(true);
            HappyEffet.SetActive(true);
            
            GameManager.isCatGood = true;
            isBubbleOut = true;
        }
        else if(NotSuccess)
        {
            for (int i = 0; i < 6; i++)
            {
                OrderBubble[i].SetActive(false);
            }
            Bad.SetActive(true);
            SadEffet[0].SetActive(true);
            SadEffet[1].SetActive(true);
            GameManager.isCatSad = true;
            isBubbleOut = true;
        }

    }

    public void BubbleFade()
    {
        Great.SetActive(false);
        HappyEffet.SetActive(false);
        Bad.SetActive(false);
        SadEffet[0].SetActive(false);
        SadEffet[1].SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            OrderBubble[i].SetActive(false);
        }
        MyBubble.SetActive(false);
        //Destroy(gameObject);
    }


    public void BubleOrderOut()
    {
        switch (MyCockOrder)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    OrderBubble[i].SetActive(false);
                }
                OrderBubble[0].SetActive(true);
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    OrderBubble[i].SetActive(false);
                }
                OrderBubble[1].SetActive(true);
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    OrderBubble[i].SetActive(false);
                }
                OrderBubble[2].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    OrderBubble[i].SetActive(false);
                }
                OrderBubble[3].SetActive(true);
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    OrderBubble[i].SetActive(false);
                }
                OrderBubble[4].SetActive(true);
                break;
            case 5:
                for (int i = 0; i < 4; i++)
                {
                    OrderBubble[i].SetActive(false);
                }
                OrderBubble[5].SetActive(true);
                break;
        }
    }

    public void OrderInputCheck()
    {
        if(!isOut)
        {
            switch(MyTable)
            {
                case 1:
                    if (WhatCocktailIn == MyCockOrder && CocktailDrag.isTableFirstIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        Success = true;
                        StartCoroutine(_CatWatiting());
                        //Destroy(gameObject, 2f);
                        isOut = true;
                     //   Debug.Log("º≠∫˘ º∫∞¯");

                        CocktailManager.isCocktailIn = false;
                    }
                    else if(WhatCocktailIn != MyCockOrder && CocktailDrag.isTableFirstIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        NotSuccess = true;
                        StartCoroutine(_CatWatiting());
                        //Destroy(gameObject, 2f);
                        isOut = true;
                   //     Debug.Log("º≠∫˘ Ω«∆–");
                        CocktailManager.isCocktailIn = false;
                    }
                    break;
                case 2:
                    if (WhatCocktailIn == MyCockOrder && CocktailDrag.isTableSecondIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        Success = true;
                        StartCoroutine(_CatWatiting());
                        // Destroy(gameObject, 2f);
                        isOut = true;
                    //    Debug.Log("º≠∫˘ º∫∞¯");
                        CocktailManager.isCocktailIn = false;
                    }
                    else if (WhatCocktailIn != MyCockOrder && CocktailDrag.isTableSecondIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        NotSuccess = true;
                        StartCoroutine(_CatWatiting());
                        //Destroy(gameObject, 2f);
                        isOut = true;
                     //   Debug.Log("º≠∫˘ Ω«∆–");
                        CocktailManager.isCocktailIn = false;
                    }
                    break;
                case 3:
                    if (WhatCocktailIn == MyCockOrder && CocktailDrag.isTableThirdIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        Success = true;
                        StartCoroutine(_CatWatiting());
                        // Destroy(gameObject, 2f);
                        isOut = true;
                     //   Debug.Log("º≠∫˘ º∫∞¯");
                        CocktailManager.isCocktailIn = false;
                    }
                    else if (WhatCocktailIn != MyCockOrder && CocktailDrag.isTableThirdIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        NotSuccess = true;
                        StartCoroutine(_CatWatiting());
                        // Destroy(gameObject, 2f);
                        isOut = true;
                     //   Debug.Log("º≠∫˘ Ω«∆–");
                        CocktailManager.isCocktailIn = false;
                    }
                    break;
                case 4:
                    if (WhatCocktailIn == MyCockOrder && CocktailDrag.isTableFouthIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        Success = true;
                        StartCoroutine(_CatWatiting());
                        //  Destroy(gameObject, 2f);
                        isOut = true;
                     //   Debug.Log("º≠∫˘ º∫∞¯");
                        CocktailManager.isCocktailIn = false;
                    }
                    else if (WhatCocktailIn != MyCockOrder && CocktailDrag.isTableFouthIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        NotSuccess = true;
                        StartCoroutine(_CatWatiting());
                        //  Destroy(gameObject, 2f);
                        isOut = true;
                    //    Debug.Log("º≠∫˘ Ω«∆–");
                        CocktailManager.isCocktailIn = false;
                    }
                    break;
                case 5:
                    if (WhatCocktailIn == MyCockOrder && CocktailDrag.isTableFifthIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        Success = true;
                        StartCoroutine(_CatWatiting());
                        //  Destroy(gameObject, 2f);
                        isOut = true;
                     //   Debug.Log("º≠∫˘ º∫∞¯");
                        CocktailManager.isCocktailIn = false;
                    }
                    else if (WhatCocktailIn != MyCockOrder && CocktailDrag.isTableFifthIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        NotSuccess = true;
                        StartCoroutine(_CatWatiting());
                        //  Destroy(gameObject, 2f);
                        isOut = true;
                    //    Debug.Log("º≠∫˘ Ω«∆–");
                        CocktailManager.isCocktailIn = false;
                    }
                    break;
                case 6:
                    if (WhatCocktailIn == MyCockOrder && CocktailDrag.isTableSixthIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        Success = true;
                        StartCoroutine(_CatWatiting());
                        //  Destroy(gameObject, 2f);
                        isOut = true;
                     //   Debug.Log("º≠∫˘ º∫∞¯");
                        CocktailManager.isCocktailIn = false;
                    }
                    else if (WhatCocktailIn != MyCockOrder && CocktailDrag.isTableSixthIn && isCockailIn && CocktailManager.isCocktailIn)
                    {
                        NotSuccess = true;
                        StartCoroutine(_CatWatiting());
                        //  Destroy(gameObject, 2f);
                        isOut = true;
                     //   Debug.Log("º≠∫˘ Ω«∆–");
                        CocktailManager.isCocktailIn = false;
                    }
                    break;
            }

            if(Success)
            {
                switch(Order)
                {
                    case 0:
                        DateManager.DayMiaojitoSell++;
                        break;
                    case 1:
                        DateManager.DayCatroseSell++;
                        break;
                    case 2:
                        DateManager.DaySidecatSell++;
                        break;
                    case 3:
                        DateManager.DayNyangtiniSell++;
                        break;
                    case 4:
                        DateManager.DayBuleRacconSell++;
                        break;
                    case 5:
                        DateManager.DayChurLibreSell++;
                        break;
                }
            }
        }
        
    }

    
    
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        isCockailIn = true;
        if (collider.gameObject.tag == "Miaojito")
        {
         //   Debug.Log("π¶»˜≈‰ ∞®¡ˆ");
            WhatCocktailIn = 0;
        }
        if (collider.gameObject.tag == "CatRose")
        {
         //   Debug.Log("ƒπ∑Œ¡Ó ∞®¡ˆ");
            WhatCocktailIn = 1;
        }
        if (collider.gameObject.tag == "Sidecat")
        {
         //   Debug.Log("ªÁ¿ÃµÂƒπ ∞®¡ˆ");
            WhatCocktailIn = 2;
        }
        if (collider.gameObject.tag == "Nyangtini")
        {
           // Debug.Log("≥…∆º¥œ ∞®¡ˆ");
            WhatCocktailIn = 3;
        }
        if (collider.gameObject.tag == "BlueRaccon")
        {
         //   Debug.Log("∫Ì∑Á ∂ÛƒÔ ∞®¡ˆ");
            WhatCocktailIn = 4;
        }
        if (collider.gameObject.tag == "ChurLibre")
        {
          //  Debug.Log("√Ú∏£ ∏Æ∫Í∑π ∞®¡ˆ");
            WhatCocktailIn = 5;
        }
        if(collider.gameObject.tag == "Mess")
        {
        //    Debug.Log("æ˚∏¡¡¯√¢¿Œ º˙ ∞®¡ˆ");
            WhatCocktailIn = 6;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        Invoke("CocktailCheckReset", 0.0001f);
        //Debug.Log("ƒ¨≈◊¿œ¿Ã π˛æÓ≥≤");
    }

    void CocktailCheckReset()
    {
        isCockailIn = false;     
        WhatCocktailIn = -1;                 //0 = ƒ¨≈◊¿œ ¿Œ¡ˆµ» ∞Õ¿Ã æ¯¿Ω
    }



    void CustomerOutTable()
    {
        StartCoroutine(_CatWatiting());
        if(isCatOut)
        {
           
        }
        
    }




    IEnumerator _Fadeaiting()
    {
        isFadeStart = false;
        yield return new WaitForSeconds(0.005f);
        isFadeStart = true;
        yield return null;
    }

    IEnumerator _CatWatiting()
    {
        
        yield return new WaitForSeconds(1.5f);
        switch (MyTable)
        {
            case 1:
                Location.isTable01Sit = false;
                TableManager.isTable01Select = false;
                CustomerSpawn.CustomerNum--;
                break;
            case 2:
                Location.isTable02Sit = false;
                TableManager.isTable02Select = false;
                CustomerSpawn.CustomerNum--;
                break;
            case 3:
                Location.isTable03Sit = false;
                TableManager.isTable03Select = false;
                CustomerSpawn.CustomerNum--;
                break;
            case 4:
                Location.isTable04Sit = false;
                TableManager.isTable04Select = false;
                CustomerSpawn.CustomerNum--;
                break;
            case 5:
                Location.isTable05Sit = false;
                TableManager.isTable05Select = false;
                CustomerSpawn.CustomerNum--;
                break;
            case 6:
                Location.isTable06Sit = false;
                TableManager.isTable06Select = false;
                CustomerSpawn.CustomerNum--;
                break;
        }
        yield return null;
    }
}
