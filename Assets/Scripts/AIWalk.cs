using UnityEngine;
using System.Collections;

public class AIWalk : MonoBehaviour
{

    public Transform goal;

    private bool isAI;

    public float randTimeDur;
    private int randMin = 1;
    private int randMax = 10;

    public float roamRadius = 100.0f;

    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        if (transform.tag.Contains("AI"))
            isAI = true;

        randTimeDur = Random.Range(randMin, randMax);
    }

    void FreeRoam()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        goal.position = hit.position;
        agent.destination = goal.position;
    }


    // Update is called once per frame
    void Update()
    {

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

            if ((transform.position - goal.position).magnitude < 3f)
                FreeRoam();
        }
    }
}
