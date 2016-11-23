using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class ZaryaRightClick : MonoBehaviour {

    private bool timeStart = false;
    private float timecount = 0;
    private bool suckStart = false;

    public List<Transform> suckList = new List<Transform>();

    // Use this for initialization
    void Start()
    {

    }

    void OnCollisionEnter()
    {
        Destroy(GetComponent<Rigidbody>());
        GetComponent<SphereCollider>().isTrigger = true;
        Vector3 explodeSize = new Vector3(15, 15, 15);

        transform.localScale = explodeSize;
        timeStart = true;


        Material translucent = new Material(Shader.Find("Transparent/Diffuse"));

        GetComponent<MeshRenderer>().material = translucent;
        GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.5f);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Rubbish"  && !suckList.Contains(col.transform) )
        {
            print(col.name);

            suckList.Add(col.transform);
            suckStart = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart)
            timecount += Time.deltaTime;
        if (timecount > 4f)
            Destroy(transform.gameObject);

        if (suckStart)
        {
            for (int i = 0; i < suckList.Count; i++)
            {
                Vector3 direction = (transform.position - suckList[i].position).normalized;

                suckList[i].GetComponent<Rigidbody>().velocity = direction * 300 * Time.deltaTime;
            }
        }

    }
}
