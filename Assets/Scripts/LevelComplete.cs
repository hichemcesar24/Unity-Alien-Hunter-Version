using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	public float timeToLoad;

	public string nextLevel;

	public GameManager theGM;

	// Use this for initialization
	void Start () {
		theGM = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		timeToLoad -= Time.deltaTime;
		if(timeToLoad <= 0)
		{
			PlayerPrefs.SetInt("HiScore", theGM.currentHiScore);
			PlayerPrefs.SetInt("CurrentScore", theGM.currentScore);
			PlayerPrefs.SetInt("CurrentLives", theGM.playerLives);

			SceneManager.LoadScene(nextLevel);
		}
	}

}