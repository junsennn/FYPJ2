using UnityEngine;
using System.Collections;

public class DropItems : MonoBehaviour {

    private float timeBeforeDrop = 5.0f;
    private float timeDrop = 0.0f;

    private GameObject rubbishPool;
    private int poolSize;

    public float heightDrop = 1.0f;

	// Use this for initialization
	void Start ()
    {
        rubbishPool = GameObject.Find("RubbishPool");
        
        foreach (Transform child in rubbishPool.transform)
            poolSize += 1;

        print(poolSize);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeDrop += Time.deltaTime;

        if(timeDrop > timeBeforeDrop)
        {
            timeDrop = 0.0f;

            GameObject newRubbish = Instantiate<GameObject>(rubbishPool.transform.GetChild(Random.Range(0, poolSize)).gameObject);
            
            newRubbish.transform.position = transform.position + new Vector3(0,heightDrop,0);

            newRubbish.SetActive(true);
        }
	
	}
}
