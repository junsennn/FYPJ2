using UnityEngine;
using System.Collections;

public class ChangeLightColor : MonoBehaviour {

	public float durationTime;
	private float thisTime;
	public Color color0 = Color.red;
	public Color color1 = Color.blue;
	public Color color2 = Color.white;

	public Light thisLight;

	// Use this for initialization
	void Start () {
		thisLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		thisTime = Mathf.PingPong (Time.time, durationTime) / durationTime;
		thisLight.color = Color.Lerp (color0, color2, thisTime);
	}
}
