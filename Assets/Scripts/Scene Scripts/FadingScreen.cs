using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingScreen : MonoBehaviour {

	// Singleton Structure -> Its a fading transition and we want other scenes to use this as an access port.
	protected static FadingScreen sInstance;
	public static FadingScreen Instance
	{
		get{
			if(sInstance == null){
				GameObject Obj = new GameObject();
				sInstance = Obj.AddComponent<FadingScreen>();
				Destroy (Obj);
			}
			return sInstance;
		}
	}

	// Which Scene to load
	string SceneName = null;

	// Want to fade or not
	bool isFade = false;

	// Fading Variables
	float fadingAlpha = 1.0f;
	float fadingSpeed = 1.0f;

	// Fading canvas
	public Canvas FadePrefab;
	Canvas FadeImage;

	// Fading type
	public enum FadeType
	{
		FADEIN,
		FADEOUT
	};

	public FadeType Type;

	// Instantiate the fade
	void FadeInstantiate()
	{
		if(FadePrefab != null)
		{
			// Set and Instantiate the transformation, image to a Canvas
			FadeImage = Instantiate(FadePrefab, FadePrefab.transform.position, Quaternion.identity) as Canvas;
		}
	}

	// Use this for initialization
	void Start () {
		// Set the instance
		sInstance = this;
		
		// Start Fading in
		FadeStart(null, true);
	}

	// Fading process
	void DoFade(bool FadingMode){
		// Fade in
		if (FadingMode) {
			if (FadeImage.GetComponentInChildren<Image> ().color.a > 0.0f) {
				fadingAlpha -= Time.deltaTime * fadingSpeed;
			} else {
				isFade = false;
			}
		} 

		// Fade out
		else {
			if (FadeImage.GetComponentInChildren<Image> ().color.a < 1.0f) {
				fadingAlpha += Time.deltaTime * fadingSpeed;
			} else {
				isFade = false;
				Application.LoadLevel(SceneName);
			}
		}
	}

	// Start the Fade Function
	public void FadeStart(string SceneName, bool FadingMode = false)
	{
		// Don't straight away reset the fade
		if (isFade) {
			return;
		}

		// Set the scene to be loaded
		this.SceneName = SceneName;

		// Tell Unity to start the fading
		isFade = true;

		// Instantiate if the canvas doesnt exist
		if (FadeImage == null) {
			FadeInstantiate();
		}
		// Set the color
		Color defaultcolor = FadeImage.GetComponentInChildren<Image>().color;

		// Call Fade In, then Fade Out
		if (FadingMode) {
			this.Type = FadeType.FADEIN;
			FadeImage.GetComponentInChildren<Image> ().color = new Color (defaultcolor.r, defaultcolor.g, defaultcolor.b, 1.0f);
		} else {
			this.Type = FadeType.FADEOUT;
			FadeImage.GetComponentInChildren<Image>().color = new Color(defaultcolor.r, defaultcolor.g, defaultcolor.b, 0.0f);
		}
	}

	// Update is called once per frame
	void Update () {
		if (isFade) {
			switch(Type)
			{
			case FadeType.FADEIN:
				DoFade(true);
				break;
			case FadeType.FADEOUT:
				DoFade (false);
				break;
			}
			// Set the color
			Color defaultcolor = FadeImage.GetComponentInChildren<Image>().color;

			// Toggle the alpha
			FadeImage.GetComponentInChildren<Image>().color = new Color(defaultcolor.r, defaultcolor.g, defaultcolor.b, fadingAlpha);
		}
	}
}
