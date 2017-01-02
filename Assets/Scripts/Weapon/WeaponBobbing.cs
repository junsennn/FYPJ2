using UnityEngine;
using System.Collections;

public class WeaponBobbing : MonoBehaviour {

	private float mouseX;
	private float mouseY;

	Quaternion rotationSpeed;

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");

		rotationSpeed = Quaternion.Euler (-mouseY * 5, mouseX * 5, 0);

		transform.localRotation = Quaternion.Slerp (transform.localRotation, rotationSpeed, speed * Time.deltaTime);
	}
}
