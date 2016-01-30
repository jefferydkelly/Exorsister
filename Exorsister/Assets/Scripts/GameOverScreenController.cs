using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour {

	public void Restart()
    {
        SceneManager.LoadScene("title");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
