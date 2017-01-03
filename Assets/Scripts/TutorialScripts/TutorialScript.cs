using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

    public GameObject[] RubbishBins;
    public GameObject[] Doors;

    public int[] RubbishCountNeeded;

    public float DoorMaxHeight;

    private int TutorialStage = 0;

    private bool tutorialComplete = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!tutorialComplete)
        {
            if (TutorialStage != 2)
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
        else
        {
            PlayerPrefs.SetInt("TutDone", 1);
        }
	}

    void GoNextStage()
    {
        StartCoroutine(OpenDoor(TutorialStage));
        TutorialStage += 1;

        if (TutorialStage >= RubbishCountNeeded.Length)
            tutorialComplete = true;
    }

    IEnumerator OpenDoor(int DoorNo)
    {
        while (Doors[DoorNo].transform.position.y < DoorMaxHeight)
        {
            Doors[DoorNo].transform.position = Vector3.Lerp(Doors[DoorNo].transform.position, new Vector3(Doors[DoorNo].transform.position.x, DoorMaxHeight , Doors[DoorNo].transform.position.z), 1 * Time.deltaTime );

            yield return new WaitForEndOfFrame();
        }

    }

}
