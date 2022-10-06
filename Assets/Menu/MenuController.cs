using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	[Header("here")]
	public string _newGameLevel;
	private string levelToLoad;
	[SerializeField] private GameObject noSaveGameDialog = null;
	
	
	
	
	
	public void ExitButton()
	{
		Application.Quit();
	}
	
	


}
