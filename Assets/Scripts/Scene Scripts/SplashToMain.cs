using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashToMain : MonoBehaviour {

    public string sceneName = "Test_Scene";

    private float delta;

	// Use this for initialization
	void Start () {
        delta = 0;
	}
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;

        if (delta > 2)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
}
