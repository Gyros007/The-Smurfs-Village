using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.None;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
