using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text thisText; // Get the text in the box

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine; // Get the line the text is at
	public int endLine;

	public FirstPersonController player;

	public bool isActive;

	// For Autotyping text
	private bool isTyping = false;
	private bool cancelTyping = false;

	public float typeSpeed;

	// To stop the player from moving
	public bool stopPlayer;

	// Sound for dialogueBox
	public AudioSource popUpSound;
	public AudioSource textClick;

    public bool LoadSceneWhenDone = false;
    public string sceneName = "";

    public float timeDur = 0.0f;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<FirstPersonController>();

		if (textFile != null) {
			// Get the textLines arrays, where the texts are entered in a new line
			textLines = (textFile.text.Split ('\n'));
		}

		if (endLine == 0) {
			endLine = textLines.Length - 1;
		}

		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
	}

	void Update() {

		if (!isActive) {
			return;
		}

		//thisText.text = textLines [currentLine];

		// Press 'Enter' key to move on to the next text
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (isTyping == false) 
			{
				currentLine += 1;
			
				// After the last line of the text, text box will deactivate
				if (currentLine > endLine)
                {
                    if (LoadSceneWhenDone)
                        StartCoroutine(LoadScene());

                    DisableTextBox ();

				} else {
					StartCoroutine (TextScroll (textLines[currentLine]));
				}

				textClick.Play ();
			} 
			else if (isTyping == true && cancelTyping == false)
			{
				cancelTyping = true;
			}
		}
	}

	private IEnumerator TextScroll (string lineText)
	{
		int letter = 0;
		thisText.text = "";
		isTyping = true;
		cancelTyping = false;
		while (isTyping == true && cancelTyping == false && (letter < lineText.Length - 1)) 
		{
			thisText.text += lineText [letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}
		thisText.text = lineText;
		isTyping = false;
		cancelTyping = false;
	}

    private IEnumerator LoadScene()
    {
        float timer = timeDur;
        while (timer > 0)
        {
            timer -= Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }
        
        SceneManager.LoadScene(sceneName);

    }

    public void InitTextBox(TextAsset text, int start, int end , bool load , string scene , float time)
    {
        ReloadScript(text);
        currentLine = start;
        endLine = end;
        LoadSceneWhenDone = load;
        sceneName = scene;
        timeDur = time;
        EnableTextBox();
    }

	public void EnableTextBox()
	{
		textBox.SetActive (true);

		//stopPlayer = true;

	//	if (stopPlayer == true) {
	//		player.canMove = false;
	//	}

		player.GetComponent<FirstPersonController> ().enabled = false;

		isActive = true;

		popUpSound.Play ();

		StartCoroutine (TextScroll (textLines[currentLine]));
	}

	public void DisableTextBox()
	{
		textBox.SetActive (false);
		isActive = false;
		//player.canMove = true;
		player.GetComponent<FirstPersonController> ().enabled = true;
	}

	public void ReloadScript(TextAsset thisText)
	{
		if (thisText != null) {
			textLines = new string[1];
			// Get the textLines arrays, where the texts are entered in a new line
			textLines = (thisText.text.Split ('\n'));
		}
	}
}
