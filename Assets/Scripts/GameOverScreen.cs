using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	public void RestartLevel()
	{
		PlayerPrefs.SetInt("CurrentScore", 0);
		PlayerPrefs.SetInt("CurrentLives", 3);

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitToMain()
	{
		SceneManager.LoadScene("Main Menu");
	}

}