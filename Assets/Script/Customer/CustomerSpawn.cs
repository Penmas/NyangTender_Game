using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject[] Customer;
    public Transform Gate;
    public static GameManager manager;
    public GameObject gamemanager;

    public float curTime;
    public float spawnTime;
    public bool isFullCustomer;
    public static int CustomerNum;
    public int CustomerRand;

    public static bool isStartSpawn = true;
    public static int CustomerGroundOutNum;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        CustomerSpawn.CustomerNum = 0;
        isStartSpawn = true;
        CustomerGroundOutNum = 0;
        isFullCustomer = false;
        curTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!DateManager.isDateExit && DateManager.isShopOpend && GameManager.isTutoOver)
        {
            CustomerFullCheck();
            if(!isStartSpawn)
            {
                curTime += Time.deltaTime;
            }
            
            if (!isFullCustomer)
            {
                Spawn();
            }

            if(isStartSpawn)
            {
                Invoke("InstantiateCustomer", 5f);
                isStartSpawn = false;
            }
        }

        if(DateManager.isDateExit)
        {
            curTime = 0f;
            isStartSpawn = true;
        }
    }

    public void Spawn()
    {
        if (spawnTime <= curTime)
        {
            InstantiateCustomer();
            curTime = 0;
            
            
        }
    }

    public void CustomerFullCheck()
    {
        if(CustomerNum >= 6)
        {
            isFullCustomer = true;
        }
        else
        {
            isFullCustomer = false;
        }
    }

    public void InstantiateCustomer()
    {
        CustomerRand = Random.Range(0, 13);
        Instantiate(Customer[CustomerRand], Gate);
        CustomerGroundOutNum++;
        CustomerNum++;
        //Debug.Log(CustomerGroundOutNum);
        GameManager.isRing = true;
        
    }

}
