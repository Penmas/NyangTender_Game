using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocktailSpawn : MonoBehaviour
{
    public Transform CocktailBarSpace;
    public GameObject[] Cocktail;
    public Transform spawnPosition;

    public int WhatKindCocktail = -1;
    public static bool CocktailComplete = false;
    public static bool isCoktailOut = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject MyCocktail = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(CocktailComplete)
        {
            CocktailComplete = false;
            FindCocktail();
           // Debug.Log("�� ��Ÿ���� ����");
 
        }

        if(makeCocktail.CocktailSpwanStart)
        {
            spawnCocktail();
            makeCocktail.CocktailSpwanStart = false;
        }
    }



    public void spawnCocktail()
    {
        spawnPosition = CocktailBarSpace ;
        if(!isCoktailOut)
        {
           // Debug.Log("Ĭ���� ���� : " + WhatKindCocktail);
            switch (WhatKindCocktail)
            {
                case 0:
                    Instantiate(Cocktail[0], spawnPosition);                  
                   // Debug.Log("������ ����");
                    isCoktailOut = true;
                    WhatKindCocktail = -1;
                    break;
                case 1:
                    Instantiate(Cocktail[1], spawnPosition);
                    isCoktailOut = true;
                   // Debug.Log("Ĺ���� ����");
                    WhatKindCocktail = -1;
                    break;
                case 2:
                    Instantiate(Cocktail[2], spawnPosition);
                    isCoktailOut = true;
                   // Debug.Log("���̵�Ĺ ����");
                    WhatKindCocktail = -1;
                    break;
                case 3:
                    Instantiate(Cocktail[3], spawnPosition);
                    isCoktailOut = true;
                    //Debug.Log("��Ƽ�� ����");
                    WhatKindCocktail = -1;
                    break;
                case 4:
                    Instantiate(Cocktail[4], spawnPosition);
                    isCoktailOut = true;
                    //Debug.Log("������ ����");
                    WhatKindCocktail = -1;
                    break;
                case 5:
                    Instantiate(Cocktail[5], spawnPosition);
                    isCoktailOut = true;
                    //Debug.Log("�� ���극 ����");
                    WhatKindCocktail = -1;
                    break;
                case 6:
                    Instantiate(Cocktail[6], spawnPosition);
                    isCoktailOut = true;
                   // Debug.Log("������â�� �� ����");
                    WhatKindCocktail = -1;
                    break;

            }
        }
        else
        {
           // Debug.Log("�̹� Ĭ������ �ϼ��Ǿ� �־�, Ĭ������ ���� �� �����ϴ�.");
            WhatKindCocktail = -1;
        }
    }

    public void FindCocktail()
    {
        //Debug.Log("��ã�� ����");
        for(int i = 0; i < 6; i++)
        {
            if(makeCocktail.WhatCocktail[i] == true)
            {
                WhatKindCocktail = i;
                //Debug.Log("�� ���� : " + (i + 1));
            }
            else if(makeCocktail.isMess)
            {
                WhatKindCocktail = 6;
                CocktailComplete = true;
                makeCocktail.isMess = false;
               // Debug.Log("������â ����");
            }
        }
    }

}
