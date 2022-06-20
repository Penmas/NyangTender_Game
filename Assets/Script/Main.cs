using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject Recipe;
    public GameObject Cocktail;
    // Start is called before the first frame update
    void Start()
    {
        Cocktail.SetActive(false);
        Recipe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
