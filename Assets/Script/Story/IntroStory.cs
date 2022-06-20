using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IntroStory : MonoBehaviour
{
    public Text playerText;
    public GameObject[] CutSecne;
    public GameObject StartButton;
    private string P1_c1_text = "가게를 운영하시던 아버지가 편찮아지셔서 더 이상 가게를 운영하지 못하게 되는데..";
    private string P1_c2_text = "아버지는 아들에게 자신의 가게를 물려주게 된다.";
    private string P1_c3_text = "호기로운 마음으로 가게를 이어받은 고양이";
    private string P1_c4_text = "그러나 예상과는 다르게 가게엔 적자만 쌓이게 되고...";
    private string P2_c1_text = "손님이 안와서 슬퍼하는 고양이에게 누군가 찾아오게 되는데";
    private string P2_c2_text = "'허허 장사가 잘 안되는 모양이구만'";
    private string P2_c3_text = "'미안하지만 이번 주 안에 빌린 돈을 갚지 못하면 가게를 넘겨줘야겠어'";
    private string P3_c1_text = "설상가상 궁지에 몰리게 된 고양이";
    private string P3_c2_text = "아버지의 가게를 지키기 위해 가게를 부흥시켜야 한다!";

    private int P1_c1_cursor = 0;
    private int P1_c2_cursor = 0;
    private int P1_c3_cursor = 0;
    private int P1_c4_cursor = 0;
    private int P2_c1_cursor = 0;
    private int P2_c2_cursor = 0;
    private int P2_c3_cursor = 0;
    private int P3_c1_cursor = 0;
    private int P3_c2_cursor = 0;

    //다음 텍스트로 이동
    public bool P1_c1_NextCheck;
    public bool P1_c2_NextCheck;
    public bool P1_c3_NextCheck;
    public bool P1_c4_NextCheck;
    public bool P2_c1_NextCheck;
    public bool P2_c2_NextCheck;
    public bool P2_c3_NextCheck;
    public bool P3_c1_NextCheck;
    public bool P3_c2_NextCheck;

    //텍스트 한 번에 보이기
    public bool P1_c1_check;
    public bool P1_c2_check;
    public bool P1_c3_check;
    public bool P1_c4_check;
    public bool P2_c1_check;
    public bool P2_c2_check;
    public bool P2_c3_check;
    public bool P3_c1_check;
    public bool P3_c2_check;

    public int Story_Cursor;
    public bool isTypingStart;
    public bool isP1_c1_End;
    public bool isP1_c2_End;
    public bool isP1_c3_End;
    public bool isP1_c4_End;
    public bool isP2_c1_End;
    public bool isP2_c2_End;
    public bool isP2_c3_End;
    public bool isP3_c1_End;
    public bool isP3_c2_End;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(_typing());
        isTypingStart = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(IntroFade.isFadeOut)
        {
            TextTypingEffet();
        }
        
    }

    public void TextTypingEffet()
    {
        if(Story_Cursor == 9)
        {
            StartButton.SetActive(true);
        }
        if (Story_Cursor == 8)
        {

            CutSecne[9].SetActive(true);
           

            if (!P3_c2_check && isTypingStart)
            {
                P3_c2_cursor++;
                playerText.text = P3_c2_text.Substring(0, P3_c2_cursor);
             //   Debug.Log("첫번째 텍스트 입력");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P3_c2_text;
                P3_c2_cursor = P3_c2_text.Length + 1;
                P3_c2_check = true;
             //   Debug.Log("첫번째 한번에 보이기");

            }

            if (P3_c2_cursor >= P3_c2_text.Length)
            {
                isP3_c2_End = true;
                P3_c2_check = true;
                P3_c2_NextCheck = true;
                isP3_c2_End = true;
                Story_Cursor = 9;
             //   Debug.Log("다음 텍스트 준비");
            }


        }
        if (Story_Cursor == 7)
        {

            CutSecne[8].SetActive(true);
            for (int i = 1; i < 8; i++)
            {
                CutSecne[i].SetActive(false);
            }
            if (Input.GetMouseButtonUp(0) && isP3_c1_End)
            {
                P3_c1_NextCheck = true;
                isP3_c1_End = true;
                Story_Cursor = 8;
              //  Debug.Log("다음 텍스트로 이동");

            }

            if (!P3_c1_check && isTypingStart)
            {
                P3_c1_cursor++;
                playerText.text = P3_c1_text.Substring(0, P3_c1_cursor);
           //     Debug.Log("첫번째 텍스트 입력");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P3_c1_text;
                P3_c1_cursor = P3_c1_text.Length + 1;
                P3_c1_check = true;
              //  Debug.Log("첫번째 한번에 보이기");

            }

            if (P3_c1_cursor >= P3_c1_text.Length)
            {
                isP3_c1_End = true;
                P3_c1_check = true;
             //   Debug.Log("다음 텍스트 준비");
            }


        }
        if (Story_Cursor == 6)
        {

            CutSecne[6].SetActive(false);
            CutSecne[7].SetActive(true);
            if (Input.GetMouseButtonUp(0) && isP2_c3_End)
            {
                P2_c3_NextCheck = true;
                isP2_c3_End = true;
                Story_Cursor = 7;
             //   Debug.Log("다음 텍스트로 이동");

            }

            if (!P2_c3_check && isTypingStart)
            {
                P2_c3_cursor++;
                playerText.text = P2_c3_text.Substring(0, P2_c3_cursor);
            //    Debug.Log("첫번째 텍스트 입력");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P2_c3_text;
                P2_c3_cursor = P2_c3_text.Length + 1;
                P2_c3_check = true;
              //  Debug.Log("첫번째 한번에 보이기");

            }

            if (P2_c3_cursor >= P2_c3_text.Length)
            {
                isP2_c3_End = true;
                P2_c3_check = true;
             //   Debug.Log("다음 텍스트 준비");
            }


        }
        if (Story_Cursor == 5)
        {

            CutSecne[6].SetActive(true);
           
            if (Input.GetMouseButtonUp(0) && isP2_c2_End)
            {
                P2_c2_NextCheck = true;
                isP2_c2_End = true;
                Story_Cursor = 6;
            //    Debug.Log("다음 텍스트로 이동");

            }

            if (!P2_c2_check && isTypingStart)
            {
                P2_c2_cursor++;
                playerText.text = P2_c2_text.Substring(0, P2_c2_cursor);
             //   Debug.Log("첫번째 텍스트 입력");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P2_c2_text;
                P2_c2_cursor = P2_c2_text.Length + 1;
                P2_c2_check = true;
            //    Debug.Log("첫번째 한번에 보이기");

            }

            if (P2_c2_cursor >= P2_c2_text.Length)
            {
                isP2_c2_End = true;
                P2_c2_check = true;
            //    Debug.Log("다음 텍스트 준비");
            }


        }
        if (Story_Cursor == 4)
        {

            CutSecne[5].SetActive(true);
            for(int i = 1; i < 5; i++)
            {
                CutSecne[i].SetActive(false);
            }
            if (Input.GetMouseButtonUp(0) && isP2_c1_End)
            {
                P2_c1_NextCheck = true;
                isP2_c1_End = true;
                Story_Cursor = 5;
             //   Debug.Log("다음 텍스트로 이동");

            }

            if (!P2_c1_check && isTypingStart)
            {
                P2_c1_cursor++;
                playerText.text = P2_c1_text.Substring(0, P2_c1_cursor);
            //    Debug.Log("첫번째 텍스트 입력");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P2_c1_text;
                P2_c1_cursor = P2_c1_text.Length + 1;
                P2_c1_check = true;
            //    Debug.Log("첫번째 한번에 보이기");

            }

            if (P2_c1_cursor >= P2_c1_text.Length)
            {
                isP2_c1_End = true;
                P2_c1_check = true;
             //   Debug.Log("다음 텍스트 준비");
            }


        }
        if (Story_Cursor == 3)
        {

            CutSecne[4].SetActive(true);
            CutSecne[3].SetActive(false) ;
            if (Input.GetMouseButtonUp(0) && isP1_c4_End)
            {
                P1_c4_NextCheck = true;
                isP1_c4_End = true;
                Story_Cursor = 4;

             //   Debug.Log("다음 텍스트로 이동");

            }

            if (!P1_c4_check && isTypingStart)
            {
                P1_c4_cursor++;
                playerText.text = P1_c4_text.Substring(0, P1_c4_cursor);
             //   Debug.Log("4 텍스트 입력");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P1_c4_text;
                P1_c4_cursor = P1_c4_text.Length + 1;
                P1_c4_check = true;
            //    Debug.Log("4 한번에 보이기");

            }

            if (P1_c4_cursor >= P1_c4_text.Length)
            {
                isP1_c4_End = true;
                P1_c4_check = true;
             //   Debug.Log("다음 텍스트 준비");
            }


        }
        if (Story_Cursor == 2)
        {

            CutSecne[3].SetActive(true);

            if (Input.GetMouseButtonUp(0) && isP1_c3_End)
            {
                P1_c3_NextCheck = true;
                isP1_c3_End = true;
                Story_Cursor = 3;

             //   Debug.Log("다음 텍스트로 이동");

            }

            if (!P1_c3_check && isTypingStart)
            {
                P1_c3_cursor++;
                playerText.text = P1_c3_text.Substring(0, P1_c3_cursor);
              //  Debug.Log("세번째 텍스트 입력");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P1_c3_text;
                P1_c3_cursor = P1_c3_text.Length + 1;
                P1_c3_check = true;
              //  Debug.Log("세번째 한번에 보이기");

            }

            if (P1_c3_cursor >= P1_c3_text.Length)
            {
                isP1_c3_End = true;
                P1_c3_check = true;
               // Debug.Log("다음 텍스트 준비");
            }


        }
        if (Story_Cursor == 1)
        {

            CutSecne[2].SetActive(true);

            if (Input.GetMouseButtonUp(0) && isP1_c2_End)
            {
                P1_c2_NextCheck = true;
                isP1_c2_End = true;
                Story_Cursor = 2;
                
              //  Debug.Log("다음 텍스트로 이동");

            }

            if (!P1_c2_check && isTypingStart)
            {
                P1_c2_cursor++;
                playerText.text = P1_c2_text.Substring(0, P1_c2_cursor);
              //  Debug.Log("두번째 텍스트 입력");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P1_c2_text;
                P1_c2_cursor = P1_c2_text.Length + 1;
                P1_c2_check = true;
               // Debug.Log("두번째 한번에 보이기");

            }

            if (P1_c2_cursor >= P1_c2_text.Length)
            {
                isP1_c2_End = true;
                P1_c2_check = true;
               // Debug.Log("다음 텍스트 준비");
            }


        }
        if (Story_Cursor == 0)
        {
            
            CutSecne[1].SetActive(true);

            if (Input.GetMouseButtonUp(0) && isP1_c1_End)
            {
                P1_c1_NextCheck = true;
                isP1_c1_End = true;
                Story_Cursor = 1;
                //Debug.Log("다음 텍스트로 이동");

            }

            if (!P1_c1_check && isTypingStart)
            {                         
                P1_c1_cursor++;
                playerText.text = P1_c1_text.Substring(0, P1_c1_cursor);
                //Debug.Log("첫번째 텍스트 입력");            
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P1_c1_text;
                P1_c1_cursor = P1_c1_text.Length + 1;
                P1_c1_check = true;
                //Debug.Log("첫번째 한번에 보이기");

            }

            if (P1_c1_cursor >= P1_c1_text.Length)
            {
                isP1_c1_End = true;
                P1_c1_check = true;
               // Debug.Log("다음 텍스트 준비");  
            }
            

        }
     
    }
    IEnumerator _typingWaiting()
    {
        isTypingStart = false;
        yield return new WaitForSeconds(0.05f);
        isTypingStart = true;
    }


    public void GameStart()
    {
        GameManager.isTouch = true;
        GameManager.isGameStart = true;
       // Debug.Log("시작");

        IntroFade.isFadeInStart = true;
    }

    
}
