using UnityEngine;
using System.Collections;

public class CandlePlacement : MonoBehaviour {

    
    public GameObject test;
    // Use this for initialization
    void Start()
    {
        test = GameObject.FindGameObjectWithTag("Control");
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (gameObject.tag.Equals(other.gameObject.tag))
        {
            Destroy(other.gameObject);
            test.GetComponent<FinishScript>().increaseScore();

        }
    }


    // Update is called once per frame
    void Update()
    {

    }

}
