using UnityEngine;
using System.Collections;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif

public class GameOverScreenController : MonoBehaviour {

	public void Restart()
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
