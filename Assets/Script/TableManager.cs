using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TableManager : MonoBehaviour
{
    
    public static bool isTablefull;
    public static bool isTable01Select;
    public static bool isTable02Select;
    public static bool isTable03Select;
    public static bool isTable04Select;
    public static bool isTable05Select;
    public static bool isTable06Select;

    public void Start()
    {
        TableManager.isTablefull = false;
        TableManager.isTable01Select = false;
        TableManager.isTable02Select = false;
        TableManager.isTable03Select = false;
        TableManager.isTable04Select = false;
        TableManager.isTable05Select = false;
        TableManager.isTable06Select = false;
    }

}
