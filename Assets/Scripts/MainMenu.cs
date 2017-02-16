using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string firstLevel;

	public GameObject continueButton;

	void Start()
	{
		if(PlayerPrefs.HasKey("FurthestLevelReached"))
		{
			continueButton.SetActive(true);
		}
	}

	public void StartGame()
	{
		SceneManager.LoadScene(firstLevel);

		PlayerPrefs.SetInt("CurrentLives", 3);
		PlayerPrefs.SetInt("CurrentScore", 0);

		if(!PlayerPrefs.HasKey("HiScore"))
		{
			PlayerPrefs.SetInt("HiScore", 0);
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void ContinueGame()
	{
		PlayerPrefs.SetInt("CurrentLives", 3);
		PlayerPrefs.SetInt("CurrentScore", 0);

		if(!PlayerPrefs.HasKey("HiScore"))
		{
			PlayerPrefs.SetInt("HiScore", 0);
		}

		SceneManager.LoadScene(PlayerPrefs.GetString("FurthestLevelReached"));
	}
}