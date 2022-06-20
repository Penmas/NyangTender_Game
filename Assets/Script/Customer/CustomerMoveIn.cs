using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMoveIn : MonoBehaviour
{

    public Animator animator;
    public Collider2D coll;

    public Vector2 goTable01;
    public Vector2 goTable02;
    public Vector2 goTable03;
    public Vector2 goTable04;
    public Vector2 goTable05;
    public Vector2 goTable06;

    public int TableNumber;            //���̺� ��ȣ �ޱ�
    public int MyRouteNum;             //�� ��� ��ȣ ����
    public int RouteSequence = 0;            //���� ����
    public float speed = 50f;

    public Vector2 goTable;            //�̵��� ��ġ
    private Vector2 myPos;                    //�� ��ġ

    public bool isCustomerComeIn = true;
    public bool isCustomerIn = false;        //���Դ��� Ȯ��
    public bool isCustomerSit = false;       //�ɾҴ��� Ȯ��
    public bool isCustomerGoOut = false;     //�������� �ϴ� �������� Ȯ��
    public bool isCustomerMove = true;       //�����̴� �������� Ȯ��
    public bool isMyPosDoor = false;

    private float timer = 0;
    private float watingTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
        RouteSelect();
        animator = GetComponent<Animator>();
        isCustomerGoOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        myPosition();
        if (!DateManager.isDateExit)
        {
            
            
            if(!isCustomerGoOut)
            {
                MoveDoor();
                goTablePosition();
                MoveInCustomer();
                MoveSequenceControll();
            }          
                      

            if (isCustomerSit)
            {
                CustomerOrderOn();
                
            }
        }
        
        if(DateManager.isDateExit)
        {
            isCustomerGoOut = true;
        }
        

        if(isCustomerGoOut)
        {
            coll.enabled = false;
            timer += Time.deltaTime;

            if(DateManager.isDateExit)
            {
                TableSelectOut();
                MoveSequenceBackControll();

                if (!isMyPosDoor)
                {
                    goTableOutPosition();
                }
                else
                {
                    goTable01 = Location.DestroyPos;
                    goTable02 = Location.DestroyPos;
                    goTable03 = Location.DestroyPos;
                    goTable04 = Location.DestroyPos;
                    goTable05 = Location.DestroyPos;
                    goTable06 = Location.DestroyPos;
                }
                MoveOutCustomer();

                if (myPos == Location.DestroyPos)
                {
                    CustomerSpawn.CustomerGroundOutNum--;
                   // Debug.Log(CustomerSpawn.CustomerGroundOutNum);
                    Destroy(gameObject);

                }
            }
            else
            {
                if (timer >= watingTime)
                {
                    MoveSequenceBackControll();

                    if (!isMyPosDoor)
                    {
                        goTableOutPosition();
                    }
                    else
                    {
                        goTable01 = Location.DestroyPos;
                        goTable02 = Location.DestroyPos;
                        goTable03 = Location.DestroyPos;
                        goTable04 = Location.DestroyPos;
                        goTable05 = Location.DestroyPos;
                        goTable06 = Location.DestroyPos;
                    }
                    MoveOutCustomer();

                    if (myPos == Location.DestroyPos)
                    {
                        CustomerSpawn.CustomerGroundOutNum--;
                        Debug.Log(CustomerSpawn.CustomerGroundOutNum);
                        Destroy(gameObject);
                        
                    }
                }
            }
            
            
        }
    }

    public void myPosition()
    {
        myPos = transform.position;
    }

    public void MoveDoor()
    {
        //������ ���ϱ�
        if(isCustomerIn == false)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, Location.Door, speed * Time.deltaTime);
            
        }
        
        //������ ���ϱ� ����
        if(myPos == Location.Door)
        {
           // Debug.Log("������ ����");
            
            isCustomerIn = true;
        }
    }

    public void MoveInCustomer()
    {
        //��ο� ���� �̵���Ű�� (���� : �ɱ�X, ���� ����o, ������ ����x, �����̴� ����o)
        if(isCustomerSit == false && isCustomerIn == true && isCustomerGoOut == false && isCustomerMove == true)
        {         
            transform.position = Vector2.MoveTowards(gameObject.transform.position, goTable, speed * Time.deltaTime);
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y);
            /*if (this.transform.position.y < -0.5)
            {
                switch(TableNumber)
                {
                    case 4:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y);
                        break;
                    case 5:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.5f);
                        break;
                    case 6:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.2f);
                        break;
                }
                // transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.1f);
            }
            else
            {
                switch (TableNumber)
                {
                    case 1:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.4f);
                        break;
                    case 2:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
                        break;
                    case 3:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.2f);
                        break;
                    case 4:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
                        break;
                    case 5:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
                        break;
                    case 6:
                        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
                        break;
                }
            }*/
            
        }

        //�ڸ��� ������ �ڸ��� �ɴ� ���·� ����
        if(!GetComponent<CustomerOrder>().isOut)
        {
            switch (TableNumber)
            {
                case 1:
                    if (myPos == Location.positionTable01)
                    {
                        Location.isTable01Sit = true;
                        isCustomerSit = true;
                        //Debug.Log("�ڸ��� ����");
                        animator.SetBool("isSit", true);
                        //RouteSequence = 0;
                    }
                    break;
                case 2:
                    if (myPos == Location.positionTable02)
                    {
                        Location.isTable02Sit = true;
                        isCustomerSit = true;
                        //Debug.Log("�ڸ��� ����");
                        animator.SetBool("isSit", true);
                        //RouteSequence = 0;
                    }
                    break;
                case 3:
                    if (myPos == Location.positionTable03)
                    {
                        Location.isTable03Sit = true;
                        isCustomerSit = true;
                        //Debug.Log("�ڸ��� ����");
                        animator.SetBool("isSit", true);
                        //RouteSequence = 0;
                    }
                    break;
                case 4:
                    if (myPos == Location.positionTable04)
                    {
                        Location.isTable04Sit = true;
                        isCustomerSit = true;
                        //Debug.Log("�ڸ��� ����");
                        animator.SetBool("isSit", true);
                        //RouteSequence = 0;
                    }
                    break;
                case 5:
                    if (myPos == Location.positionTable05)
                    {
                        Location.isTable05Sit = true;
                        isCustomerSit = true;
                        //Debug.Log("�ڸ��� ����");
                        animator.SetBool("isSit", true);
                        //RouteSequence = 0;
                    }
                    break;
                case 6:
                    if (myPos == Location.positionTable06)
                    {
                        Location.isTable06Sit = true;
                        isCustomerSit = true;
                        //Debug.Log("�ڸ��� ����");
                        animator.SetBool("isSit", true);
                        //RouteSequence = 0;
                    }
                    break;
            }
        }
        
    }


    public void MoveSequenceControll() //�����̴� ��� ������� �����ϱ�
    {
        switch (TableNumber)
        {
            case 1:
                goTable = goTable01;

                if (RouteSequence >= MyRouteNum)
                {
                    Location.isTable01Sit = true;
                   // Debug.Log("sit");
                }

                if (myPos == goTable && isCustomerSit == false && RouteSequence <= MyRouteNum)
                {
                    RouteSequence++;
                   // Debug.Log("����");
                }
                break;
            case 2:
                goTable = goTable02;

                if (RouteSequence >= MyRouteNum)
                {
                    Location.isTable02Sit = true;
                }

                if (myPos == goTable && isCustomerSit == false && RouteSequence <= MyRouteNum)
                {
                    RouteSequence++;
                   // Debug.Log("����");
                }
                break;
            case 3:
                goTable = goTable03;

                if (RouteSequence >= MyRouteNum)
                {
                    Location.isTable03Sit = true;
                }

                if (myPos == goTable && isCustomerSit == false && RouteSequence <= MyRouteNum)
                {
                    RouteSequence++;
                   // Debug.Log("����");
                }
                break;
            case 4:
                goTable = goTable04;

                if (RouteSequence >= MyRouteNum)
                {
                    Location.isTable04Sit = true;
                }

                if (myPos == goTable && isCustomerSit == false && RouteSequence <= MyRouteNum)
                {
                    RouteSequence++;
                    //Debug.Log("����");
                }
                break;
            case 5:
                goTable = goTable05;

                if (RouteSequence >= MyRouteNum)
                {
                    Location.isTable05Sit = true;
                }

                if (myPos == goTable && isCustomerSit == false && RouteSequence <= MyRouteNum)
                {
                    RouteSequence++;
                   // Debug.Log("����");
                }
                break;
            case 6:
                goTable = goTable06;

                if (RouteSequence >= MyRouteNum)
                {
                    Location.isTable06Sit = true;
                }

                if (myPos == goTable && isCustomerSit == false && RouteSequence <= MyRouteNum)
                {
                    RouteSequence++;
                   // Debug.Log("����");
                }
                break;
        }
    }

    public void RouteSelect()
    {
        //�̵��ϴ� ��Ʈ ����
        if (TableManager.isTable01Select == false)
        {
            TableNumber = 1;
            TableManager.isTable01Select = true;
            gameObject.tag = "TableFirst";
            //Debug.Log("ù��° ���̺� ����");
        }
        else if (TableManager.isTable02Select == false)
        {
            TableNumber = 2;
            TableManager.isTable02Select = true;
            gameObject.tag = "TableSecond";
           // Debug.Log("�ι�° ���̺� ����");
        }
        else if (TableManager.isTable03Select == false)
        {
            TableNumber = 3;
            TableManager.isTable03Select = true;
            gameObject.tag = "TableThird";
           // Debug.Log("����° ���̺� ����");
        }
        else if (TableManager.isTable04Select == false)
        {
            TableNumber = 4;
            TableManager.isTable04Select = true;
            gameObject.tag = "TableFouth";
           // Debug.Log("�׹�° ���̺� ����");
        }
        else if (TableManager.isTable05Select == false)
        {
            TableNumber = 5;
            TableManager.isTable05Select = true;
            gameObject.tag = "TableFifth";
            //Debug.Log("�ټ���° ���̺� ����");
        }
        else if (TableManager.isTable06Select == false)
        {
            TableNumber = 6;
            TableManager.isTable06Select = true;
            gameObject.tag = "TableSixth";
            //Debug.Log("������° ���̺� ����");
        }


        switch (TableNumber)
        {
            case 1:
                MyRouteNum = Location.NumTable01;
                break;
            case 2:
                MyRouteNum = Location.NumTable02;
                break;
            case 3:
                MyRouteNum = Location.NumTable03;
                break;
            case 4:
                MyRouteNum = Location.NumTable04;
                break;
            case 5:
                MyRouteNum = Location.NumTable05;
                break;
            case 6:
                MyRouteNum = Location.NumTable06;
                break;
        }
    }

    public void goTablePosition()
    {
        if (TableNumber == 1)
        {
            Vector2 position01 = Location.Table01Route[RouteSequence];
            goTable01 = position01;
        }

        if (TableNumber == 2)
        {
            Vector2 position02 = Location.Table02Route[RouteSequence];
            goTable02 = position02;
        }

        if (TableNumber == 3)
        {
            Vector2 position03 = Location.Table03Route[RouteSequence];
            goTable03 = position03;
        }

        if (TableNumber == 4)
        {
            Vector2 position04 = Location.Table04Route[RouteSequence];
            goTable04 = position04;
        }

        if (TableNumber == 5)
        {
            Vector2 position05 = Location.Table05Route[RouteSequence];
            goTable05 = position05;
        }

        if (TableNumber == 6)
        {
            Vector2 position06 = Location.Table06Route[RouteSequence];
            goTable06 = position06;
        }

    }

    void CustomerOrderOn()
    {
        coll.enabled = true;
    }






    //������
    public void MoveOutCustomer()
    {
        //��ο� ���� �̵���Ű�� (���� : �ɱ�X, ���� ����o, ������ ����x, �����̴� ����o)s
        transform.position = Vector2.MoveTowards(gameObject.transform.position, goTable, speed * Time.deltaTime);
        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y);

        /* if (this.transform.position.y < -0.5)
         {
             switch (TableNumber)
             {
                 case 4:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.8f);
                     break;
                 case 5:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.5f);
                     break;
                 case 6:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.2f);
                     break;
             }

         }
         else
         {
             switch (TableNumber)
             {
                 case 1:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.4f);
                     break;
                 case 2:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
                     break;
                 case 3:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.2f);
                     break;
                 case 4:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
                     break;
                 case 5:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
                     break;
                 case 6:
                     transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
                     break;
             }
         }*/
        animator.SetBool("isSit", false);


    }
    public void MoveSequenceBackControll() //�����̴� ��� ������� �����ϱ�
    {
        switch (TableNumber)
        {
            case 1:
                goTable = goTable01;

                if (myPos == goTable && RouteSequence >= 0)
                {
                    RouteSequence--;
                    //Debug.Log("����");
                }
                break;
            case 2:
                goTable = goTable02;


                if (myPos == goTable && RouteSequence >= 0)
                {
                    RouteSequence--;
                    //Debug.Log("����");
                }
                break;
            case 3:
                goTable = goTable03;


                if (myPos == goTable && RouteSequence >= 0)
                {
                    RouteSequence--;
                    //Debug.Log("����");
                }
                break;
            case 4:
                goTable = goTable04;

                if (myPos == goTable && RouteSequence >= 0)
                {
                    RouteSequence--;
                    //Debug.Log("����");
                }
                break;
            case 5:
                goTable = goTable05;


                if (myPos == goTable && RouteSequence >= 0)
                {
                    RouteSequence--;
                   // Debug.Log("����");
                }
                break;
            case 6:
                goTable = goTable06;

                if (myPos == goTable && RouteSequence >= 0)
                {
                    RouteSequence--;
                   // Debug.Log("����");
                }
                break;
        }
    }

    public void goTableOutPosition()
    {
        if (TableNumber == 1)
        {
            if(RouteSequence >= 0)
            {
                Vector2 position01 = Location.Table01Route[RouteSequence];
                goTable01 = position01;
            }
            else
            {
                goTable01 = Location.Door;
            }
        }

        if (TableNumber == 2)
        {
            if (RouteSequence >= 0)
            {
                Vector2 position02 = Location.Table02Route[RouteSequence];
                goTable02 = position02;
            }
            else
            {
                goTable02 = Location.Door;
            }
        }

        if (TableNumber == 3)
        {
            if (RouteSequence >= 0)
            {
                Vector2 position03 = Location.Table03Route[RouteSequence];
                goTable03 = position03;
            }
            else
            {
                goTable03 = Location.Door;
            }
        }

        if (TableNumber == 4)
        {
            if (RouteSequence >= 0)
            {
                Vector2 position04 = Location.Table04Route[RouteSequence];
                goTable04 = position04;
            }
            else
            {
                goTable04 = Location.Door;
            }
        }

        if (TableNumber == 5)
        {
            if (RouteSequence >= 0)
            {
                Vector2 position05 = Location.Table05Route[RouteSequence];
                goTable05 = position05;
            }
            else
            {
                goTable05 = Location.Door;
            }

        }

        if (TableNumber == 6)
        {
            if (RouteSequence >= 0)
            {
                Vector2 position06 = Location.Table06Route[RouteSequence];
                goTable06 = position06;
            }
            else
            {
                goTable06 = Location.Door;
            }
        }


        if(myPos == Location.Door)
        {
            isMyPosDoor = true;
            //goTable = Location.DestroyPos; 
        }
    }


    public void TableSelectOut()
    {
        switch (TableNumber)
        {
            case 1:
                TableManager.isTable01Select = false;
                break;
            case 2:
                TableManager.isTable02Select = false;
                break;
            case 3:
                TableManager.isTable03Select = false;
                break;
            case 4:
                TableManager.isTable04Select = false;
                break;
            case 5:
                TableManager.isTable05Select = false;
                break;
            case 6:
                TableManager.isTable06Select = false;
                break;
        }
    }
}
