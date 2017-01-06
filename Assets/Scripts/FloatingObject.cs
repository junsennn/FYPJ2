using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour {

	private float originalY;
	public float floatingStrength = 1; 

	// Use this for initialization
	void Start () {
		this.originalY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, originalY + ((float)Mathf.Sin (Time.time) * floatingStrength), transform.position.z);
	}
}
