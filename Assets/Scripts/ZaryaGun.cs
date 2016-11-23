using UnityEngine;
using System.Collections;

public class ZaryaGun : MonoBehaviour {

    GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            bullet.name = "Bullet";
            bullet.transform.position = GetComponent<Camera>().transform.position + GetComponent<Camera>().transform.forward * 3;

            Vector3 small = new Vector3(0.25f, 0.25f, 0.25f);
            bullet.transform.localScale = small;

            bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().AddForce(GetComponent<Camera>().transform.forward * 1000);

            if (Input.GetMouseButtonDown(0))
                bullet.AddComponent<ZaryaLeftClick>();
            else if (Input.GetMouseButtonDown(1))
                bullet.AddComponent<ZaryaRightClick>();
        }



	}
}
