using UnityEngine;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif
using System.Collections;

public class MinigameController : MonoBehaviour {

    bool gameOver;//default is false. If player gets 2 Poor scores, it is game over
    int badBoyPoints;//every time the player gets poor scores this will increase. If it reaches 0 the game is over.
    public Vector3 mousePos;//getting the position of the mouse at the current moment.

    public string nextScene;

    void Update()
    {
        //things will loop until player gets to end of game, BBP = 2, or they fail the final mission
        mousePos = (Input.mousePosition);//setting the position of the mouse equal to the vector. (mainly need the x and y. z is not as important)
        gameOver = false;
        badBoyPoints = 0;
    }

    public void Win()
    {
		//SceneManager.LoadScene(nextScene);
#if UNITY_5_3
		SceneManager.LoadScene("Win Screen");
#else
		Application.LoadLevel("Win Screen");
#endif
	}

	public void Lose()
    {
#if UNITY_5_3
		SceneManager.LoadScene("Game Over");
#else
		Application.LoadLevel("Game Over");
#endif
	}
}
