using UnityEngine;
using System.Collections;

public class CheckLootStatus : MonoBehaviour {

    public bool Lootable = true;

    public bool isUsing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
       
	}

    void OnCollisionEnter(Collision col)
    {
        if(!isUsing && (col.transform.name != "Player" || col.transform.name != "FirstPersonCharacter"))
        {
            Lootable = true;
        }
    }

    public void LootWeapon()
    {
        isUsing = true;
        Lootable = false;
    }

    public void DropWeapon()
    {
        isUsing = false;
    }

}
