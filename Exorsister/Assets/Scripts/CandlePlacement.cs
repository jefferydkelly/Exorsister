using UnityEngine;
using System.Collections;

public class CandlePlacement : MonoBehaviour {

    
    public GameObject test;
    public GameObject colorBox;
    // Use this for initialization
    void Start()
    {
        test = GameObject.FindGameObjectWithTag("Control");
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if ((gameObject.tag.Equals(other.gameObject.tag)) && (gameObject.tag.Equals(colorBox.tag)))
        {
            Destroy(other.gameObject);
            test.GetComponent<FinishScript>().increaseScore();
            colorBox.GetComponent<_Color_Select_Script>().setColor();
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

}
