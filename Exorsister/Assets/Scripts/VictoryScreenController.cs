using UnityEngine;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif

using System.Collections;

public class VictoryScreenController : MonoBehaviour {
    public void NextJob()
    {
#if UNITY_5_3
		SceneManager.LoadScene("title");
#else
		Application.LoadLevel("title");
#endif
	}

	public void Quit()
    {
        Application.Quit();
    }
}
