using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckLevel : MonoBehaviour {

    int checkTutorial = 0;

	// Use this for initialization
	void Start () {
        checkTutorial = PlayerPrefs.GetInt("TutDone");

        if (checkTutorial < 1)
        {
            transform.GetChild(0).GetComponent<Button>().interactable = false;
            transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        }
        else
        {
            transform.GetChild(0).GetComponent<Button>().interactable = true;
            transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 1.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
