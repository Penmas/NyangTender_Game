using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{


    //���̺�� �̵��ϴ� ��� ����� ��
    public static int NumTable01 = 2;
    public static int NumTable02 = 5;
    public static int NumTable03 = 7;
    public static int NumTable04 = 5;
    public static int NumTable05 = 6;
    public static int NumTable06 = 8;

    //���̺� ��ġ ����
    public GameObject DoorPosition;
    public GameObject DestroyPosition;
    public GameObject[] LocaTable01;
    public GameObject[] LocaTable02;
    public GameObject[] LocaTable03;
    public GameObject[] LocaTable04;
    public GameObject[] LocaTable05;
    public GameObject[] LocaTable06;

    //���̺�� ��, �Ҹ� ���� ��ǥ ����
    public static Vector2 Door;
    public static Vector2 DestroyPos;
    public static Vector2 positionTable01;
    public static Vector2 positionTable02;
    public static Vector2 positionTable03;
    public static Vector2 positionTable04;
    public static Vector2 positionTable05;
    public static Vector2 positionTable06;

    //��� ��ǥ static �迭�� ����
    public static Vector2[] Table01Route = new Vector2[NumTable01];
    public static Vector2[] Table02Route = new Vector2[NumTable02];
    public static Vector2[] Table03Route = new Vector2[NumTable03];
    public static Vector2[] Table04Route = new Vector2[NumTable04];
    public static Vector2[] Table05Route = new Vector2[NumTable05];
    public static Vector2[] Table06Route = new Vector2[NumTable06];

    //���̺� ������
    public static bool isTable01Sit = false;
    public static bool isTable02Sit = false;
    public static bool isTable03Sit = false;
    public static bool isTable04Sit = false;
    public static bool isTable05Sit = false;
    public static bool isTable06Sit = false;

    void Start()
    {
        PositionAssign();
        RouteSave();
    }

    // Update is called once per frame 
    void Update()
    {

    }
    public void PositionAssign()
    {
        Door = this.DoorPosition.transform.position;
        DestroyPos = this.DestroyPosition.transform.position;
        positionTable01 = this.LocaTable01[NumTable01 - 1].transform.position;
        positionTable02 = this.LocaTable02[NumTable02 - 1].transform.position;
        positionTable03 = this.LocaTable03[NumTable03 - 1].transform.position;
        positionTable04 = this.LocaTable04[NumTable04 - 1].transform.position;
        positionTable05 = this.LocaTable05[NumTable05 - 1].transform.position;
        positionTable06 = this.LocaTable06[NumTable06 - 1].transform.position;
    }


    public void RouteSave()
    {
        for(int i =0; i < NumTable01; i++)
        {
            Table01Route[i] = this.LocaTable01[i].transform.position;
           // Debug.Log("��Ʈ 1�� "+ i + "��° ��ǥ�� : " + Table01Route[i]);
        }

        for (int i = 0; i < NumTable02; i++)
        {
            Table02Route[i] = this.LocaTable02[i].transform.position;
           // Debug.Log("��Ʈ 2�� " + i + "��° ��ǥ�� : " + Table02Route[i]);
        }

        for (int i = 0; i < NumTable03; i++)
        {
            Table03Route[i] = this.LocaTable03[i].transform.position;
           // Debug.Log("��Ʈ 3�� " + i + "��° ��ǥ�� : " + Table03Route[i]);
        }


        for (int i = 0; i < NumTable04; i++)
        {
            Table04Route[i] = this.LocaTable04[i].transform.position;
           // Debug.Log("��Ʈ 4�� " + i + "��° ��ǥ�� : " + Table04Route[i]);
        }

        for (int i = 0; i < NumTable05; i++)
        {
            Table05Route[i] = this.LocaTable05[i].transform.position;
          //  Debug.Log("��Ʈ 5�� " + i + "��° ��ǥ�� : " + Table05Route[i]);
        }

        for (int i = 0; i < NumTable06; i++)
        {
            Table06Route[i] = this.LocaTable06[i].transform.position;
          //  Debug.Log("��Ʈ 6�� " + i + "��° ��ǥ�� : " + Table06Route[i]);
        }

    }
}
