using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
	public Transform player;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        canvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PauseMenu ();
		}
	}

	public void PauseMenu(){
		if (canvas.gameObject.activeInHierarchy == false)
        {
			canvas.gameObject.SetActive (true);
			//Time.timeScale = 0;
			player.GetComponent<FirstPersonController> ().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

            for (int i = 1; i < 4; i++)
            {
                canvas.gameObject.transform.GetChild(i).GetComponent<Button>().enabled = true;
                canvas.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
		}
        else
        {
			canvas.gameObject.SetActive (false);
			//Time.timeScale = 1;
			player.GetComponent<FirstPersonController> ().enabled = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	public void RetryTownLevel1()
	{
		SceneManager.LoadScene("TownLevel", LoadSceneMode.Single);
	}

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
