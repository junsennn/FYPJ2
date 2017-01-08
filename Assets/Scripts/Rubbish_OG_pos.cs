using UnityEngine;
using System.Collections;

public class Rubbish_OG_pos : MonoBehaviour {

    public Vector3 OG_Pos;
    public Quaternion OG_Rotation;

    public enum collisionState
    {
        None,
        Enter,
        Exit,
        Stay,
    };

    public collisionState cState;

	// Use this for initialization
	void Start () {
        OG_Pos = transform.position;
        OG_Rotation = transform.rotation;

        cState = collisionState.None;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter()
    {
        cState = collisionState.Enter;
    }

    void OnCollisionStay()
    {
        cState = collisionState.Stay;
    }

    void OnCollisionExit()
    {
        cState = collisionState.Exit;
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
