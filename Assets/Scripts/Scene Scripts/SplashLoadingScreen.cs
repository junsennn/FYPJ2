using UnityEngine;
using System.Collections;

public class SplashLoadingScreen : MonoBehaviour {

	// Variables
	public float setTime = 3.0f;
	float timer;
	public string SceneName;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > setTime) {
			FadingScreen.Instance.FadeStart (SceneName);
		}
	}
}
