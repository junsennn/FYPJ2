using UnityEngine;
using System.Collections;

public class ActivateTextLines : MonoBehaviour {

	public TextAsset thisText;

	public int startLine;
	public int endLine;

	public TextBoxManager manager;

	public bool requireBtnPress; // To click on a button to trigger text box
	private bool waitBtnPress;

	public bool destroyActivatedText;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waitBtnPress == true && Input.GetKeyDown (KeyCode.E)) {
			manager.ReloadScript (thisText);
			manager.currentLine = startLine;
			manager.endLine = endLine;
			manager.EnableTextBox ();

			if (destroyActivatedText == true) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider collide)
	{
		if (collide.name == "Player") {

			if (requireBtnPress == true) {
				waitBtnPress = true;
				return;
			}

			manager.ReloadScript (thisText);
			manager.currentLine = startLine;
			manager.endLine = endLine;
			manager.EnableTextBox ();

			if (destroyActivatedText == true) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerExit(Collider collide)
	{
		if (collide.name == "Player") {
			waitBtnPress = false;
		}
	}
}
