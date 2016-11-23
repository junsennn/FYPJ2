using UnityEngine;
using System.Collections;

public class ZaryaLeftClick : MonoBehaviour {

    private bool timeStart = false;
    private float timecount = 0;

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter()
    {
        Destroy(GetComponent<Rigidbody>());
        GetComponent<SphereCollider>().isTrigger = true;
        Vector3 explodeSize = new Vector3(5, 5, 5);

        transform.localScale = explodeSize;
        timeStart = true;
    }

    void OnTriggerEnter(Collider col)
    {
        print("TEST");
        if (col.tag == "Rubbish")
        {
            Vector3 Direction = (col.transform.position - transform.position).normalized;

            col.GetComponent<Rigidbody>().AddForce(Direction * 10000);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (timeStart)
            timecount += Time.deltaTime;
        if (timecount > 0.1f)
            Destroy(transform.gameObject);
	}
}
