using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStory : MonoBehaviour
{
    public GameObject BossObj;
    public GameObject BossTextObj;
    public Text BossText;


    private string BossComeTalk00 = "���� ���� ���߳�?";
    private string BossComeTalk01 = "����... �����, ���� ���� ���� �� ������ ���ڳ�.";


    private string BossHappyTalk00 = "��ȣ... ������ ��縦 �ߴ°� ����!";
    private string BossHappyTalk01 = "����������.";
    private string BossHappyTalk02 = "���� ����! �̴�� ������ ���Ƴ����� �Ǵ� �ɼ�.";


    private string BossHappyTalk04 = "�׷� 7���Ŀ� �ٽ� ����������.";



    private string BossAngryTalk00 = "�̷�! ���� �������� �ʳ�?!";
    private string BossAngryTalk01 = "�Ǹ��̱�... ���� ���� ���Ͽ�����, �� ���Դ� ���� ��������������!";

    private string BossAngryTalk02 = "���� �����ϴٰ�?";
    private string BossAngryTalk03 = "�׷� ��Ӵ�� ���Ը� �޾ư��ڳ�!";


    public Image Boss;
    public Sprite[] BossSprite;
    public static bool isBossTextAllOut;
    public bool isTypingStart;
    public bool isTouch;

    public int BossTalkSelect;
    public int BossTalkHappySelect;
    public int BossTalkAngrySelect;
    public bool isBossTalkSelect;


    public bool isBossComeTalkOut;
    public bool isBossAngryTalkOut;
    public bool isBossHappyTalkOut;
    public bool isBossNormalTalkOut;

    public int AngryCursor;
    public int HappyCursor;
    public int NomalCursor;
    public int ComeCuresor;

    public int NormalTalkCursor00;
    public int NormalTalkCursor01;


    public int ComeTalkCursor00;
    public int ComeTalkCursor01;

    public int HappyTalkCursor00;
    public int HappyTalkCursor01;

    public int AngryTalkCursor00;
    public int AngryTalkCursor01;

    public bool isStartSound;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        TalkSelect();
        if(isBossTextAllOut)
        {
            BossObj.SetActive(false);
            BossTextObj.SetActive(false);
            isBossTalkSelect = false;
            isTypingStart = true;
            isBossTalkSelect = false;
            
        }
    }


    public void TalkSelect()
    {
        if(DateManager.isBossOutDay && DateManager.ShutterDown && !isBossTextAllOut)
        {
            
            if (!isBossTalkSelect)
            {
                //Debug.Log("���� �ؽ�Ʈ ������");
                BossObj.SetActive(true);
                BossTextObj.SetActive(true);
                Boss.sprite = BossSprite[0];
                BossTalkSelect = Random.Range(0, 4);
                BossTalkAngrySelect = Random.Range(0, 2);
                BossTalkHappySelect = Random.Range(0, 2);


                isTypingStart = true;
                isBossTalkSelect = true;
                HappyTalkCursor00 = 0;
                HappyTalkCursor01 = 0;
                isBossComeTalkOut = false;
                isBossAngryTalkOut = false;
                isBossHappyTalkOut = false;
                isBossNormalTalkOut = false;
                AngryCursor = 0;
                HappyCursor = 0;
                NomalCursor = 0;
                ComeCuresor = 0;
                NormalTalkCursor00 = 0;
                NormalTalkCursor01 = 0;
                ComeTalkCursor00 = 0;
                ComeTalkCursor01 = 0;
                AngryTalkCursor00 = 0;
                AngryTalkCursor01 = 0;
            }
            else
            {
                if(isBossComeTalkOut)
                {
                    if (DateManager.isBossHappy)
                    {
                        BossHappy();
                    }
                    else if (DateManager.isBossUpset)
                    {
                        BossAngry();
                    }
                }
                else
                {
                    BossCome();
                }
               
            }
            if (Input.GetMouseButtonUp(0))
            {
                isTouch = true;
                //Debug.Log("��ġ");
            }
        }
    }

    IEnumerator _typingWaiting()
    {
        isTypingStart = false;
        yield return new WaitForSeconds(0.05f);
        isTypingStart = true;
    }

    public void BossAngry()
    {
        Boss.sprite = BossSprite[1];
        if(!isStartSound)
        {
            GameManager.isBoss_angry = true;
            isStartSound = true;
        }
        if(isTypingStart)
        {
            switch (BossTalkAngrySelect)
            {
                case 0:
                    if(AngryCursor == 0)
                    {
                        

                        if(AngryTalkCursor00 >= BossAngryTalk00.Length)
                        {
                            if(isTouch)
                            {
                                AngryCursor = 1;
                                isTouch = false;
                            }
                            
                        }
                        else
                        {
                            BossText.text = BossAngryTalk00.Substring(0, AngryTalkCursor00);
                            AngryTalkCursor00++;
                            StartCoroutine(_typingWaiting());
                        }
                    }
                    else if(AngryCursor == 1)
                    {
                       
                        if (AngryTalkCursor01 >= BossAngryTalk01.Length)
                        {
                            if(isTouch)
                            {
                                AngryCursor = 2;
                                isTouch = false;
                            }
                            
                        }
                        else
                        {
                            BossText.text = BossAngryTalk01.Substring(0, AngryTalkCursor01);
                            AngryTalkCursor01++;
                            StartCoroutine(_typingWaiting());
                        }
                    }
                    else if(AngryCursor == 2)
                    {
                        isBossTextAllOut = true;
                        isStartSound = false;
                    }
                    break;

                case 1:
                    if (AngryCursor == 0)
                    {
                        
                        if (AngryTalkCursor00 >= BossAngryTalk02.Length)
                        {
                            if(isTouch)
                            {
                                AngryCursor = 1;
                                isTouch = false;
                            }
                            
                        }
                        else
                        {
                            BossText.text = BossAngryTalk02.Substring(0, AngryTalkCursor00);
                            AngryTalkCursor00++;
                            StartCoroutine(_typingWaiting());

                        }
                    }
                    else if (AngryCursor == 1)
                    {
                        
                        if (AngryTalkCursor01 >= BossAngryTalk03.Length)
                        {
                            if (isTouch)
                            {
                                AngryCursor = 2;
                                isTouch = false;
                            }
                            
                        }
                        else
                        {
                            BossText.text = BossAngryTalk03.Substring(0, AngryTalkCursor01);
                            AngryTalkCursor01++;
                            StartCoroutine(_typingWaiting());
                        }
                    }
                    else if (AngryCursor == 2)
                    {
                        isBossTextAllOut = true;
                        isStartSound = false;
                    }
                    break;
            }
           
        }

        if(isTouch)
        {
            switch(BossTalkAngrySelect)
            {
                case 0:
                    if (AngryCursor == 0)
                    {
                        AngryTalkCursor00 = BossAngryTalk00.Length;
                        BossText.text = BossAngryTalk00;
                        isTouch = false;
                    }
                    else if (AngryCursor == 1)
                    {
                        AngryTalkCursor01 = BossAngryTalk01.Length;
                        BossText.text = BossAngryTalk01;
                        isTouch = false;
                    }
                    break;

                case 1:
                    if (AngryCursor == 0)
                    {
                        AngryTalkCursor00 = BossAngryTalk02.Length;
                        BossText.text = BossAngryTalk02;
                        isTouch = false;
                    }
                    else if (AngryCursor == 1)
                    {
                        AngryTalkCursor01 = BossAngryTalk03.Length;
                        BossText.text = BossAngryTalk03;
                        isTouch = false;
                    }
                    break;
            }
            
        }
    }

    public void BossCome()
    {
        if(!isStartSound)
        {
            GameManager.isBoss_Nomal = true;
            isStartSound = true;
        }
        if(isTypingStart)
        {
            if (ComeCuresor == 0)
            {
                if (ComeTalkCursor00 >= BossComeTalk00.Length)
                {
                    if (isTouch)
                    {
                        ComeCuresor = 1;
                        isTouch = false;
                    }

                }
                else
                {
                    
                    Boss.sprite = BossSprite[0];
                    BossText.text = BossComeTalk00.Substring(0, ComeTalkCursor00);
                    ComeTalkCursor00++;
                    StartCoroutine(_typingWaiting());
                    if (isTouch)
                    {
                        ComeTalkCursor00 = BossComeTalk00.Length;
                        BossText.text = BossComeTalk00;
                        isTouch = false;

                    }

                }
            }
            else if (ComeCuresor == 1)
            {


                if (ComeTalkCursor01 >= BossComeTalk01.Length)
                {
                    if (isTouch)
                    {
                        ComeCuresor = 2;
                        isTouch = false;
                    }

                }
                else
                {
                    Boss.sprite = BossSprite[3];
                    BossText.text = BossComeTalk01.Substring(0, ComeTalkCursor01);
                    ComeTalkCursor01++;
                    StartCoroutine(_typingWaiting());
                    if (isTouch)
                    {
                        ComeTalkCursor01 = BossComeTalk01.Length;
                        BossText.text = BossComeTalk01;
                        isTouch = false;

                    }
                }
            }
            else if (ComeCuresor == 2)
            {
                isBossComeTalkOut = true;
                isStartSound = false;
            }
        }
        


       
        

    }
    public void BossHappy()
    {
        Boss.sprite = BossSprite[2];
        if(!isStartSound)
        {
            GameManager.isBoss_Happy = true;
            isStartSound = true;
        }
        if (isTypingStart)
        {
            switch (BossTalkHappySelect)
            {
                case 0:
                    if (HappyCursor == 0)
                    {


                        if ( HappyTalkCursor00 >=BossHappyTalk00.Length)
                        {
                            if(isTouch)
                            {
                                HappyCursor = 1;
                                isTouch = false;
                            }
                            
                           
                        }
                        else
                        {
                            BossText.text = BossHappyTalk00.Substring(0, HappyTalkCursor00);
                            HappyTalkCursor00++;
                            StartCoroutine(_typingWaiting());
                        }
                    }
                    else if (HappyCursor == 1)
                    {

                        if (HappyTalkCursor01 >= BossHappyTalk04.Length)
                        {
                            if (isTouch)
                            {
                                HappyCursor = 2;
                                isTouch = false;
                            }
                           
                        }
                        else
                        {
                            BossText.text = BossHappyTalk04.Substring(0, HappyTalkCursor01);
                            HappyTalkCursor01++;
                            StartCoroutine(_typingWaiting());
                        }
                    }
                    else if (HappyCursor == 2)
                    {
                        isBossTextAllOut = true;
                        isStartSound = false;
                    }
                    break;

                case 1:
                    if (HappyCursor == 0)
                    {

                        if (HappyTalkCursor00 >= BossHappyTalk01.Length)
                        {
                            if (isTouch)
                            {
                                HappyCursor = 1;
                                isTouch = false;
                            }

                        }
                        else
                        {
                            BossText.text = BossHappyTalk01.Substring(0, HappyTalkCursor00);
                            HappyTalkCursor00++;
                            StartCoroutine(_typingWaiting());

                        }
                    }
                    else if (HappyCursor == 1)
                    {

                        if (HappyTalkCursor01 >= BossHappyTalk04.Length)
                        {
                            if (isTouch)
                            {
                                HappyCursor = 2;
                                isTouch = false;
                            }

                        }
                        else
                        {
                            BossText.text = BossHappyTalk04.Substring(0, HappyTalkCursor01);
                            HappyTalkCursor01++;
                            StartCoroutine(_typingWaiting());
                        }
                    }
                    else if (HappyCursor == 2)
                    {
                        isBossTextAllOut = true;
                        isStartSound = false;
                    }
                    break;
            }

        }

        if (isTouch)
        {
            switch (BossTalkHappySelect)
            {
                case 0:
                    if (HappyCursor == 0)
                    {
                        HappyTalkCursor00 = BossHappyTalk00.Length + 1;
                        BossText.text = BossHappyTalk00;
                        isTouch = false;
                    }
                    else if (HappyCursor == 1)
                    {
                        HappyTalkCursor01 = BossHappyTalk04.Length + 1;
                        BossText.text = BossHappyTalk04;
                        isTouch = false;
                    }
                    break;

                case 1:
                    if (HappyCursor == 0)
                    {
                        HappyTalkCursor00 = BossHappyTalk01.Length + 1;
                        BossText.text = BossHappyTalk01;
                        isTouch = false;
                    }
                    else if (HappyCursor == 1)
                    {
                        HappyTalkCursor01 = BossHappyTalk04.Length + 1;
                        BossText.text = BossHappyTalk04;
                        isTouch = false;
                    }
                    break;
            }

        }
    }

}
