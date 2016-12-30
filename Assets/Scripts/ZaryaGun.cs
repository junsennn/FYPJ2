using UnityEngine;
using System.Collections;

public class ZaryaGun : MonoBehaviour
{

    GameObject bullet;

    GameObject suckbullet;

    private GameObject player;

    private bool SuckOnCD;
    private float SuckCD;
    public float SuckCDDur = 4.0f;

    RaycastHit hit;
    public GameObject itemGrabbed;
    public float distance = 10.0f;

    // Use this for initialization
    void Start()
    {
        SuckOnCD = false;
        SuckCD = 0.0f;

        player = GameObject.Find("Player").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (SuckOnCD)
        {
            SuckCD -= Time.deltaTime;

            if (SuckCD < 0)
                SuckOnCD = false;
        }


        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (!(Input.GetMouseButtonDown(0) && SuckOnCD))
            {
                bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                bullet.name = "Bullet";
                bullet.transform.position = GetComponent<Camera>().transform.position + GetComponent<Camera>().transform.forward * 3;

                Vector3 small = new Vector3(0.25f, 0.25f, 0.25f);
                bullet.transform.localScale = small;

                bullet.AddComponent<Rigidbody>();
                bullet.GetComponent<Rigidbody>().AddForce(GetComponent<Camera>().transform.forward * 1000);

                if (Input.GetMouseButtonDown(1))
                    bullet.AddComponent<ZaryaLeftClick>();
                else if (Input.GetMouseButtonDown(0))
                {
                    bullet.AddComponent<ZaryaRightClick>();
                    SuckOnCD = true;
                    SuckCD = SuckCDDur;
                    suckbullet = bullet;
                }
            }

            if (Input.GetMouseButtonDown(0) && SuckOnCD && !suckbullet.GetComponent<ObjectFollow>() && suckbullet.GetComponent<ZaryaRightClick>().suckStart)
            {
                suckbullet.AddComponent<ObjectFollow>();
                itemGrabbed = suckbullet;
                suckbullet.GetComponent<ObjectFollow>().distance = (suckbullet.transform.position - player.transform.position).magnitude ;
            }

        }
    }
}