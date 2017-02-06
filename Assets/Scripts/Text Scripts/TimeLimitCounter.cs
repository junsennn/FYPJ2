using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLimitCounter : MonoBehaviour {
    
    private GameObject gamecontrol;

	// Use this for initialization
	void Start () {
        gamecontrol = GameObject.Find("GameplayControl");
	}
	
	// Update is called once per frame
	void Update ()
    {
		GetComponent<Image>().fillAmount = (gamecontrol.GetComponent<GameLevelSettings>().TimeLimit - gamecontrol.GetComponent<GameLevelSettings>().TimeElapsed) / gamecontrol.GetComponent<GameLevelSettings>().TimeLimit;
    }
}
