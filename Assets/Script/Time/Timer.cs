using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{


    public static float StageTime;
    public float TimerMin1;
    public float TimerMin10;
    public float TimerHour1;
    public float TimerHour10;

    public float TimerMin1Ca;
    public float TimerMin10Ca;
    public float TimerHour1Ca;
    public float TimerHour10Ca;

    public bool isTimerNextDay;

    public Image min1;
    public Image min10;
    public Image Hour1;
    public Image Hour10;



    public Sprite Num0;
    public Sprite Num1;
    public Sprite Num2;
    public Sprite Num3;
    public Sprite Num4;
    public Sprite Num5;
    public Sprite Num6;
    public Sprite Num7;
    public Sprite Num8;
    public Sprite Num9;
    //public GameObject arrow_center; // Empty Game Object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StageTime = DateManager.MyTime;

        TimerMin1 = (StageTime % 60) % 10;
        if(TimerMin10 >= 6)
        {
            TimerMin10 = (((StageTime % 60) - TimerMin1) / 10) - 6;
        }
        else
        {
            TimerMin10 = ((StageTime % 60) - TimerMin1) / 10;
        }

        if(!isTimerNextDay)
        {
            TimerHour1 = (((StageTime / 60) + 20) % 24) % 10;
            TimerHour10 = (((StageTime / 60) + 20) % 24) / 10;
        }
        else
        {
            TimerHour1 = ((((StageTime / 60) + 20) % 24) - 4) % 10;
            TimerHour10 = (((StageTime / 60) + 20) % 24) / 10 - 2;
        }
        

        if((((StageTime / 60) + 20) % 24) % 10 >= 4)
        {
            isTimerNextDay = true;
        }

        

        min1Changer();
        min10Changer();
        hour1Changer();
        hour10Changer();
    }



    void min1Changer()
    {
        if(TimerMin1 >= 0 && TimerMin1 < 1)
        {
            min1.sprite = Num0;
            
        }
        else if (TimerMin1 >= 1 && TimerMin1 < 2)
        {
            min1.sprite = Num1;
        }
        else if (TimerMin1 >= 2 && TimerMin1 < 3)
        {
            min1.sprite = Num2;
        }
        else if (TimerMin1 >= 3 && TimerMin1 < 4)
        {
            min1.sprite = Num3;
        }
        else if (TimerMin1 >= 4 && TimerMin1 < 5)
        {
            min1.sprite = Num4;
        }
        else if (TimerMin1 >= 5 && TimerMin1 < 6)
        {
            min1.sprite = Num5;
        }
        else if (TimerMin1 >= 6 && TimerMin1 < 7)
        {
            min1.sprite = Num6;
        }
        else if (TimerMin1 >= 7 && TimerMin1 < 8)
        {
            min1.sprite = Num7;
        }
        else if (TimerMin1 >= 8 && TimerMin1 < 9)
        {
            min1.sprite = Num8;
        }
        else if (TimerMin1 >= 9 && TimerMin1 < 10)
        {
            min1.sprite = Num9;
        }

    }

    void min10Changer()
    {
        if (TimerMin10 >= 0 && TimerMin10 < 1)
        {
            min10.sprite = Num0;

        }
        else if (TimerMin10 >= 1 && TimerMin10 < 2)
        {
            min10.sprite = Num1;
        }
        else if (TimerMin10 >= 2 && TimerMin10 < 3)
        {
            min10.sprite = Num2;
        }
        else if (TimerMin10 >= 3 && TimerMin10 < 4)
        {
            min10.sprite = Num3;
        }
        else if (TimerMin10 >= 4 && TimerMin10 < 5)
        {
            min10.sprite = Num4;
        }
        else if (TimerMin10 >= 5 && TimerMin10 < 6)
        {
            min10.sprite = Num5;
        }
        
    }
    
    void hour1Changer()
    {
        if (TimerHour1 >= 0 && TimerHour1 < 1)
        {
            Hour1.sprite = Num0;

        }
        else if (TimerHour1 >= 1 && TimerHour1 < 2)
        {
            Hour1.sprite = Num1;
        }
        else if (TimerHour1 >= 2 && TimerHour1 < 3)
        {
            Hour1.sprite = Num2;
        }
        else if (TimerHour1 >= 3 && TimerHour1 < 4)
        {
            Hour1.sprite = Num3;
        }
        else if (TimerHour1 >= 4 && TimerHour1 < 5)
        {
            Hour1.sprite = Num4;
        }
        else if (TimerHour1 >= 5 && TimerHour1 < 6)
        {
            Hour1.sprite = Num5;
        }
        else if (TimerHour1 >= 6 && TimerHour1 < 7)
        {
            Hour1.sprite = Num6;
        }
        else if (TimerHour1 >= 7 && TimerHour1 < 8)
        {
            Hour1.sprite = Num7;
        }
        else if (TimerHour1 >= 8 && TimerHour1 < 9)
        {
            Hour1.sprite = Num8;
        }
        else if (TimerHour1 >= 9 && TimerHour1 < 10)
        {
            Hour1.sprite = Num9;
        }
    }

    void hour10Changer()
    {
        if (TimerHour10 >= 0 && TimerHour10 < 1)
        {
            Hour10.sprite = Num0;

        }
        else if (TimerHour10 >= 1 && TimerHour10 < 2)
        {
            Hour10.sprite = Num1;
        }
        else if (TimerHour10 >= 2 && TimerHour10 < 3)
        {
            Hour10.sprite = Num2;
        }
    }

}
