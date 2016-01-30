using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour {
    public string FirstGame = "Fly Swatter";
	public void StartGame()
    {
        SceneManager.LoadScene(FirstGame);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
