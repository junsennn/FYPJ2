using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPS_Counter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Get the FPS values
		GetComponent<Text> ().text = "FPS: " + (1 / Time.deltaTime).ToString();
	}
}
