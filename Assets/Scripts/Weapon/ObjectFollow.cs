using UnityEngine;
using System.Collections;

public class ObjectFollow : MonoBehaviour
{

    private GameObject player;
    public float distance = 5.0f;
    float speed = 300.0f;
    Camera playerCamera;
    float forceAmount = 20000;

    private GameObject itemGrabbed;

    private bool ZaryaGun = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform.GetChild(0).gameObject;
        playerCamera = player.GetComponent<Camera>();

        if (player.GetComponent<ObjectGrab>())
            itemGrabbed = player.GetComponent<ObjectGrab>().itemGrabbed;
        else if (player.GetComponent<ZaryaGun>())
        {
            itemGrabbed = player.GetComponent<ZaryaGun>().itemGrabbed;
            ZaryaGun = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Drop Item
        if (itemGrabbed != null)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            if (!Input.GetMouseButton(0))
            {
                itemGrabbed = null;

                if (ZaryaGun)
                    player.GetComponent<ZaryaGun>().itemGrabbed = null;
                else
                    player.GetComponent<ObjectGrab>().itemGrabbed = null;

                Destroy(this);
            }

            //if (Input.GetMouseButtonDown(0))
            if (Input.GetMouseButtonDown(1) && !ZaryaGun)
            {
                GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * forceAmount);
                itemGrabbed = null;
                
                player.GetComponent<ObjectGrab>().itemGrabbed = null;

                Destroy(this);
            }

        }


        #endregion

        #region Scrolling
        if (distance > 3.0f)
            distance += Input.mouseScrollDelta.y;
        if (distance < 3.0f)
            distance = 3.1f;
        #endregion

        #region Moving
        if (!ZaryaGun)
            GetComponent<Rigidbody>().velocity = (((playerCamera.transform.position + playerCamera.transform.forward * distance) - transform.position) * speed * Time.deltaTime);
        else
            transform.position = playerCamera.transform.position + playerCamera.transform.forward * distance;
        #endregion

    }
}
