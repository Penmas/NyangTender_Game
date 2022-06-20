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
    private string P1_c1_text = "���Ը� ��Ͻô� �ƹ����� ���������ż� �� �̻� ���Ը� ����� ���ϰ� �Ǵµ�..";
    private string P1_c2_text = "�ƹ����� �Ƶ鿡�� �ڽ��� ���Ը� �����ְ� �ȴ�.";
    private string P1_c3_text = "ȣ��ο� �������� ���Ը� �̾���� �����";
    private string P1_c4_text = "�׷��� ������� �ٸ��� ���Կ� ���ڸ� ���̰� �ǰ�...";
    private string P2_c1_text = "�մ��� �ȿͼ� �����ϴ� ����̿��� ������ ã�ƿ��� �Ǵµ�";
    private string P2_c2_text = "'���� ��簡 �� �ȵǴ� ����̱���'";
    private string P2_c3_text = "'�̾������� �̹� �� �ȿ� ���� ���� ���� ���ϸ� ���Ը� �Ѱ���߰ھ�'";
    private string P3_c1_text = "���󰡻� ������ ������ �� �����";
    private string P3_c2_text = "�ƹ����� ���Ը� ��Ű�� ���� ���Ը� ������Ѿ� �Ѵ�!";

    private int P1_c1_cursor = 0;
    private int P1_c2_cursor = 0;
    private int P1_c3_cursor = 0;
    private int P1_c4_cursor = 0;
    private int P2_c1_cursor = 0;
    private int P2_c2_cursor = 0;
    private int P2_c3_cursor = 0;
    private int P3_c1_cursor = 0;
    private int P3_c2_cursor = 0;

    //���� �ؽ�Ʈ�� �̵�
    public bool P1_c1_NextCheck;
    public bool P1_c2_NextCheck;
    public bool P1_c3_NextCheck;
    public bool P1_c4_NextCheck;
    public bool P2_c1_NextCheck;
    public bool P2_c2_NextCheck;
    public bool P2_c3_NextCheck;
    public bool P3_c1_NextCheck;
    public bool P3_c2_NextCheck;

    //�ؽ�Ʈ �� ���� ���̱�
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
             //   Debug.Log("ù��° �ؽ�Ʈ �Է�");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P3_c2_text;
                P3_c2_cursor = P3_c2_text.Length + 1;
                P3_c2_check = true;
             //   Debug.Log("ù��° �ѹ��� ���̱�");

            }

            if (P3_c2_cursor >= P3_c2_text.Length)
            {
                isP3_c2_End = true;
                P3_c2_check = true;
                P3_c2_NextCheck = true;
                isP3_c2_End = true;
                Story_Cursor = 9;
             //   Debug.Log("���� �ؽ�Ʈ �غ�");
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
              //  Debug.Log("���� �ؽ�Ʈ�� �̵�");

            }

            if (!P3_c1_check && isTypingStart)
            {
                P3_c1_cursor++;
                playerText.text = P3_c1_text.Substring(0, P3_c1_cursor);
           //     Debug.Log("ù��° �ؽ�Ʈ �Է�");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P3_c1_text;
                P3_c1_cursor = P3_c1_text.Length + 1;
                P3_c1_check = true;
              //  Debug.Log("ù��° �ѹ��� ���̱�");

            }

            if (P3_c1_cursor >= P3_c1_text.Length)
            {
                isP3_c1_End = true;
                P3_c1_check = true;
             //   Debug.Log("���� �ؽ�Ʈ �غ�");
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
             //   Debug.Log("���� �ؽ�Ʈ�� �̵�");

            }

            if (!P2_c3_check && isTypingStart)
            {
                P2_c3_cursor++;
                playerText.text = P2_c3_text.Substring(0, P2_c3_cursor);
            //    Debug.Log("ù��° �ؽ�Ʈ �Է�");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P2_c3_text;
                P2_c3_cursor = P2_c3_text.Length + 1;
                P2_c3_check = true;
              //  Debug.Log("ù��° �ѹ��� ���̱�");

            }

            if (P2_c3_cursor >= P2_c3_text.Length)
            {
                isP2_c3_End = true;
                P2_c3_check = true;
             //   Debug.Log("���� �ؽ�Ʈ �غ�");
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
            //    Debug.Log("���� �ؽ�Ʈ�� �̵�");

            }

            if (!P2_c2_check && isTypingStart)
            {
                P2_c2_cursor++;
                playerText.text = P2_c2_text.Substring(0, P2_c2_cursor);
             //   Debug.Log("ù��° �ؽ�Ʈ �Է�");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P2_c2_text;
                P2_c2_cursor = P2_c2_text.Length + 1;
                P2_c2_check = true;
            //    Debug.Log("ù��° �ѹ��� ���̱�");

            }

            if (P2_c2_cursor >= P2_c2_text.Length)
            {
                isP2_c2_End = true;
                P2_c2_check = true;
            //    Debug.Log("���� �ؽ�Ʈ �غ�");
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
             //   Debug.Log("���� �ؽ�Ʈ�� �̵�");

            }

            if (!P2_c1_check && isTypingStart)
            {
                P2_c1_cursor++;
                playerText.text = P2_c1_text.Substring(0, P2_c1_cursor);
            //    Debug.Log("ù��° �ؽ�Ʈ �Է�");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P2_c1_text;
                P2_c1_cursor = P2_c1_text.Length + 1;
                P2_c1_check = true;
            //    Debug.Log("ù��° �ѹ��� ���̱�");

            }

            if (P2_c1_cursor >= P2_c1_text.Length)
            {
                isP2_c1_End = true;
                P2_c1_check = true;
             //   Debug.Log("���� �ؽ�Ʈ �غ�");
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

             //   Debug.Log("���� �ؽ�Ʈ�� �̵�");

            }

            if (!P1_c4_check && isTypingStart)
            {
                P1_c4_cursor++;
                playerText.text = P1_c4_text.Substring(0, P1_c4_cursor);
             //   Debug.Log("4 �ؽ�Ʈ �Է�");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P1_c4_text;
                P1_c4_cursor = P1_c4_text.Length + 1;
                P1_c4_check = true;
            //    Debug.Log("4 �ѹ��� ���̱�");

            }

            if (P1_c4_cursor >= P1_c4_text.Length)
            {
                isP1_c4_End = true;
                P1_c4_check = true;
             //   Debug.Log("���� �ؽ�Ʈ �غ�");
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

             //   Debug.Log("���� �ؽ�Ʈ�� �̵�");

            }

            if (!P1_c3_check && isTypingStart)
            {
                P1_c3_cursor++;
                playerText.text = P1_c3_text.Substring(0, P1_c3_cursor);
              //  Debug.Log("����° �ؽ�Ʈ �Է�");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P1_c3_text;
                P1_c3_cursor = P1_c3_text.Length + 1;
                P1_c3_check = true;
              //  Debug.Log("����° �ѹ��� ���̱�");

            }

            if (P1_c3_cursor >= P1_c3_text.Length)
            {
                isP1_c3_End = true;
                P1_c3_check = true;
               // Debug.Log("���� �ؽ�Ʈ �غ�");
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
                
              //  Debug.Log("���� �ؽ�Ʈ�� �̵�");

            }

            if (!P1_c2_check && isTypingStart)
            {
                P1_c2_cursor++;
                playerText.text = P1_c2_text.Substring(0, P1_c2_cursor);
              //  Debug.Log("�ι�° �ؽ�Ʈ �Է�");
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P1_c2_text;
                P1_c2_cursor = P1_c2_text.Length + 1;
                P1_c2_check = true;
               // Debug.Log("�ι�° �ѹ��� ���̱�");

            }

            if (P1_c2_cursor >= P1_c2_text.Length)
            {
                isP1_c2_End = true;
                P1_c2_check = true;
               // Debug.Log("���� �ؽ�Ʈ �غ�");
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
                //Debug.Log("���� �ؽ�Ʈ�� �̵�");

            }

            if (!P1_c1_check && isTypingStart)
            {                         
                P1_c1_cursor++;
                playerText.text = P1_c1_text.Substring(0, P1_c1_cursor);
                //Debug.Log("ù��° �ؽ�Ʈ �Է�");            
                StartCoroutine(_typingWaiting());

            }

            if (Input.GetMouseButtonUp(0))
            {
                playerText.text = P1_c1_text;
                P1_c1_cursor = P1_c1_text.Length + 1;
                P1_c1_check = true;
                //Debug.Log("ù��° �ѹ��� ���̱�");

            }

            if (P1_c1_cursor >= P1_c1_text.Length)
            {
                isP1_c1_End = true;
                P1_c1_check = true;
               // Debug.Log("���� �ؽ�Ʈ �غ�");  
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
       // Debug.Log("����");

        IntroFade.isFadeInStart = true;
    }

    
}
