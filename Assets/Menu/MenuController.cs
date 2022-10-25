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
		//PlayerPrefs.DeleteAll();
		Debug.Log ("Start!!");
		
		resolutions = Screen.resolutions; // Collects Users Screen Resolutions
		resolutionDropdown.ClearOptions(); // Clears Drop down
		
		List<string> options = new List<string>();
		
		int currentResolutionsIndex = 0;
		
		for (int i = 0; i < resolutions.Length; i++) { //collects all resolutions in an array 
			
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);
			
			if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
			{
				currentResolutionsIndex = i;
			}
				
		}
		
		//Adds array to dropdown
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionsIndex;
		resolutionDropdown.RefreshShownValue();
	}
	
	public void SetResolution(int resolutionIndex)
	{
		//Set Resolution of Game 
		Debug.Log (resolutions[resolutionIndex]);
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
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
	
	
	public void SetFullScreen(int isFullScreen)
	{
		bool fullScreen = true;
		
		if (isFullScreen == 0)
		{
			fullScreen = true;
		}
		else {fullScreen = false;}
		
		
		_isFullscreen = fullScreen;
		
		Debug.Log(fullScreen);
		
		PlayerPrefs.SetInt("masterFullscreen", (_isFullscreen ? 1 : 0));
		Screen.fullScreen = _isFullscreen;
	}
	
	public void SetQuality(int QualityIndex)
	{
		_qualityLevel = QualityIndex;
		
		PlayerPrefs.SetInt("masterQuality", _qualityLevel);
		QualitySettings.SetQualityLevel(_qualityLevel);
		Debug.Log(QualitySettings.currentLevel); //log quality level
	}
	
	
	public void setDefault()
	{
		QualitySettings.SetQualityLevel(3); //Ultra 
		Screen.fullScreen = true; //Fullscreen
		Screen.SetResolution(1920,1080, Screen.fullScreen);
		
		
		
	}


}
