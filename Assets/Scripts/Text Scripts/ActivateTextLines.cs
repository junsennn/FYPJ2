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

	public bool isEnded;

	public AudioSource sound;

    public bool LoadSceneWhenEnd = false;

    public string sceneName = "";

    public float TimeTillLoad = 0.0f;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waitBtnPress == true && Input.GetKeyDown (KeyCode.E)) {

            manager.InitTextBox(thisText, startLine, endLine, LoadSceneWhenEnd, sceneName , TimeTillLoad);

			sound.Play ();

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

            manager.InitTextBox(thisText, startLine, endLine, LoadSceneWhenEnd, sceneName , TimeTillLoad);

            if (destroyActivatedText == true) {
				Destroy (gameObject);
			}

			isEnded = true;
		}
	}

	void OnTriggerExit(Collider collide)
	{
		if (collide.name == "Player") {
			waitBtnPress = false;
		}
	}
}
