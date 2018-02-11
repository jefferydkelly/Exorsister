using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour {
    public string FirstGame = "Fly Swatter";
    [SerializeField]
    Button quitButton;

    private void Awake()
    {
        if (Application.isMobilePlatform) {
            quitButton.gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
		SceneManager.LoadScene(FirstGame);
	}

	public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
