using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isAllSpriteAlphaOn;
    public static bool isTutoOver;
    public static int myMoney;       //돈
    public static int upgradeRecipe = 0;           //레시피 업그레이드
    public static int upgreadTimer = 0;             //영업시간 업그레이드
    public static int MyDay = 1;            //일차
    public static bool isHavePlayData;      //이전에 한 플레이 데이터 존재 유무
    public static int DedtMoney = 50000;


    public static int PriceMiaojito = 2000;
    public static int PriceCatrose = 3000;
    public static int PriceSidecat = 4200;
    public static int PriceNyangtini = 6000;
    public static int PriceBlueRaccon = 7500;
    public static int PriceChurLibre = 9700;

    public static int PriceGin = 100;
    public static int PriceRum = 300;
    public static int PriceSyrup = 240;
    public static int PriceCuracao = 160;


    
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] bgmClip;
    public AudioClip[] sfxClip;
    public int sfxCursor;
    public enum sfx { CatOrder, CatSad,  CatGood, AddCocktail, Ring, Money1, Sake, Touch, RecipePage, Money2, Boss_Angry, Boss_Happy, Boss_Nomal, GameOver, ShutterMove }
    public enum bgm { neon, bgm1, bgm2, intro}

    public static bool isCatorder;
    public static bool isCatSad;
    public static bool isCatGood;
    public static bool isAddCocktail;
    public static bool isRing;
    public static bool isMoney1;
    public static bool isMoney2;
    public static bool isBoss_angry;
    public static bool isBoss_Happy;
    public static bool isBoss_Nomal;
    public static bool isGameOver;
    public static bool isShutterMove;
    public static bool isSakeOn;
    public static bool isTouch;
    public static bool isRecipePage;

    public static bool bgmStart;
    public static bool isIntroStart;
    public static bool isGameStart;
    // Start is called before the first frame update

    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static GameManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
        bgmPlyer(bgm.neon);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(myMoney);
        if(DateManager.isShopOpend && bgmStart)
        {
            bgmPlayer.loop = true;
            bgmStart = false;
            bgmPlayer.mute = false;
            bgmPlyer(bgm.bgm1);
        }
        
        if(DateManager.isShopOpend == false)
        {
            bgmPlayer.Stop();
            
        }

        if(isIntroStart)
        {
            bgmPlyer(bgm.intro);
            bgmPlayer.loop = true;
            bgmPlayer.mute = false;
            isIntroStart = false;
        }
        if(isGameStart)
        {
            bgmPlayer.Stop();
            isGameStart = false;
        }

        if (isRing)
        {
            SfxPlay(sfx.Ring);
            isRing = false;
        }

        if (isAddCocktail)
        {
            SfxPlay(sfx.AddCocktail);
            isAddCocktail = false;
        }

        if(isRecipePage)
        {
            SfxPlay(sfx.RecipePage);
            isRecipePage = false;
        }

        if(isCatorder)
        {
            SfxPlay(sfx.CatOrder);
            isCatorder = false;
        }

        if(isCatGood)
        {
            SfxPlay(sfx.CatGood);
            isCatGood = false;
        }

        if(isCatSad)
        {
            SfxPlay(sfx.CatSad);
            isCatSad = false; 
        }

        if(isTouch)
        {
            SfxPlay(sfx.Touch);
            isTouch = false;
        }

        if(isMoney1)
        {
            SfxPlay(sfx.Money1);
            isMoney1 = false;
        }

        if (isMoney2)
        {
            SfxPlay(sfx.Money2);
            isMoney2 = false;
        }

        if(isBoss_angry)
        {
            SfxPlay(sfx.Boss_Angry);
            isBoss_angry = false;
        }

        if (isBoss_Happy)
        {
            SfxPlay(sfx.Boss_Happy);
            isBoss_Happy = false;
        }

        if (isBoss_Nomal)
        {
            SfxPlay(sfx.Boss_Nomal);
            isBoss_Nomal = false;
        }

        if (isShutterMove)
        {
            SfxPlay(sfx.ShutterMove);
            isShutterMove = false;
        }

        if (isGameOver)
        {
            SfxPlay(sfx.GameOver);
            isGameOver = false;
        }

    }


    public static void GameSave()
    {
        PlayerPrefs.SetInt("MyMoney", myMoney);
        PlayerPrefs.SetInt("upgradeRecipe", upgradeRecipe);
        //PlayerPrefs.SetInt("upgradeTable", upgradeTable);
        PlayerPrefs.SetInt("upgradeTimer", upgreadTimer);
        PlayerPrefs.SetInt("Day", MyDay);
        PlayerPrefs.Save();
        
    }


    public static void GameRoad()
    {
        if(!PlayerPrefs.HasKey("MyMoney"))
        {
            return;
        }
        myMoney = PlayerPrefs.GetInt("MyMoney");
        upgradeRecipe = PlayerPrefs.GetInt("upgradeRecipe");
        //upgradeTable = PlayerPrefs.GetInt("upgradeTable");
        upgreadTimer = PlayerPrefs.GetInt("upgradeTimer");
        MyDay = PlayerPrefs.GetInt("Day");
    }

    public static void GameReset()
    {
        PlayerPrefs.SetInt("MyMoney", 30000);
        PlayerPrefs.SetInt("upgradeRecipe", 0);
        //PlayerPrefs.SetInt("upgradeTable", upgradeTable);
        PlayerPrefs.SetInt("upgradeTimer", 0);
        PlayerPrefs.SetInt("Day", 1);
    }


    public void SfxPlay(sfx type)
    {
        switch (type)
        {
            case sfx.CatOrder:
                sfxPlayer[sfxCursor].clip = sfxClip[0];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.CatSad:
                sfxPlayer[sfxCursor].clip = sfxClip[1];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.CatGood:
                sfxPlayer[sfxCursor].clip = sfxClip[2];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.AddCocktail:
                sfxPlayer[sfxCursor].clip = sfxClip[3];
                sfxPlayer[sfxCursor].volume = 0.3f;
                break;
            case sfx.Ring:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.Money1:
                sfxPlayer[sfxCursor].clip = sfxClip[5];
                sfxPlayer[sfxCursor].volume = 0.6f;
                break;
            case sfx.Sake:
                sfxPlayer[sfxCursor].clip = sfxClip[6];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.Touch:
                sfxPlayer[sfxCursor].clip = sfxClip[7];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.RecipePage:
                sfxPlayer[sfxCursor].clip = sfxClip[8];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.Money2:
                sfxPlayer[sfxCursor].clip = sfxClip[9];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.Boss_Angry:
                sfxPlayer[sfxCursor].clip = sfxClip[10];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.Boss_Happy:
                sfxPlayer[sfxCursor].clip = sfxClip[11];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.Boss_Nomal:
                sfxPlayer[sfxCursor].clip = sfxClip[12];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.GameOver:
                sfxPlayer[sfxCursor].clip = sfxClip[13];
                sfxPlayer[sfxCursor].volume = 0.2f;
                break;
            case sfx.ShutterMove:
                sfxPlayer[sfxCursor].clip = sfxClip[14];
                sfxPlayer[sfxCursor].volume = 0.4f;
                break;
        }

        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }


    public void bgmPlyer(bgm type)
    {
        switch (type)
        {
            case bgm.neon:
                bgmPlayer.clip = bgmClip[0];
                break;
            case bgm.bgm1:
                bgmPlayer.clip = bgmClip[1];
                break;
            case bgm.bgm2:
                bgmPlayer.clip = bgmClip[2];
                break;
            case bgm.intro:
                bgmPlayer.clip = bgmClip[3];
                break;
        }
        bgmPlayer.Play();
        
    }
}
