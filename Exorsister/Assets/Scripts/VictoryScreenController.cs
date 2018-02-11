using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class VictoryScreenController : MonoBehaviour {
    public void NextJob()
    {
        
	}

	public void Quit()
    {
		if (Application.isMobilePlatform)
		{
            SceneManager.LoadScene("title");
		}
		else
		{
			Application.Quit();
		}
    }
}
