using UnityEngine;
using System.Collections;

public class RubbishInBound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider col)
    {

    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Rubbish")
            col.GetComponent<Rubbish_OG_pos>().ResetToOG();

    }

}
