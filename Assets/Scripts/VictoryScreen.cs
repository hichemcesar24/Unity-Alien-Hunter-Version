using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour {

	public Text playerScore;

	// Use this for initialization
	void Start () {
		playerScore.text = PlayerPrefs.GetInt("CurrentScore") + " points!";
	}

	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
		{
			SceneManager.LoadScene("Main Menu");
		}
	}

}