using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameLevelSettings : MonoBehaviour {
   
    private GameObject canvas;

    public GameObject WinPanel;
    public GameObject LosePanel;

    public float TimeLimit;
    private float TimeElapsed;

    public int MinRubbishRequired;
    private int RubbishCollected = 0;

    private List<GameObject> binList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        foreach (Transform child in GameObject.Find("RubbishBins").transform)
            binList.Add(child.gameObject);

        canvas = GameObject.Find("Canvas");
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckRubbishCount();

        TimeElapsed += Time.deltaTime;

        if (TimeElapsed > TimeLimit)
        {
            //if (  )
        }

    }

    void CheckRubbishCount()
    {
        RubbishCollected = 0;

        for (int i = 0; i < binList.Count; i++)
            RubbishCollected += binList[i].GetComponent<BinCount>().objectCounts;
    }

}
