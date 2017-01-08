using UnityEngine;
using System.Collections;

public class Rubbish_OG_pos : MonoBehaviour {

    public Vector3 OG_Pos;
    public Quaternion OG_Rotation;

	// Use this for initialization
	void Start () {
        OG_Pos = transform.position;
        OG_Rotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetToOG()
    {
        transform.position = OG_Pos;
        transform.rotation = OG_Rotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    
    public void SetOG(Vector3 og_pos , Quaternion og_rot)
    {
        OG_Pos = og_pos;
        OG_Rotation = og_rot;
    }

}
