using UnityEngine;
using System.Collections;

public class ObjectFollow : MonoBehaviour {

    private GameObject player;
    float distance = 5.0f;
    float speed = 300.0f;
    Camera playerCamera;
    float forceAmount = 20000;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").transform.GetChild(0).gameObject;
        playerCamera = player.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        #region Drop Item
        if (player.GetComponent<ObjectGrab>().itemGrabbed != null)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            if (!Input.GetMouseButton(0))
            {
                player.GetComponent<ObjectGrab>().itemGrabbed = null;
                Destroy(this);
            }

            //if (Input.GetMouseButtonDown(0))
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * forceAmount);
                player.GetComponent<ObjectGrab>().itemGrabbed = null;
                Destroy(this);
            }

        }


        #endregion

        #region Scrolling
        if (distance < 15.0f && distance > 3.0f)
            distance += Input.mouseScrollDelta.y;
        if (distance < 3.0f)
            distance = 3.1f;
        if (distance > 15.0f)
            distance = 14.9f;
        #endregion

        #region Moving
        GetComponent<Rigidbody>().velocity = (((playerCamera.transform.position + playerCamera.transform.forward * distance) - transform.position) * speed * Time.deltaTime);
        #endregion

    }
}
