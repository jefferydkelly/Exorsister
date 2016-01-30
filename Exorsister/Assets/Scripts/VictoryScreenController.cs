using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VictoryScreenController : MonoBehaviour {
    public void NextJob()
    {
        SceneManager.LoadScene("title");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
