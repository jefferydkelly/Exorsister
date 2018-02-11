using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenController : MonoBehaviour {

    [SerializeField]
    Button quitButton;
    private void Awake()
    {
        if (Application.isMobilePlatform) {
            quitButton.gameObject.SetActive(false);
        }
    }
    public void Restart()
    {
		SceneManager.LoadScene("title");
	}

    public void Quit()
    {
        Application.Quit();
    }
}
