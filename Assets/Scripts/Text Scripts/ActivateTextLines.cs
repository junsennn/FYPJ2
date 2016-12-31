using UnityEngine;
using System.Collections;

public class ActivateTextLines : MonoBehaviour {

	public TextAsset thisText;

	public int startLine;
	public int endLine;

	public TextBoxManager manager;

	public bool destroyActivatedText;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collide)
	{
		if (collide.name == "Player") {
			manager.ReloadScript (thisText);
			manager.currentLine = startLine;
			manager.endLine = endLine;
			manager.EnableTextBox ();

			if (destroyActivatedText == true) {
				Destroy (gameObject);
			}
		}
	}
}
