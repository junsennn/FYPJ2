using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	// This speed is for the character
	public float speed;
	public float jumpspeed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		// This is to lock the cursor within the game and to also disable the mouse cursor icon
		Cursor.lockState = CursorLockMode.None;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Translate forward or backward
		float translateForwardBack = Input.GetAxis ("Vertical") * speed; // "Vertical" can be found at Edit -> Project Settings -> Input

		// Translate either left or right
		float strafeLeftRight = Input.GetAxis ("Horizontal") * speed; // "Horizontal" can be found at Edit -> Project Settings -> Input

		translateForwardBack *= Time.deltaTime;
		strafeLeftRight *= Time.deltaTime;

		transform.Translate (strafeLeftRight, 0.0f, translateForwardBack);

		// This is to get the mouse cursor icon back and to unlock the cursor from the game
		//if(Input.GetKeyDown("escape"))
	//	{
		//	Cursor.lockState = CursorLockMode.None;
		//}

		// This is to allow the character to jump up and then back down again
	//	if(Input.GetKeyDown ("space"))
	//	{
		//	print ("I am Jumping!");
		//	Vector3 jumping = new Vector3 (0, 20, 0);
		////	rb.AddForce (jumping * jumpspeed);
		//}
	}
}
