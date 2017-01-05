using UnityEngine;
using System.Collections;

public class InstantiateTrees : MonoBehaviour {

	public GameObject thisPrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				Instantiate (thisPrefab, new Vector3 ((i * 50.0f) - 220.0f, 38.0f, (j * 20.0f) + 50.0f), Quaternion.Euler(-90, 0, 0));
			}
		}
	}
}
