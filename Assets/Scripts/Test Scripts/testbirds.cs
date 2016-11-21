using UnityEngine;
using System.Collections;

public class testbirds : MonoBehaviour {

	public GameObject prefab;
	public GameObject goalPrefab;
	public static int areaSize = 5;

	static int numBeings = 10;
	public static GameObject[] allBeings = new GameObject[numBeings];

	public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numBeings; i++) {
			Vector3 pos = new Vector3 (Random.Range (-areaSize, areaSize), Random.Range (-areaSize, areaSize), Random.Range (-areaSize, areaSize));
			allBeings [i] = (GameObject)Instantiate (prefab, pos, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, 1000) < 50) {
			goalPos = new Vector3 (Random.Range (-areaSize, areaSize), Random.Range (-areaSize, areaSize), Random.Range (-areaSize, areaSize)); 

			goalPrefab.transform.position = goalPos;
		}
	}
}
