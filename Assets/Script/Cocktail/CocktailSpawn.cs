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
           // Debug.Log("술 나타가기 실행");
 
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
           // Debug.Log("칵테일 스폰 : " + WhatKindCocktail);
            switch (WhatKindCocktail)
            {
                case 0:
                    Instantiate(Cocktail[0], spawnPosition);                  
                   // Debug.Log("묘히토 생성");
                    isCoktailOut = true;
                    WhatKindCocktail = -1;
                    break;
                case 1:
                    Instantiate(Cocktail[1], spawnPosition);
                    isCoktailOut = true;
                   // Debug.Log("캣로즈 생성");
                    WhatKindCocktail = -1;
                    break;
                case 2:
                    Instantiate(Cocktail[2], spawnPosition);
                    isCoktailOut = true;
                   // Debug.Log("사이드캣 생성");
                    WhatKindCocktail = -1;
                    break;
                case 3:
                    Instantiate(Cocktail[3], spawnPosition);
                    isCoktailOut = true;
                    //Debug.Log("냥티니 생성");
                    WhatKindCocktail = -1;
                    break;
                case 4:
                    Instantiate(Cocktail[4], spawnPosition);
                    isCoktailOut = true;
                    //Debug.Log("블루라쿤 생성");
                    WhatKindCocktail = -1;
                    break;
                case 5:
                    Instantiate(Cocktail[5], spawnPosition);
                    isCoktailOut = true;
                    //Debug.Log("츄르 리브레 생성");
                    WhatKindCocktail = -1;
                    break;
                case 6:
                    Instantiate(Cocktail[6], spawnPosition);
                    isCoktailOut = true;
                   // Debug.Log("엉망진창인 술 생성");
                    WhatKindCocktail = -1;
                    break;

            }
        }
        else
        {
           // Debug.Log("이미 칵테일이 완성되어 있어, 칵테일을 만들 수 없습니다.");
            WhatKindCocktail = -1;
        }
    }

    public void FindCocktail()
    {
        //Debug.Log("술찾기 실행");
        for(int i = 0; i < 6; i++)
        {
            if(makeCocktail.WhatCocktail[i] == true)
            {
                WhatKindCocktail = i;
                //Debug.Log("술 종류 : " + (i + 1));
            }
            else if(makeCocktail.isMess)
            {
                WhatKindCocktail = 6;
                CocktailComplete = true;
                makeCocktail.isMess = false;
               // Debug.Log("엉망진창 술임");
            }
        }
    }

}
