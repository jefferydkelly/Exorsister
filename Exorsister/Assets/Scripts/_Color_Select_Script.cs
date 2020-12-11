using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class _Color_Select_Script : MonoBehaviour {

    public int colorSelect;
    [SerializeField]
    List<CandleSprite> candleSprites;
    Image myImage;
    string colorstring;

    
	// Use this for initialization
	void Start () {

        myImage = GetComponent<Image>();
        setColor();
        
    }

    public void setColor()
    {
        CandleSprite newSprite = candleSprites.RandomElement();
        candleSprites.Remove(newSprite);
        myImage.sprite = newSprite.sprite;
        colorstring = newSprite.name;
       
        gameObject.tag = colorstring;
    }
}

[System.Serializable]
public struct CandleSprite
{
    public Sprite sprite;
    public string name;
}
