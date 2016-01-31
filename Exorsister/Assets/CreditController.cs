using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
#if UNITY_5_3
        SceneManager.LoadScene("ThuribleInfo");

#else
        Application.LoadLevel("ThuribleInfo");
#endif
    }
}
