using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _Color_Select_Script : MonoBehaviour {

    public int colorSelect;
    //public List<Color> colorlist = new List<Color>();
    public List<Material> matList = new List<Material>();
    public List<string> matColors = new List<string>();
    string colorstring;
    int x = 5;
    //;

    
	// Use this for initialization
	void Start () {
        /*
        print(Color.white);
        colorlist.Add(Color.black);
        colorlist.Add(Color.blue);
        colorlist.Add(Color.red);
        colorlist.Add(Color.yellow);
        colorlist.Add(Color.gray);
        */
        setColor();
        
    }

    public void setColor()
    {
        int a = chooseNewColor();
        Renderer rend = GetComponent<Renderer>();
        rend.material = matList[a];
        matList.RemoveAt(a);
        colorstring = matColors[a];
        matColors.RemoveAt(a);

        /*
        rend.material.SetColor("_Color", colorlist[a]);

        colorstring = colorlist[a].ToString();
        if (colorstring.Equals("RGBA(0.000, 0.000, 0.000, 1.000)"))
        {
            colorstring = "Black";
        }
        else if (colorstring.Equals("RGBA(0.000, 0.000, 1.000, 1.000)"))
        {
            colorstring = "Blue";
        }
        else if (colorstring.Equals("RGBA(1.000, 0.000, 0.000, 1.000)"))
        {
            colorstring = "Red";
        }
        else if (colorstring.Equals("RGBA(1.000, 0.922, 0.016, 1.000)"))
        {
            colorstring = "Yellow";
        }
        else if (colorstring.Equals("RGBA(0.500, 0.500, 0.500, 1.000)"))
        {
            colorstring = "Gray";
        }
        
        colorlist.Remove(colorlist[a]);
        */
        gameObject.tag = colorstring;
        x--;
    }

    public int chooseNewColor()
    {
        colorSelect = Random.Range(0, x);
        return colorSelect;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
