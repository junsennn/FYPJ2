using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour {

    GameObject gunTransform;

    public Text weapon_Name;

	// Use this for initialization
	void Start () {
        
        gunTransform = Instantiate(transform.GetChild(0).gameObject);
        gunTransform.SetActive(false);
        gunTransform.transform.parent = transform;
        gunTransform.transform.position = transform.GetChild(0).position;
        gunTransform.transform.rotation = transform.GetChild(0).rotation;

        weapon_Name.text = transform.GetChild(0).name;
    }
	
    void OnTriggerEnter(Collider col)
    {
        if (!transform.GetChild(0).gameObject.activeSelf && col.tag == "Weapon" && col.GetComponent<CheckLootStatus>().Lootable)
        {
            col.transform.parent = transform;
            Destroy(col.transform.gameObject.GetComponent<Rigidbody>());
            col.transform.SetAsFirstSibling();

            col.transform.position = gunTransform.transform.position;
            col.transform.rotation = gunTransform.transform.rotation;

            weapon_Name.text = transform.GetChild(0).name;

            transform.GetChild(0).GetComponent<CheckLootStatus>().LootWeapon();

            if (transform.GetChild(0).name == "Portal gun")
                transform.gameObject.AddComponent<ObjectGrab>();
            if (transform.GetChild(0).name == "Zarya Gun")
                transform.gameObject.AddComponent<ZaryaGun>();
        }
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.G) && transform.GetChild(0).gameObject.activeSelf)
        {
            if (transform.GetChild(0).name == "Portal gun")
                Destroy(GetComponent<ObjectGrab>());
            if (transform.GetChild(0).name == "Zarya Gun")
                Destroy(GetComponent<ZaryaGun>());

            transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(transform.GetComponent<Camera>().transform.forward * 300);
            transform.GetChild(0).GetComponent<CheckLootStatus>().DropWeapon();
            transform.GetChild(0).parent = null;

            weapon_Name.text = "No Weapon";
        }

	}
}
