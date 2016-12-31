using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text thisText; // Get the text in the box

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine; // Get the line the text is at
	public int endLine;

	public FirstPersonCameraControl player;

	public bool isActive;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<FirstPersonCameraControl>();

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

		thisText.text = textLines [currentLine];

		// Press 'Enter' key to move on to the next text
		if (Input.GetKeyDown (KeyCode.Return)) {
			currentLine += 1;
		}

		// After the last line of the text, text box will deactivate
		if (currentLine > endLine) {
			DisableTextBox ();
		}
	}

	public void EnableTextBox()
	{
		textBox.SetActive (true);
		isActive = true;
	}

	public void DisableTextBox()
	{
		textBox.SetActive (false);
		isActive = false;
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
