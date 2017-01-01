using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

    public GameObject[] RubbishBins;
    public GameObject[] Doors;

    public int[] RubbishCountNeeded;

    public float DoorMaxHeight;

    private int TutorialStage = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (TutorialStage != 2 && TutorialStage < RubbishBins.Length - 1)
        {
            if (RubbishBins[TutorialStage].GetComponent<BinCount>().objectCounts >= RubbishCountNeeded[TutorialStage])
                GoNextStage();
        }
        else
        {
            if (GameObject.Find("Player").transform.GetChild(0).GetComponent<ChangeWeapon>().weapon_Name.text == "Zarya Gun")
                GoNextStage();
        }

	}

    void GoNextStage()
    {
        StartCoroutine(OpenDoor(TutorialStage));
        TutorialStage += 1;
    }

    IEnumerator OpenDoor(int DoorNo)
    {
        while (Doors[DoorNo].transform.position.y < DoorMaxHeight)
        {
            Doors[DoorNo].transform.position += new Vector3(0, 1 * Time.deltaTime, 0);

            yield return new WaitForEndOfFrame();
        }

    }

}
