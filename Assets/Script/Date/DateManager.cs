using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DateManager : MonoBehaviour
{
    public static float MyTime;                    //현재 흐른 시간
    public static float DateExitTime;          //일차가 종료되는 시간(업그레이드 적용)
    public static float BaseTime =300f;             //업그레이드가 적용되지 않은 원래 기본 시간
    public int SalesSettlement;
    public static int DebtDay;
    public int UsedIngredientPrice;
    private int startMoney;

    public static bool isShopClose;     //정리
    public static bool isDateExit;      //시간 종료
    public static bool isShopOpend = true;     //가게 오픈
    public static bool isNextDayStart;  //다음날 시작
    public static bool isTextComeOutOver; //텍스트 나오기
    public float TextComeTime;
    private bool isThisTimeGameOver;

    public GameObject GameoverPaLel;
    public GameObject Shutter;
    public static bool ShutterDown;
    public bool ShutterUp;
    public GameObject shutterTarget;
    public GameObject ShutterUpTarget;

    public GameObject SalesSettlementPage;
    public Text DayDisplay;
    public Text TodayMyMoneyText;
    public Text TodayRevenue;
    public Text DayUsedIngredient;
    public Text Debt;
    public Text TodaySalesSettlement;

    public GameObject ThisDay;
    public Text ThisDayNum;
    public Text MyDebtDDay;
    

    //게임 오버씬 보이기 페이드
    public static bool isGameOverFadeOut;
    public static bool isGameOverFadeInStart;
    public float fadeSequece;
    public Image BlackPage;



    //합산
    public static int DayTotal;

    //사용된 재료
    public static int DayGinUsed;
    public static int DayRumUsed;
    public static int DaySyrupUsed;
    public static int DayCuracaoUsed;

    //판매된 칵테일
    public static int DayNyangtiniSell;
    public static int DayMiaojitoSell;
    public static int DayCatroseSell;
    public static int DaySidecatSell;
    public static int DayBuleRacconSell;
    public static int DayChurLibreSell;
    public static int DayRevenue;              //오늘 이익

    //보스관련
    public static bool isBossOutDay;
    public static bool isBossUpset;
    public static bool isBossHappy;

    //딜레이
    public float ShutterTime = 0f;
    public float myTime;
    // Start is called before the first frame update

    public static int i;
    public static bool StartBgm;
    void Start()
    {
        //DateExitTime = BaseTime * GameManager.upgreadTimer;
        Debug.Log(startMoney);
        startMoney = GameManager.myMoney;
        Debug.Log(startMoney);
        Shutter.transform.position = ShutterUpTarget.transform.position;
        MyTime = 0f;
        isShopOpend = true;
        isThisTimeGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        DebtDay = 7 - (GameManager.MyDay % 7);

        DateExitTime = BaseTime + (60 * GameManager.upgreadTimer);
        if (isShopOpend && GameManager.isTutoOver)
        {
            MyTime += Time.deltaTime;           //시간 측정
            
        }
        
        UsedIngredientPrice = 
            (DayCuracaoUsed * GameManager.PriceCuracao) + 
            (DayGinUsed * GameManager.PriceGin) + 
            (DayRumUsed * GameManager.PriceRum) + 
            (DaySyrupUsed * GameManager.PriceSyrup);

        DayRevenue =
            (DayMiaojitoSell * GameManager.PriceMiaojito) +
            (DayCatroseSell * GameManager.PriceCatrose) +
            (DaySidecatSell * GameManager.PriceSidecat) +
            (DayNyangtiniSell * GameManager.PriceNyangtini) +
            (DayBuleRacconSell * GameManager.PriceBlueRaccon) +
            (DayChurLibreSell * GameManager.PriceChurLibre);
        if(DebtDay == 7)
        {
            SalesSettlement = startMoney + DayRevenue - UsedIngredientPrice - GameManager.DedtMoney;
            isBossOutDay = true;
        }
        else
        {
            SalesSettlement = startMoney + DayRevenue - UsedIngredientPrice;
            isBossOutDay = false;

        }

        if (MyTime >= DateExitTime)
        {

            isShopOpend = false;
            //ShutterTime += Time.deltaTime;
            //Debug.Log(ShutterTime);
            DateExit();


        }

        
        
        if(isDateExit && CustomerSpawn.CustomerGroundOutNum <= 0)
        {
            if (SalesSettlement > 0 )
            {
                isBossHappy = true;
                isBossUpset = false;
                isThisTimeGameOver = false;
                Debug.Log(GameManager.myMoney);
            }
            else
            {
                Debug.Log("파산 함");
                Debug.Log(GameManager.myMoney);
                isGameOverFadeInStart = true;
                isBossUpset = true;
                isBossHappy = false;
                isThisTimeGameOver = true;
            }

            if (!StartBgm)
            {
                GameManager.isShutterMove = true;
                StartBgm = true;
            }
            //Debug.Log("셔터 내려가기");
            Vector2 vel = Vector2.zero;
            Shutter.transform.position = Vector2.MoveTowards(Shutter.transform.position, shutterTarget.transform.position, 2f *Time.deltaTime);
            if(Shutter.transform.position.y == 0)
            {
               // Debug.Log("셔터 다 내려옴");
                ShutterDown = true;
                isDateExit = false;
                StartBgm = false;
                MyTime = 0;
            }
            
        }
        if(isBossOutDay && ShutterDown)
        {
            if (ShutterDown && BossStory.isBossTextAllOut && !isThisTimeGameOver)
            {
                Invoke("ShutterManager", 0.7f);
                DateText.isTextOut = true;
                GameManager.myMoney = SalesSettlement;
                ShutterDown = false;

            }

            if(isThisTimeGameOver && BossStory.isBossTextAllOut)
            {
                if (isGameOverFadeInStart)
                {
                    StartCoroutine(_FadeInOn());
                    isGameOverFadeInStart = false;
                }

                if (isGameOverFadeOut)
                {
                    StartCoroutine(_FadeOutOn());
                    isGameOverFadeOut = false;
                }
                
                GameManager.GameReset();
               // Debug.Log("파산을 함");
            }
        }
        else
        {
            if (ShutterDown)
            {
                Invoke("ShutterManager", 0.7f);
                DateText.isTextOut = true;
                GameManager.myMoney = SalesSettlement;
                ShutterDown = false;
                
                GameManager.GameSave();
            }
        }
        

        if(isNextDayStart && !isTextComeOutOver)
        {
            ThisDay.SetActive(true);
            
            if(DebtDay == 7)
            {
                ThisDayNum.text = GameManager.MyDay.ToString() + " 일차";
                MyDebtDDay.text = "빚 갚는 날 까지 D-Day";
                
            }
            else
            {
                ThisDayNum.text = GameManager.MyDay.ToString() + " 일차";
                MyDebtDDay.text = "빚 갚는 날 까지 D-" + DebtDay.ToString();
            }
            
            TextComeTime += Time.deltaTime;
            if(TextComeTime >= 1.5f)
            {
                isTextComeOutOver = true;
                GameManager.isShutterMove = true;
                ThisDay.SetActive(false);
            }
            
        }

        if(isNextDayStart && isTextComeOutOver)
        {

            startMoney = GameManager.myMoney;
            Shutter.transform.position = Vector2.MoveTowards(Shutter.transform.position, ShutterUpTarget.transform.position, 2f * Time.deltaTime);
            if (Shutter.transform.position == ShutterUpTarget.transform.position)
            {
                ShutterUp = true;
                isNextDayStart = false;
                isTextComeOutOver = false;
                TextComeTime = 0;
            }
        }

        if(ShutterUp)
        {

            isShopOpend = true;
            ShutterUp = false;
            MyTime = 0;
        }
    }



    public void DateExit()
    {
        isShopOpend = false;
        isDateExit = true;
    }


    public void ShutterManager()
    {
        SalesSettlementPage.SetActive(true);
        TextFade();
    }
    public void TextFade()
    {
        
        DayDisplay.text = GameManager.MyDay.ToString() + "일차";
        DayDisplay.color = new Color(255, 0, 0, 1);
        TodayMyMoneyText.text = startMoney.ToString() + "냥머니";
        TodayRevenue.text = DayRevenue.ToString() + "냥머니";
        DayUsedIngredient.text =  "-" + UsedIngredientPrice.ToString() + "냥머니";

        TodaySalesSettlement.text = SalesSettlement.ToString() + "냥머니";
        
        
        if(DebtDay == 7)
        {
            Debt.text = "-" + GameManager.DedtMoney.ToString();
        }
        else
        {
            //Debt.text = "빚 갚는 날 까지 D-" + DebtDay.ToString();
        }
       
    }



    IEnumerator _FadeOutOn()
    {
        
        while (fadeSequece >= 0)
        {
            fadeSequece -= 0.05f;
            yield return new WaitForSeconds(0.05f);
            BlackPage.color = new Color(0, 0, 0, fadeSequece);

        }
        isGameOverFadeInStart = true;
        ShutterDown = false;
    }

    IEnumerator _FadeInOn()
    {
        GameManager.isGameOver = true;
        while (fadeSequece <= 1)
        {
            fadeSequece += 0.05f;
            yield return new WaitForSeconds(0.05f);
            BlackPage.color = new Color(0, 0, 0, fadeSequece);
        }
        isGameOverFadeOut = true;
        GameoverPaLel.SetActive(true);
    }

}
