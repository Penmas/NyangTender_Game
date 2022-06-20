using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CocktailPrice : MonoBehaviour
{
    // Start is called before the first frame update

    public Text[] Cocktail;
    void Start()
    {
        Cocktail[0].text = GameManager.PriceMiaojito.ToString();
        Cocktail[1].text = GameManager.PriceCatrose.ToString();
        Cocktail[2].text = GameManager.PriceSidecat.ToString();
        Cocktail[3].text = GameManager.PriceNyangtini.ToString();
        Cocktail[4].text = GameManager.PriceBlueRaccon.ToString();
        Cocktail[5].text = GameManager.PriceChurLibre.ToString();
    }

}
