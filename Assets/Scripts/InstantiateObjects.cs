using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

    public GameObject Trees, RedCar, GreenCar, YellowCar;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 1; i++)
            for (int j = 0; j < 4; j++)
                Instantiate(YellowCar, new Vector3((i * 50.0f) + 80.0f, 36.0f, (j * 20.0f) - 90.0f), Quaternion.Euler(-90, 0, 0));

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Instantiate(Trees, new Vector3((i * 50.0f) - 220.0f, 38.0f, (j * 20.0f) + 50.0f), Quaternion.Euler(-90, 0, 0));

        for (int i = 0; i < 1; i++)
            for (int j = 0; j < 4; j++)
                Instantiate(RedCar, new Vector3((i * 50.0f) + 50.0f, 36.0f, (j * 20.0f) - 90.0f), Quaternion.identity);

        for (int i = 0; i < 1; i++)
            for (int j = 0; j < 4; j++)
                Instantiate(GreenCar, new Vector3((i * 50.0f) + 20.0f, 36.0f, (j * 20.0f) - 90.0f), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
