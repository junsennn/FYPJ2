using UnityEngine;
using System.Collections;

public class InstantiateGreenCar : MonoBehaviour {

	public GameObject thisPrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 1; i++) {
			for (int j = 0; j < 4; j++) {
				Instantiate (thisPrefab, new Vector3 ((i * 50.0f) + 20.0f, 36.0f, (j * 20.0f) - 90.0f), Quaternion.identity);
			}
		}
	}
}
