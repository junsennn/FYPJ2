using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ClickExit ();
	}

	public void ClickExit()
	{
		Application.Quit ();
	}
}
