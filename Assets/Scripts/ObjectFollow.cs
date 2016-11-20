using UnityEngine;
using System.Collections;

public class ObjectFollow : MonoBehaviour {

    private GameObject player;
    float distance = 10.0f;
    float speed = 300.0f;
    Camera playerCamera;
    float forceAmount = 20000;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        playerCamera = player.transform.GetChild(0).GetComponent<Camera>();
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
        if (distance < 30 && distance > 5)
            distance += Input.mouseScrollDelta.y;
        if (distance < 5)
            distance = 5.1f;
        if (distance > 30)
            distance = 29.9f;
        #endregion

        #region Moving
        GetComponent<Rigidbody>().velocity = (((playerCamera.transform.position + playerCamera.transform.forward * distance) - transform.position) * speed * Time.deltaTime);
        #endregion

    }
}
