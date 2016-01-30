using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MinigameController : MonoBehaviour {

    public string nextScene;

    public void Win()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void Lose()
    {
        SceneManager.LoadScene("Game Over");
    }
}
