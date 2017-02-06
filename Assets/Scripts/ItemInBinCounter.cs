using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;

public class ItemInBinCounter : MonoBehaviour {

    private List<GameObject> binList = new List<GameObject>();

    public Text binText;
    public bool text;

    private int binAmount;

	// Use this for initialization
	void Start ()
    {
        foreach (Transform child in GameObject.Find("RubbishBins").transform)
        {
            binList.Add(child.gameObject);
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        binAmount = 0;

        for(int i = 0; i < binList.Count; i++)
        {
            binAmount += binList[i].GetComponent<BinCount>().objectCounts;
        }    

        if(text)
            binText.text = " : " + binAmount;

	}
}
