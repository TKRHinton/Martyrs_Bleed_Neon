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
	
	


}
