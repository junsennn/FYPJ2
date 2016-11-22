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

    void OnCollisionEnter(Collision col)
    {
        if(!collidedObjects.Contains(col.collider) && col.collider.tag == "Rubbish")
        {
            collidedObjects.Add(col.collider);
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (collidedObjects.Contains(col.collider) && col.collider.tag == "Rubbish")
        {
            collidedObjects.Remove(col.collider);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        objectCounts = collidedObjects.Count;
	}
}
