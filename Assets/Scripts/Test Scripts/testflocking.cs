using UnityEngine;
using System.Collections;

public class testflocking : MonoBehaviour {

	public float speed = 0.001f;

	// How fast the being will turn
	float rotationSpeed = 4.0f;

	// Heading direction
	Vector3 averageHeading;
	Vector3 averagePosition;

	// Distance between each being to flock, if too far from the other being, might not flock
	float neighbourDistance = 3.0f;

	bool turning = false;

	// Use this for initialization
	void Start () {
		speed = Random.Range (0.5f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, Vector3.zero) >= testbirds.areaSize) {
			turning = true;
		} 
		else 
		{
			turning = false;
		}

		if (turning == true) 
		{
			Vector3 direction = Vector3.zero - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);

			speed = Random.Range (0.5f, 1);
		} 
		else 
		{
			if (Random.Range (0.0f, 5.0f) < 1) {
				ApplyRules ();
			}
		}
	
		transform.Translate(0, 0, Time.deltaTime * speed);
	}

	void ApplyRules()
	{
		GameObject[] gos;
		gos = testbirds.allBeings;

		Vector3 vCentre = Vector3.zero;
		Vector3 vaVoid = Vector3.zero;
		float gSpeed = 0.1f;

		Vector3 goalPos = testbirds.goalPos;

		float distance;

		int groupSize = 0;

		foreach (GameObject go in gos)
		{
			if (go != this.gameObject) 
			{
				distance = Vector3.Distance (go.transform.position, this.transform.position);

				if(distance <= neighbourDistance)
				{
					vCentre += go.transform.position;
					groupSize++;

					if (distance < 1.0f) 
					{
						vaVoid = vaVoid + (this.transform.position - go.transform.position);
					}

					testflocking anotherflock = go.GetComponent<testflocking> ();
					gSpeed = gSpeed + anotherflock.speed;
				}
			}
		}

		if (groupSize > 0) 
		{
			vCentre = vCentre / groupSize + (goalPos - this.transform.position);
			speed = gSpeed / groupSize;

			Vector3 direction = (vCentre + vaVoid) - transform.position;
			if (direction != Vector3.zero) 
			{
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
			}
		}
	}
}
