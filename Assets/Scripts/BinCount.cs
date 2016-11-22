using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BinCount : MonoBehaviour {

    public List<Collider> collidedObjects = new List<Collider>();

    public int objectCounts;

	// Use this for initialization
	void Start ()
    {
        objectCounts = 0;
    }

    void OnTriggerEnter(Collider col)
    {
        if(!collidedObjects.Contains(col) && col.tag == "Rubbish")
        {
            collidedObjects.Add(col);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (collidedObjects.Contains(col) && col.tag == "Rubbish")
        {
            collidedObjects.Remove(col);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        objectCounts = collidedObjects.Count;
	}
}
