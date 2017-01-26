using UnityEngine;
using System.Collections;

public class ObjectGrab : MonoBehaviour
{

    RaycastHit hit;
    public GameObject itemGrabbed;
    public float distance = 10.0f;

    private bool Shot = false;
    private float ShotPreventHold = 0.1f;
    public float ShotCD = 0.2f;

    private GameObject redCrosshair;
    private GameObject greenCrosshair;

    // Use this for initialization
    void Start()
    {
        ShotPreventHold = ShotCD;

        redCrosshair = GameObject.Find("RedCrosshair");
        greenCrosshair = GameObject.Find("GreenCrosshair");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
            Shot = true;

        if (Shot)
        {
            ShotPreventHold -= Time.deltaTime;

            if (ShotPreventHold < 0)
            {
                ShotPreventHold = ShotCD;
                Shot = false;
            }
        }

        #region Raycast 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(transform.position, ray.direction * 10);

        
        greenCrosshair.SetActive(false);
        redCrosshair.SetActive(true);
        

        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.cyan);
        if (Physics.Raycast(ray, out hit, distance))
        {
            //print("Im looking at " + hit.transform.name);
            if (hit.collider.tag == "Rubbish")
            {
                if (redCrosshair.activeInHierarchy)
                {
                    redCrosshair.SetActive(false);
                    greenCrosshair.SetActive(true);
                }

                //if(Input.GetKeyDown(KeyCode.E) && itemGrabbed == null)
                if (Input.GetMouseButton(0) && itemGrabbed == null && !Shot)
                {
                    if (!hit.transform.gameObject.GetComponent<ObjectFollow>())
                        hit.transform.gameObject.AddComponent<ObjectFollow>();

                    itemGrabbed = hit.transform.gameObject;
                }
            }
        }
        #endregion

    }

}
