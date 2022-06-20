using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateText : MonoBehaviour
{
    public GameObject DayText;
    public GameObject[] IndexText;
    public GameObject[] ChangeText;

    public GameObject[] Button;
    public static float Mytimer;
    public static bool isTextOut;
    public static bool isTextOutOver;

    public GameObject GameManagerObj;
    public GameManager manager;
    // Start is called before the first frame update

    private void Start()
    {
        for(int i = 0; i<5; i++)
        {
            IndexText[i].SetActive(false);
            ChangeText[i].SetActive(false);
            DayText.SetActive(false);
            Button[0].SetActive(false);
            Button[1].SetActive(false);
        }
        Mytimer = 0;
        GameManagerObj = GameObject.FindWithTag("GameManagerObj");
        manager = GameManagerObj.GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isTextOut)
        {
            if(!isTextOutOver)
            {
              //  Debug.Log("텍스트 나오기 시작");
                StartCoroutine(_DayCalculate());
            }
            
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                IndexText[i].SetActive(false);
                ChangeText[i].SetActive(false);
                DayText.SetActive(false);
                Button[0].SetActive(false);
                Button[1].SetActive(false);
            }
            Mytimer = 0;
        }
     
    }


    IEnumerator _DayCalculate()
    {

        isTextOutOver = true;

        yield return new WaitForSeconds(0.4f);
        DayText.SetActive(true);
        

        yield return new WaitForSeconds(0.6f);
        IndexText[0].SetActive(true);

        yield return new WaitForSeconds(0.8f);
        ChangeText[0].SetActive(true);
        manager.SfxPlay(GameManager.sfx.Money1);

        yield return new WaitForSeconds(0.8f);
        IndexText[1].SetActive(true);

        yield return new WaitForSeconds(0.8f);
        ChangeText[1].SetActive(true);
        manager.SfxPlay(GameManager.sfx.Money1);

        yield return new WaitForSeconds(0.8f);
        IndexText[2].SetActive(true);

        yield return new WaitForSeconds(0.8f);
        ChangeText[2].SetActive(true);
        manager.SfxPlay(GameManager.sfx.Money1);

        if (DateManager.DebtDay == 7)
        {
            yield return new WaitForSeconds(0.8f);
            IndexText[3].SetActive(true);

            yield return new WaitForSeconds(0.8f);
            ChangeText[3].SetActive(true);
            manager.SfxPlay(GameManager.sfx.Money1);


            yield return new WaitForSeconds(0.8f);
            IndexText[4].SetActive(true);
            ChangeText[4].SetActive(true);
            manager.SfxPlay(GameManager.sfx.Money2);


            yield return new WaitForSeconds(0.8f);
            Button[0].SetActive(true);
            Button[1].SetActive(true);
            
        }
        else
        {
            yield return new WaitForSeconds(0.8f);
            IndexText[4].SetActive(true);
            ChangeText[4].SetActive(true);
            manager.SfxPlay(GameManager.sfx.Money2);



            yield return new WaitForSeconds(0.8f);
            Button[0].SetActive(true);
            Button[1].SetActive(true);
        }



    }
 


}
