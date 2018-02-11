using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoScreenController : MonoBehaviour {
    public Text infoTextBox;
    public string infoText;
    [SerializeField]
    string mobileText;
    public float letterRevealSpeed;
    private int lettersRevealed = 0;
    public Button continueButton;
    public string nextScreen;
    Timer revealTimer;
	// Use this for initialization
	public void Start () {
        infoTextBox.text = "";
        continueButton.gameObject.SetActive(false);

        if (Application.isMobilePlatform && mobileText.Length > 0) {
            infoText = mobileText;
        }

        revealTimer = new Timer(1 / letterRevealSpeed, infoText.Length);
        revealTimer.OnTick.AddListener(RevealLetter);
        revealTimer.OnComplete.AddListener(RevealButton);
        revealTimer.Start();
	}

    void RevealLetter() {
        lettersRevealed++;
        infoTextBox.text = infoText.Substring(0, Mathf.Min(lettersRevealed, infoText.Length));
    }

    private void Update()
    {
        TimerManager.Instance.Update(Time.deltaTime);
    }
    void RevealButton() {
        continueButton.gameObject.SetActive(true);
    }

    public void NextScreen()
    {
        SceneManager.LoadScene(nextScreen);
    }
}
