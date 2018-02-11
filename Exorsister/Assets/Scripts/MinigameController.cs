using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour {

    [SerializeField]
    int timeLimit = 15;
    protected Timer gameTimer;
    [SerializeField]
    Text timeText;
    bool gameOver;//default is false. If player gets 2 Poor scores, it is game over
    int badBoyPoints;//every time the player gets poor scores this will increase. If it reaches 0 the game is over.
    public Vector3 mousePos;//getting the position of the mouse at the current moment.

    public string nextScene;

    public void Start()
    {
        EventManager.StartListening("GameOver", Lose);
        EventManager.StartListening("Win", Win);
        gameTimer = new Timer(1, timeLimit);
        gameTimer.OnTick.AddListener(() => {
            timeLimit--;
            timeText.text = string.Format("Time Remaining: {0}", timeLimit);
        });

        timeText.text = string.Format("Time Remaining: {0}", timeLimit);
        gameTimer.Start();
    }

    void Update()
    {
        //things will loop until player gets to end of game, BBP = 2, or they fail the final mission
        mousePos = (Input.mousePosition);//setting the position of the mouse equal to the vector. (mainly need the x and y. z is not as important)
        gameOver = false;
        badBoyPoints = 0;

        TimerManager.Instance.Update(Time.deltaTime);
    }

    public void Win()
    {
		SceneManager.LoadScene(nextScene);
	}

	public void Lose()
    {
		SceneManager.LoadScene("Game Over");
	}

    public void OnDisable()
    {
        EventManager.StopListening("GameOver", Lose);
        EventManager.StopListening("Win", Win);
        TimerManager.Instance.RemoveTimer(gameTimer);
    }
}
