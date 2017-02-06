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
            transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 160.0f / 255.0f);
			transform.GetChild(1).GetComponent<Button>().interactable = false;
			transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 160.0f / 255.0f);
        }
        else
        {
            transform.GetChild(0).GetComponent<Button>().interactable = true;
            transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1.0f);
			transform.GetChild(1).GetComponent<Button>().interactable = true;
			transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1.0f);
        }
    }

    public void resetPrefs()
    {
        PlayerPrefs.SetInt("TutDone", 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
