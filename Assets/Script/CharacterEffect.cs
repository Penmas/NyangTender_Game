using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HappyEffect;
    public GameObject SadEffect;

    public SpriteRenderer HappySpRender;
    public SpriteRenderer SadSpRender;


    public float HappySequen;
    public float SadSequen;

    public bool isFadeStart;

    void Start()
    {
        HappySpRender.color = new Color(255, 255, 255, 0);
        SadSpRender.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator _typingWaiting()
    {
        isFadeStart = false;
        yield return new WaitForSeconds(0.1f);
        isFadeStart = true;
        yield return null;
    }
}
