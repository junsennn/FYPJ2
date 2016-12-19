using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLimitCounter : MonoBehaviour {

	public double timer = 60.0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		GetComponent<Text> ().text = "Time Left: " + timer.ToString();
	}
}
