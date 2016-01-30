using UnityEngine;
using System.Collections;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif

public class StartMenuController : MonoBehaviour {
    public string FirstGame = "Fly Swatter";
	public void StartGame()
    {
#if UNITY_5_3
		SceneManager.LoadScene(FirstGame);
#else
		Application.LoadLevel(FirstGame);
#endif
	}

	public void QuitGame()
    {
        Application.Quit();
    }
}
