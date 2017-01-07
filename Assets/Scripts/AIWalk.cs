using UnityEngine;
using System.Collections;

public class AIWalk : MonoBehaviour {

	public Transform goal;

    private bool isAI;

    public float randTimeDur;
    private int randMin = 1;
    private int randMax = 10;

    private NavMeshAgent agent;

    // Use this for initialization
    void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = goal.position;

        if (transform.tag.Contains("AI"))
            isAI = true;

        randTimeDur = Random.Range(randMin, randMax);
	}
	
	// Update is called once per frame
	void Update () {

        if (isAI)
        {
            randTimeDur -= Time.deltaTime;

            if (randTimeDur <= 0)
            {
                randTimeDur = Random.Range(randMin, randMax);

                int isRunning = Random.Range(0, 2);

                if (isRunning == 0)
                {
                    agent.speed = 8;
                    GetComponent<Animator>().SetBool("IsWalking", true);
                }
                else
                {
                    agent.speed = 16;
                    GetComponent<Animator>().SetBool("IsWalking", false);
                }

            }
        }
	}
}
