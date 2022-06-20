using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] Finger;
    public GameObject TutorialObj;
    public GameObject CocktailPageSee;
    public GameObject CustomerSee;
    public GameObject TrashCan;
    public Text MyText;
    private string Tuto00 = "날 도와주러 와줘서 고마워! 가게를 운영하는 방법은 간단해.";
    private string Tuto01 = "일정시간동안 이곳에서 손님이 들어올거야.";
    private string Tuto02 = "손님이 테이블에 앉으면 말풍선 안에 손님이 원하는 칵테일의 모양이 보일 거야.";
    private string Tuto03 = "그러면, 이 버튼을 눌러 칵테일 메이커를 열고, 칵테일을 만들어서 드래그로 전해주면 돼";
    private string Tuto04 = "만들 때 사용한 재료값은 돈에서 즉시 차감이 되니까 주의해! 돈이 부족하면 칵테일을 만들 수 없어.";
    private string Tuto04_1 = "칵테일은 1개만 만들 수 있으니까 만들고 바로 손님에게 전해주는 게 좋아.";
    private string Tuto04_2 = "만약 칵테일을 잘못 만들었으면 하단에 있는 쓰레기통에 버리면 돼.";
    private string Tuto05 = "혹시 칵테일의 레시피를 모른다고 해도 걱정하지마.";
    private string Tuto06 = "이 버튼은 레시피 북인데, 버튼만 누르면 언제든지 레시피를 볼 수 있어.";
    private string Tuto07 = "영업시간은 이곳에 표시가 되고, 영업이 종료가 되면 가게를 업그레이드 할 수 있어.";
    private string Tuto08 = "7일마다 내게 돈을 빌려준 '보스'가 와서 '5만 냥머니'를 받아갈 거야.";
    private string Tuto09 = "돈을 갚지 못한다면 가게를 빼앗기게 되니까, 열심히 일을 해서 많은 돈을 가지고 있어야 해!";
    private string Tuto10 = "기본적인 정보는 다 알려줬으니, 부가적인 정보는 가게를 운영하면서 직접 알아가 봐.";
    private string Tuto11 = "그럼 장사를 시작해보자!";



    public bool isTypingStart;
    public bool isTouch;

    public float TutoCursor;
    public int TutoTextCursor00;
    public int TutoTextCursor01;
    public int TutoTextCursor02;
    public int TutoTextCursor03;
    public int TutoTextCursor04;
    public int TutoTextCursor04_1;
    public int TutoTextCursor04_2;
    public int TutoTextCursor05;
    public int TutoTextCursor06;
    public int TutoTextCursor07;
    public int TutoTextCursor08;
    public int TutoTextCursor09;
    public int TutoTextCursor10;
    public int TutoTextCursor11;

    public bool TutoNext00;
    public bool TutoNext01;
    public bool TutoNext02;
    public bool TutoNext03;
    public bool TutoNext04;
    public bool TutoNext05;
    public bool TutoNext06;
    public bool TutoNext07;
    public bool TutoNext08;
    public bool TutoNext09;
    public bool TutoNext10;
    public bool TutoNext11;
    
    // Start is called before the first frame update
    void Start()
    {
        TutoCursor = 0;
        isTypingStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        typingStart();
    }


    IEnumerator _typingWaiting()
    {
        isTypingStart = false;
        yield return new WaitForSeconds(0.05f);
        isTypingStart = true;
    }

    public void typingStart()
    {
        if(GameManager.isTutoOver)
        {
            TutorialObj.SetActive(false);
        }
        else
        {
            TutorialObj.SetActive(true);
            if (isTypingStart)
            {
                if (TutoCursor == 0)
                {
                    if(Tuto00.Length >= TutoTextCursor00)
                    {
                        MyText.text = Tuto00.Substring(0, TutoTextCursor00);
                        TutoTextCursor00++;
                        StartCoroutine(_typingWaiting());
                        if(isTouch)
                        {
                            TutoTextCursor00 = Tuto00.Length;
                            MyText.text = Tuto00;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if(isTouch)
                        {
                            TutoCursor = 1;
                            isTouch = false;
                        }
                    }

                   
                }
                else if(TutoCursor == 1)
                {
                    Finger[0].SetActive(true);
                    if (Tuto01.Length >= TutoTextCursor01)
                    {
                        
                        MyText.text = Tuto01.Substring(0, TutoTextCursor01);
                        TutoTextCursor01++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor01 = Tuto01.Length;
                            MyText.text = Tuto01;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 2;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 2)
                {
                    Finger[0].SetActive(false);
                    Finger[4].SetActive(true);
                    CustomerSee.SetActive(true);
                    if (Tuto02.Length >= TutoTextCursor02)
                    {
                        MyText.text = Tuto02.Substring(0, TutoTextCursor02);
                        TutoTextCursor02++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor02 = Tuto02.Length;
                            MyText.text = Tuto02;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 3;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 3)
                {
                    Finger[0].SetActive(false);
                    Finger[1].SetActive(true);
                    Finger[4].SetActive(false);
                    CustomerSee.SetActive(false);
                    if (Tuto03.Length >= TutoTextCursor03)
                    {
                        MyText.text = Tuto03.Substring(0, TutoTextCursor03);
                        TutoTextCursor03++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor03 = Tuto03.Length;
                            MyText.text = Tuto03;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 4;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 4)
                {
                    Finger[1].SetActive(false);
                    CocktailPageSee.SetActive(true);

                    if (Tuto04.Length >= TutoTextCursor04)
                    {
                        MyText.text = Tuto04.Substring(0, TutoTextCursor04);
                        TutoTextCursor04++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor04 = Tuto04.Length;
                            MyText.text = Tuto04;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 4.1f;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 4.1f)
                {
                    CocktailPageSee.SetActive(false);
                    if (Tuto04_1.Length >= TutoTextCursor04_1)
                    {
                        MyText.text = Tuto04_1.Substring(0, TutoTextCursor04_1);
                        TutoTextCursor04_1++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor04_1 = Tuto04_1.Length;
                            MyText.text = Tuto04_1;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 4.2f;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 4.2f)
                {                   
                    CocktailPageSee.SetActive(false);
                    TrashCan.SetActive(true);
                    if (Tuto04_2.Length >= TutoTextCursor04_2)
                    {
                        MyText.text = Tuto04_2.Substring(0, TutoTextCursor04_2);
                        TutoTextCursor04_2++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor04_2 = Tuto04_2.Length;
                            MyText.text = Tuto04_2;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 5;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 5)
                {
                    TrashCan.SetActive(false);

                    if (Tuto05.Length >= TutoTextCursor05)
                    {
                        MyText.text = Tuto05.Substring(0, TutoTextCursor05);
                        TutoTextCursor05++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor05 = Tuto05.Length;
                            MyText.text = Tuto05;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 6;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 6)
                {
                    Finger[2].SetActive(true);
                    CocktailPageSee.SetActive(false);

                    if (Tuto06.Length >= TutoTextCursor06)
                    {
                        MyText.text = Tuto06.Substring(0, TutoTextCursor06);
                        TutoTextCursor06++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor06 = Tuto06.Length;
                            MyText.text = Tuto06;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 7;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 7)
                {
                    Finger[3].SetActive(true);
                    Finger[2].SetActive(false);
                    if (Tuto07.Length >= TutoTextCursor07)
                    {
                        MyText.text = Tuto07.Substring(0, TutoTextCursor07);
                        TutoTextCursor07++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor07 = Tuto07.Length;
                            MyText.text = Tuto07;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 8;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 8)
                {
                    Finger[3].SetActive(false);
                    if (Tuto08.Length >= TutoTextCursor08)
                    {
                        MyText.text = Tuto08.Substring(0, TutoTextCursor08);
                        TutoTextCursor08++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor08 = Tuto08.Length;
                            MyText.text = Tuto08;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 9;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 9)
                {
                    if (Tuto09.Length >= TutoTextCursor09)
                    {
                        MyText.text = Tuto09.Substring(0, TutoTextCursor09);
                        TutoTextCursor09++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor09 = Tuto09.Length;
                            MyText.text = Tuto09;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 10;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 10)
                {
                    if (Tuto10.Length >= TutoTextCursor10)
                    {
                        MyText.text = Tuto10.Substring(0, TutoTextCursor10);
                        TutoTextCursor10++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor10 = Tuto10.Length;
                            MyText.text = Tuto10;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 11;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 11)
                {
                    if (Tuto11.Length >= TutoTextCursor11)
                    {
                        MyText.text = Tuto11.Substring(0, TutoTextCursor11);
                        TutoTextCursor11++;
                        StartCoroutine(_typingWaiting());
                        if (isTouch)
                        {
                            TutoTextCursor11 = Tuto11.Length;
                            MyText.text = Tuto11;
                            isTouch = false;

                        }
                    }
                    else
                    {
                        if (isTouch)
                        {
                            TutoCursor = 12;
                            isTouch = false;
                        }
                    }
                }
                else if (TutoCursor == 12)
                {
                    GameManager.isTutoOver = true;
                    GameManager.bgmStart = true;
                    TutoCursor = 13;
                }
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                isTouch = true;
             //   Debug.Log("터치");
            }
        }
        
    }
}
