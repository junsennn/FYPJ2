using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour
{

    public GameObject[] RubbishBins;
    public GameObject[] Doors;
    public GameObject[] DoorEndPos;

    public int[] RubbishCountNeeded;

    private int TutorialStage = 1;

    private bool tutorialComplete = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorialComplete)
        {
            if (RubbishBins[TutorialStage - 1].GetComponent<BinCount>().objectCounts >= RubbishCountNeeded[TutorialStage - 1])
                GoNextStage();
        }
    }

    void GoNextStage()
    {
        StartCoroutine(OpenDoor(TutorialStage * 2));
        TutorialStage += 1;

        if (TutorialStage > 3)
        {
            tutorialComplete = true;
            PlayerPrefs.SetInt("TutDone", 1);
        }
    }

    IEnumerator OpenDoor(int DoorNo)
    {
        while ((Doors[DoorNo - 2].transform.position - DoorEndPos[DoorNo - 2].transform.position).magnitude > 0.001f &&
           (Doors[DoorNo - 2].transform.eulerAngles - DoorEndPos[DoorNo - 2].transform.eulerAngles).magnitude > 0.001f &&
           (Doors[DoorNo - 1].transform.position - DoorEndPos[DoorNo - 1].transform.position).magnitude > 0.001f &&
           (Doors[DoorNo - 1].transform.eulerAngles - DoorEndPos[DoorNo - 1].transform.eulerAngles).magnitude > 0.001f)
        {
            Doors[DoorNo - 2].transform.position = Vector3.Lerp(Doors[DoorNo - 2].transform.position, DoorEndPos[DoorNo - 2].transform.position, 1 * Time.deltaTime);
            Doors[DoorNo - 2].transform.eulerAngles = Vector3.Lerp(Doors[DoorNo - 2].transform.eulerAngles, DoorEndPos[DoorNo - 2].transform.eulerAngles, 1 * Time.deltaTime);

            Doors[DoorNo - 1].transform.position = Vector3.Lerp(Doors[DoorNo - 1].transform.position, DoorEndPos[DoorNo - 1].transform.position, 1 * Time.deltaTime);
            Doors[DoorNo - 1].transform.eulerAngles = Vector3.Lerp(Doors[DoorNo - 1].transform.eulerAngles, DoorEndPos[DoorNo - 1].transform.eulerAngles, 1 * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

    }

}
