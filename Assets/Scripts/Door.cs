using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public GameObject[] Doors;
	public float DoorMaxWidth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OpenDoor(int DoorNo)
	{
		while (Doors[DoorNo].transform.position.y < DoorMaxWidth)
		{
			Doors[DoorNo].transform.position = Vector3.Lerp(Doors[DoorNo].transform.position, new Vector3(Doors[DoorNo].transform.position.x, DoorMaxWidth , Doors[DoorNo].transform.position.z), 1 * Time.deltaTime );

			yield return new WaitForEndOfFrame();
		}

	}
}
