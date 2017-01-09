using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class GameLevelSettings : MonoBehaviour {
   
	public FirstPersonController player;

    private GameObject canvas;

	public Transform WinPanel;
	public Transform LosePanel;

	public GameObject PoisonMist;

    public float TimeLimit;
    public float TimeElapsed;
	public float PoisonTime;

    public int MinRubbishRequired;
    private int RubbishCollected = 0;

	public bool playerTakeDamage = false;

    private List<GameObject> binList = new List<GameObject>();

    public enum GameState
    {
        Win,
        Lose,
        Ongoing
    };

    public GameState currentState = GameState.Ongoing;

    // Use this for initialization
    void Start () {
        foreach (Transform child in GameObject.Find("RubbishBins").transform)
            binList.Add(child.gameObject);

        canvas = GameObject.Find("Canvas");
        WinPanel.gameObject.SetActive(false);
		LosePanel.gameObject.SetActive(false);

		player = FindObjectOfType<FirstPersonController>();
	}

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.Ongoing:
                {
                    CheckRubbishCount();

                    TimeElapsed += Time.deltaTime;

                    if (RubbishCollected >= MinRubbishRequired)
                        currentState = GameState.Win;

                    if (TimeElapsed > TimeLimit)
                    {
                        TimeElapsed = 0;

                        if (RubbishCollected >= MinRubbishRequired)
                            currentState = GameState.Win;
                        else
                            currentState = GameState.Lose;
                    }

					if (TimeElapsed > PoisonTime)
					{
						PoisonMist.gameObject.SetActive (true);
					player.myHealth -= Time.deltaTime;

						if (player.myHealth == 0) 
						{
							player.myHealth = 0;
							currentState = GameState.Lose;
						}
					}

					player.canMove = true;
					player.showCursor = false;
					
                }
                break;

            case GameState.Win:
                {
				WinPanel.gameObject.SetActive(true);

					player.canMove = false;
					player.showCursor = true;
                }
                break;

            case GameState.Lose:
                {
				LosePanel.gameObject.SetActive(true);

					player.canMove = false;
					player.showCursor = true;
                }
                break;
        }

    }

    void CheckRubbishCount()
    {
        RubbishCollected = 0;

        for (int i = 0; i < binList.Count; i++)
            RubbishCollected += binList[i].GetComponent<BinCount>().objectCounts;
    }
}
