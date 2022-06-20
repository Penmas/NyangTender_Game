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
        //Debug.Log("Ŭ����");
        myMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(myMouse.x, myMouse.y, -5);
        
    }

    public void OnMouseUp()
    {
        Vector2 myPosition = new Vector2(1.1f, 2.3f);
        //Debug.Log("Ŭ����");
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
          //  Debug.Log("ù��° ���̺� ���� ��");
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
         //   Debug.Log("�ι�° ���̺� ���� ��");
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
          //  Debug.Log("����° ���̺� ���� ��");
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
           // Debug.Log("�׹�° ���̺� ���� ��");
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
           // Debug.Log("�ټ���° ���̺� ���� ��");
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
           // Debug.Log("������° ���̺� ���� ��");
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
           // Debug.Log("������ �뿡 ����");
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
        //Debug.Log("���");
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
        //Debug.Log("Ĭ���� ���� ���̺� ����");
    }
}
