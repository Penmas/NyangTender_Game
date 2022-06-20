using System;
using UnityEngine;

public class CocktailDrag : MonoBehaviour/*, IDragHandler, IBeginDragHandler, IEndDragHandler*/
{
    public Vector2 myMouse;
    private bool isServing;
    private bool isTrashCanIn;
    private Collider2D coll;

    public static bool isTableFirstIn;
    public static bool isTableSecondIn;
    public static bool isTableThirdIn;
    public static bool isTableFouthIn;
    public static bool isTableFifthIn;
    public static bool isTableSixthIn;

    private void Update()
    {
        if(DateManager.isDateExit)
        {
            Destroy(this.gameObject);
            CocktailSpawn.isCoktailOut = false;
            
        }
    }
    private void OnMouseDrag()
    {
        //Debug.Log("클릭중");
        myMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(myMouse.x, myMouse.y, -5);
        
    }

    public void OnMouseUp()
    {
        Vector2 myPosition = new Vector2(1.1f, 2.3f);
        //Debug.Log("클릭뗌");
       //Debug.Log(myPosition);
        if (!isServing)
        {
            transform.position = myPosition;
        }
        else
        {
            CocktailSpawn.isCoktailOut = false;
            CocktailManager.isCocktailIn = true;
            Destroy(this.gameObject,0.001f);
            
        }

        if (isTrashCanIn)
        {
            CocktailSpawn.isCoktailOut = false;
            Destroy(this.gameObject, 0.001f);
            
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "TableFirst")
        {
          //  Debug.Log("첫번째 테이블에 서빙 중");
            isTableFirstIn = true;
            isTableSecondIn = false;
            isTableThirdIn = false;
            isTableFouthIn = false;
            isTableFifthIn = false;
            isTableSixthIn = false;
            isServing = true;
        }
        if (collider.gameObject.tag == "TableSecond")
        {
         //   Debug.Log("두번째 테이블에 서빙 중");
            isTableSecondIn = true;
            isTableFirstIn = false;
            isTableThirdIn = false;
            isTableFouthIn = false;
            isTableFifthIn = false;
            isTableSixthIn = false;
            isServing = true;
        }
        if (collider.gameObject.tag == "TableThird")
        {
          //  Debug.Log("세번째 테이블에 서빙 중");
            isTableThirdIn = true;
            isTableFirstIn = false;
            isTableSecondIn = false;
            isTableFouthIn = false;
            isTableFifthIn = false;
            isTableSixthIn = false;
            isServing = true;
        }
        if (collider.gameObject.tag == "TableFouth")
        {
           // Debug.Log("네번째 테이블에 서빙 중");
            isTableFouthIn = true;
            isTableFirstIn = false;
            isTableSecondIn = false;
            isTableThirdIn = false;
            isTableFifthIn = false;
            isTableSixthIn = false;
            isServing = true;
        }
        if (collider.gameObject.tag == "TableFifth")
        {
           // Debug.Log("다섯번째 테이블에 서빙 중");
            isTableFifthIn = true;
            isTableFirstIn = false;
            isTableSecondIn = false;
            isTableThirdIn = false;
            isTableFouthIn = false;
            isTableSixthIn = false;
            isServing = true;
        }
        if (collider.gameObject.tag == "TableSixth")
        {
           // Debug.Log("여섯번째 테이블에 서빙 중");
            isTableSixthIn = true;
            isTableFirstIn = false;
            isTableSecondIn = false;
            isTableThirdIn = false;
            isTableFouthIn = false;
            isTableFifthIn = false;
            isServing = true;
        }

        if (collider.gameObject.tag == "TrashCan")
        {
           // Debug.Log("쓰레기 통에 버림");
            isTrashCanIn = true;
            isTableFirstIn = false;
            isTableSecondIn = false;
            isTableThirdIn = false;
            isTableFouthIn = false;
            isTableFifthIn = false;
            isTableSixthIn = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Invoke("CocktailReset", 0.001f);
        CocktailReset();
        //Debug.Log("벗어남");
    }

    void CocktailReset()
    {
        CocktailSpawn.isCoktailOut = false;
        isTableFirstIn = false;
        isTableSecondIn = false;
        isTableThirdIn = false;
        isTableFouthIn = false;
        isTableFifthIn = false;
        isTableSixthIn = false;
        isServing = false;
        isTrashCanIn = false;
        //Debug.Log("칵테일 서빙 테이블 리셋");
    }
}
