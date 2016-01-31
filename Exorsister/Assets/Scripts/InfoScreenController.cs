using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif

public class InfoScreenController : MonoBehaviour {
    public Text infoTextBox;
    public string infoText;
    public float letterRevealSpeed;
    private int lettersRevealed = 0;
    private bool completelyRevealed = false;
    private float timePassed = 0;
    public Button continueButton;
    public string nextScreen;
	// Use this for initialization
	void Start () {
        infoTextBox.text = "";
        Debug.Log("Starting");
        continueButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!completelyRevealed)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= 1 / letterRevealSpeed)
            {
                lettersRevealed++;
                timePassed -= (1 / letterRevealSpeed);
                infoTextBox.text = infoText.Substring(0, lettersRevealed);
                completelyRevealed = (lettersRevealed == infoText.ToCharArray().Length);

                if (completelyRevealed)
                {
                    continueButton.gameObject.SetActive(true);
                }
            }
            
        }
	}

    public void NextScreen()
    {
        #if UNITY_5_3
        SceneManager.LoadScene(nextScreen);
        #else
        Application.LoadLevel(nextScreen);

        #endif
    }
}
