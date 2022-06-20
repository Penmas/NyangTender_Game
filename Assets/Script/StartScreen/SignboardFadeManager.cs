using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignboardFadeManager : MonoBehaviour
{
    public static bool isCatFootOn;
    public static bool isCupOn;
    public static bool isSignOn;
    public static bool isLineOn;
    public static bool isBackLightOn;

    public SpriteRenderer RendererCatFoot;
    public SpriteRenderer RendererCupTop;
    public SpriteRenderer RendererCupBottom;
    public SpriteRenderer RendererSign;
    public SpriteRenderer RendererLine;
    public SpriteRenderer RendererBackLight;

    public Image StartButton;
    public Text StartText;
    public Image LoadButton;
    public Text LoadText;

    public float CatFootFade = 0;
    public float CupFade = 0;
    public float LineFade = 0;
    public float SignFade = 0;
    public float BackLightFade = 0;

    public int LineSequence;
    public int CatFootSequence;
    public int CupSequence;
    public int SignSequence;

    public GameObject ButtonStart;
    public GameObject ButtonRoad;
    public GameObject ButtonUnlockRoad;


    private void Start()
    {
        RendererCatFoot.color = new Color(255, 255, 255, 0);
        RendererCupTop.color = new Color(255, 255, 255, 0);
        RendererCupBottom.color = new Color(255, 255, 255, 0);
        RendererSign.color = new Color(255, 255, 255, 0);
        RendererLine.color = new Color(255, 255, 255, 0);
        RendererBackLight.color = new Color(255, 255, 255, 0);
        ButtonRoad.SetActive(false);
        ButtonStart.SetActive(false);
        ButtonUnlockRoad.SetActive(false);
    }

    private void FixedUpdate()
    {
        
        

        if (GameManager.isAllSpriteAlphaOn)
        {
            Invoke("ButtonFadeIn", 0.05f);
            RendererCatFoot.color = new Color(255, 255, 255, 1);
            RendererCupTop.color = new Color(255, 255, 255, 1);
            RendererCupBottom.color = new Color(255, 255, 255, 1);
            RendererSign.color = new Color(255, 255, 255, 1);
            RendererLine.color = new Color(255, 255, 255, 1);
            RendererBackLight.color = new Color(255, 255, 255, 1);
        }
        else
        {
            LineFadeIn();
            CatFootFadeIn();
            CupFadeIn();
            SignFadeIn();
            if (isSignOn)
            {
                Invoke("BackLightFadeIn", 1f);
            }

        }

    }

    void LineFadeIn()
    {
        if (LineSequence == 0)
        {
            LineFade = LineFade + 0.05f;
            RendererLine.color = new Color(255, 255, 255, LineFade);
            if (LineFade >= 1)
            {
                LineSequence = 1;
            }
        }

        if (LineSequence == 1)
        {
            LineFade = LineFade - 0.05f;
            RendererLine.color = new Color(255, 255, 255, LineFade);
            if (LineFade <= 0.2f)
            {
                LineSequence = 2;
            }
        }

        if (LineSequence == 2)
        {
            LineFade = LineFade + 0.05f;
            RendererLine.color = new Color(255, 255, 255, LineFade);
            if (LineFade >= 1)
            {
                LineSequence = 3;
            }
        }

        if (LineSequence == 3)
        {
            Debug.Log("테투리 나타남");
            isLineOn = true;
        }

    }


    void CatFootFadeIn()
    {
        if (isLineOn && CatFootSequence < 3)
        {

            if (CatFootSequence == 0)
            {
                CatFootFade = CatFootFade + 0.05f;
                RendererCatFoot.color = new Color(255, 255, 255, CatFootFade);
                if (CatFootFade >= 1)
                {
                    CatFootSequence = 1;
                }
            }

            if (CatFootSequence == 1)
            {
                CatFootFade = CatFootFade - 0.06f;
                RendererCatFoot.color = new Color(255, 255, 255, CatFootFade);
                if (CatFootFade <= 0.2f)
                {
                    CatFootSequence = 2;
                }
            }

            if (CatFootSequence == 2)
            {
                CatFootFade = CatFootFade + 0.06f;
                RendererCatFoot.color = new Color(255, 255, 255, CatFootFade);
                if (CatFootFade >= 1)
                {
                    CatFootSequence = 3;
                }
            }
        }

        if (CatFootSequence == 1)
        {
            Debug.Log("발자국 나타남");
            isCatFootOn = true;
        }
    }

    void CupFadeIn()
    {
        if (isCatFootOn && CupSequence < 3)
        {
            if (CupSequence == 0)
            {
                CupFade = CupFade + 0.05f;
                RendererCupTop.color = new Color(255, 255, 255, CupFade);
                RendererCupBottom.color = new Color(255, 255, 255, CupFade);
                if (CupFade >= 1)
                {
                    CupSequence = 1;
                }
            }

            if (CupSequence == 1)
            {
                CupFade = CupFade - 0.05f;
                RendererCupTop.color = new Color(255, 255, 255, CupFade);
                RendererCupBottom.color = new Color(255, 255, 255, CupFade);
                if (CupFade <= 0.2f)
                {
                    CupSequence = 2;
                }
            }

            if (CupSequence == 2)
            {
                CupFade = CupFade + 0.05f;
                RendererCupTop.color = new Color(255, 255, 255, CupFade);
                RendererCupBottom.color = new Color(255, 255, 255, CupFade);
                if (CupFade >= 1)
                {
                    CupSequence = 3;
                }
            }
        }

        if (CupSequence == 3)
        {
            Debug.Log("컵 나타남");
            isCupOn = true;
        }

    }

    void SignFadeIn()
    {
        if (isCupOn && SignSequence < 3)
        {

            if (SignSequence == 0)
            {
                SignFade = SignFade + 0.1f;
                RendererSign.color = new Color(255, 255, 255, SignFade);
                if (SignFade >= 1)
                {
                    SignSequence = 1;
                }
            }

            if (SignSequence == 1)
            {
                SignFade = SignFade - 0.1f;
                RendererSign.color = new Color(255, 255, 255, SignFade);
                if (SignFade <= 0.2f)
                {
                    SignSequence = 2;
                }
            }

            if (SignSequence == 2)
            {
                SignFade = SignFade + 0.1f;
                RendererSign.color = new Color(255, 255, 255, SignFade);
                if (SignFade >= 1)
                {
                    SignSequence = 3;
                }
            }
        }

        if (SignSequence == 3)
        {
            Debug.Log("타이틀 나타남");
            isSignOn = true;
        }
    }

    void BackLightFadeIn()
    {
        if (isSignOn && BackLightFade < 1)
        {
            BackLightFade = BackLightFade + 0.05f;
            RendererBackLight.color = new Color(255, 255, 255, BackLightFade);
        }

        if (!isBackLightOn && SignFade >= 1)
        {
            Debug.Log("조명 나타남");
            isBackLightOn = true;
            GameManager.isAllSpriteAlphaOn = true;
        }
    }


    void ButtonFadeIn()
    {
        if (GameManager.isHavePlayData)
        {
            ButtonRoad.SetActive(true);
        }
        else
        {
            ButtonUnlockRoad.SetActive(true);
        }

        ButtonStart.SetActive(true);
    }
}