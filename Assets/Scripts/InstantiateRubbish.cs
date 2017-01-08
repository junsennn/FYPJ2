using UnityEngine;
using System.Collections;

public class InstantiateRubbish : MonoBehaviour {

    private GameObject rubbishPool;
    private int poolSize;

    public int RubbishAmount;

    public Vector3 centrePoint;
    public Vector3 scale;

    // Use this for initialization
    void Start () {
        rubbishPool = GameObject.Find("RubbishPool");

        foreach (Transform child in rubbishPool.transform)
            poolSize += 1;

        int currentAmount = 0;

        while (currentAmount < RubbishAmount)
        {
            GameObject newRubbish = Instantiate<GameObject>(rubbishPool.transform.GetChild(Random.Range(0, poolSize)).gameObject);

            newRubbish.transform.position = new Vector3(Random.Range(centrePoint.x - scale.x/2, centrePoint.x + scale.x / 2), centrePoint.y , Random.Range(centrePoint.z - scale.z / 2, centrePoint.z + scale.z / 2));
            while(newRubbish.GetComponent<Rubbish_OG_pos>().cState == Rubbish_OG_pos.collisionState.Enter || newRubbish.GetComponent<Rubbish_OG_pos>().cState == Rubbish_OG_pos.collisionState.Stay)
            {   
                newRubbish.transform.position = new Vector3(Random.Range(centrePoint.x - scale.x / 2, centrePoint.x + scale.x / 2), centrePoint.y, Random.Range(centrePoint.z - scale.z / 2, centrePoint.z + scale.z / 2));
            }

            newRubbish.SetActive(true);

            newRubbish.GetComponent<Rubbish_OG_pos>().SetOG(newRubbish.transform.position, newRubbish.transform.rotation);

            currentAmount += 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
