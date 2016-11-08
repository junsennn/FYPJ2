using UnityEngine;
using System.Collections;

public class FirstPersonCameraControl : MonoBehaviour {

	// 2D Vector for the camera's movements
	Vector2 mouseLook;

	// 2D Vector for the mouse to move smoothly
	Vector2 smoothVector;

	// Values for mouse sensitivity
	public float sensitivity;

	// Values for the mouse to move smoothly
	public float smoothValues;
	 
	GameObject character;

	// Use this for initialization
	void Start () {
		// Assigning the character to the camera's parent
		character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		/* -> To get the mouse movement values
		   -> var is used as it defines the type of the variable by the complier */
		var mouseMoveValues = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		// To increase the mouse movement values with sensitivity and smoothing
		mouseMoveValues = Vector2.Scale (mouseMoveValues, new Vector2 (sensitivity * smoothValues, sensitivity * smoothValues));

		// To smooth the mouse's x-axis, lerp is used to prevent the snapping of one's direction to the other. (Should be used more for movements?) 
		smoothVector.x = Mathf.Lerp (smoothVector.x, mouseMoveValues.x, 1f / smoothValues);
		// To smooth the mouse's y-axis
		smoothVector.y = Mathf.Lerp (smoothVector.y, mouseMoveValues.y, 1f / smoothValues);
	
		// Add the smoothVector (smoothing of mouse) to the mouseLook
		mouseLook += smoothVector;

		// To clamp the mouse for looking up and down
		mouseLook.y = Mathf.Clamp(mouseLook.y, -90.0f, 90.0f);

		/* -> Giving the camera a rotation
		   -> "-" added to the "mouseLook.y" for inverted movement of up and down
		   -> Vector3.right is to rotate the camera around the y-axis */
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);

		// To use the x-axis of the mouse to rotate around the character's up
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);

		// -Optional- Do not need the main camera to be the child of a GameObject
		//transform.rotation = Quaternion.Euler(-mouseLook.y, mouseLook.x, 0.0f);
	}
}
