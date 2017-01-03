using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	public AudioSource sound;
	private Button button;

	// Use this for initialization
	void Start () {
		sound.playOnAwake = false;
		button.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {

		sound.Play ();
	}
		
}
