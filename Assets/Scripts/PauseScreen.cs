using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void ResumeGame()
	{
		gameObject.SetActive(false);
		Time.timeScale = 1f;
	}

	public void QuitToMain()
	{
		SceneManager.LoadScene("Main Menu");
		Time.timeScale = 1f;
	}

	public void QuitToDesktop()
	{
		Application.Quit();
		Time.timeScale = 1f;
	}

}