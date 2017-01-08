using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PauseMenu ();
		}
	}

	public void PauseMenu(){
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			//Time.timeScale = 0;
			player.GetComponent<FirstPersonController> ().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

		} else {
			canvas.gameObject.SetActive (false);
			//Time.timeScale = 1;
			player.GetComponent<FirstPersonController> ().enabled = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}
