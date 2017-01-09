using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	public AudioSource sound;

	// Use this for initialization
	void Start () {
		sound.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Button>().onClick.AddListener( ()=> PlaySound() );
	}

    private void PlaySound()
    {
        sound.Play();
    }
		
}
