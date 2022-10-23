using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
	
	[Header("Volume Settings")]
	[SerializeField] private Slider volumeSlider = null;
	
	[Header("Graphics Settings")]
	private int _qualityLevel;
	private bool _isFullscreen;
	
	public TMP_Dropdown resolutionDropdown;
	private Resolution[] resolutions;
	
	
	[Header("Levels to load")]
	public string _newGameLevel;
	private string levelToLoad;
	[SerializeField] private GameObject noSaveGameDialog = null;
	
	
	private void Start()
	{
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();
		
		List<string> options = new List<string>();
		
		int currentResolutionsIndex = 0;
		
		for (int i = 0; i < resolutions.Length; i++) {
			
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);
			
			if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
			{
				currentResolutionsIndex = i;
			}
				
		}
		
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionsIndex;
		resolutionDropdown.RefreshShownValue();
	}
	
	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width,resolution.width, Screen.fullScreen);
	}
	
	
	
	
	public void	PlayNewGame ()
	{
		Debug.Log ("Start New Game");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		
	}
	
	
	public void ExitButton()
	{
		Debug.Log ("Quit!");
		Application.Quit();
	}
	
	
	public void SetVolume(float volume)
	{
		AudioListener.volume = volume;
		VolumeApply();
	}
	
	public void VolumeApply()
	{
		PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
	}
	
	
	public void SetFullScreen(string isFullScreen)
	{
		Debug.Log("Output" + isFullScreen + "ffff");
		
		//	_isFullscreen = isFullScreen;
		
		//	PlayerPrefs.SetInt("masterFullscreen", (_isFullscreen ? 1 : 0));
		//	Screen.fullScreen = _isFullscreen;
		
	}
	
	public void SetQuality(int QualityIndex)
	{
		_qualityLevel = QualityIndex;
		
		PlayerPrefs.SetInt("masterQuality", _qualityLevel);
		QualitySettings.SetQualityLevel(_qualityLevel);
	}


}
