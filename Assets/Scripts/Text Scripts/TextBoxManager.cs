using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

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
				if (currentLine > endLine) {
					DisableTextBox ();
				} else {
					StartCoroutine (TextScroll (textLines[currentLine]));
				}
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

	public void EnableTextBox()
	{
		textBox.SetActive (true);

		stopPlayer = true;

		if (stopPlayer == true) {
			player.canMove = false;
		}

		isActive = true;

		StartCoroutine (TextScroll (textLines[currentLine]));
	}

	public void DisableTextBox()
	{
		textBox.SetActive (false);
		isActive = false;
		player.canMove = true;
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
