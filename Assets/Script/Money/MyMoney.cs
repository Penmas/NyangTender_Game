using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMoney : MonoBehaviour
{
    public Text MoneyText;
    
    // Start is called before the first frame update
    void Start()
    {
        MoneyText.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        GoldLink();
    }


    public void GoldLink()
    {
        MoneyText.text = GameManager.myMoney.ToString();
    }
}
