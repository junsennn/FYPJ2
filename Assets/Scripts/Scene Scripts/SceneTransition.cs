using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneName = "Test_Scene";
    public bool loadScene = true;
    public float duration = 2.0f;

    private float delta;

    // Use this for initialization
    void Start()
    {
        delta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        if (delta > duration)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
