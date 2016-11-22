using UnityEngine;
using System.Collections;

public class ObjectGrab : MonoBehaviour
{

    RaycastHit hit;
    public GameObject itemGrabbed;
    float distance = 20.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Raycast 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(transform.position, ray.direction * 10);
   
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.cyan);
        if (Physics.Raycast(ray, out hit, distance))
        {
            print("Im looking at " + hit.transform.name);
            if (hit.collider.tag == "Rubbish")
            {
                //if(Input.GetKeyDown(KeyCode.E) && itemGrabbed == null)
                if (Input.GetMouseButton(0) && itemGrabbed == null)
                {
                    if(!hit.transform.gameObject.GetComponent<ObjectFollow>())
                        hit.transform.gameObject.AddComponent<ObjectFollow>();

                    itemGrabbed = hit.transform.gameObject;
                }
            }
        }
        #endregion

    }

}
