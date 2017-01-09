using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class OptionManager : MonoBehaviour {

	public Toggle fullscreenToggle;
	public Dropdown resolutionDropDown;
	public Dropdown textureDropDown;
	public Dropdown vSyncDropDown;
	public Slider musicVolumeSlider;
	public Button applyButton;

	public Resolution[] resolutions;
	public AudioSource bgMusic;

	private OptionSettings optionSettings;

	void OnEnable()
	{
		optionSettings = new OptionSettings ();

		fullscreenToggle.onValueChanged.AddListener (delegate {OnFullScreenToggle (); });
		resolutionDropDown.onValueChanged.AddListener (delegate {OnResolutionChange (); });
		textureDropDown.onValueChanged.AddListener (delegate {OnTextureQualityChange (); });
		vSyncDropDown.onValueChanged.AddListener (delegate {OnVSyncChange (); });
		musicVolumeSlider.onValueChanged.AddListener (delegate {OnMusicVolumeChange (); });
		applyButton.onClick.AddListener(delegate {OnApplyButtonClick(); });

        // For the number of resolutions.

        //int counter = 0;
		resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) {
			resolutionDropDown.options.Add (new Dropdown.OptionData (resolution.ToString ()));
            //resolutionDropDown.options[counter].text
            //counter += 1;
		}
	}

	public void OnFullScreenToggle()
	{
		optionSettings.isFullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}

	public void OnResolutionChange()
	{
		Screen.SetResolution (resolutions [resolutionDropDown.value].width, resolutions [resolutionDropDown.value].height, Screen.fullScreen);
		optionSettings.resolutionIndex = resolutionDropDown.value;
	}

	public void OnTextureQualityChange()
	{
		QualitySettings.masterTextureLimit = optionSettings.textureQuality = textureDropDown.value;
	}

	public void OnVSyncChange()
	{
		QualitySettings.vSyncCount = optionSettings.vSync = vSyncDropDown.value;
	}

	public void OnMusicVolumeChange()
	{
		bgMusic.volume = optionSettings.musicVolume = musicVolumeSlider.value;
	}

	public void OnApplyButtonClick()
	{
		SaveSettings ();
	}

	// Write the saved settings to a new file using Json, and reading from it.
	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson (optionSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/OptionSettings.json",jsonData);
	}

	public void LoadSettings()
	{
		optionSettings = JsonUtility.FromJson<OptionSettings> (File.ReadAllText(Application.persistentDataPath + "/OptionSetting.json"));
		fullscreenToggle.isOn = optionSettings.isFullscreen;
		resolutionDropDown.value = optionSettings.resolutionIndex;
		resolutionDropDown.RefreshShownValue ();
		textureDropDown.value = optionSettings.textureQuality;
		vSyncDropDown.value = optionSettings.vSync;
		musicVolumeSlider.value = optionSettings.musicVolume;
	}
}
