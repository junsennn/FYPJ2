using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ItemInBinCounter : MonoBehaviour {

    public GameObject [] binList;

    public Text binText;

    private int binAmount;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        binAmount = 0;

        for(int i = 0; i < binList.Length; i++)
        {
            binAmount += binList[i].GetComponent<BinCount>().objectCounts;
        }

        binText.text = "Item In Bin :" + binAmount;

	}
}
