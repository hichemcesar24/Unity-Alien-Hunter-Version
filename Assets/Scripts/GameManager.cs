using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Transform waveSpawnPoint;

	public GameObject[] waves;
	public float[] waveDelays;
	public bool spawningWaves;
	private int waveTracker;

	public GameObject[] powerUps;
	public int powerUpChance;

	public float powerUpLength;
	private float powerUpCounter;
	private float playerSpeed;
	private PlayerController thePlayer;

	public float speedMultiplier;

	public int playerLives;
	public Transform playerSpawnPoint;
	public GameObject explosion;
	public GameObject gameOverScreen;

	public Text livesText;
	public Text scoreText;

	public int currentScore;

	public GameObject bossBattle;

	public int currentHiScore;
	public Text hiScoreText;

	public GameObject pauseScreen;

	// Use this for initialization
	void Start () {

		currentHiScore = PlayerPrefs.GetInt("HiScore");
		currentScore = PlayerPrefs.GetInt("CurrentScore");
		playerLives = PlayerPrefs.GetInt("CurrentLives");

		thePlayer = FindObjectOfType<PlayerController>();
		playerSpeed = thePlayer.moveSpeed;

		livesText.text = "LIVES: " + playerLives;
		scoreText.text = currentScore + " :SCORE";
		hiScoreText.text = currentHiScore + " :HI-SCORE";

		PlayerPrefs.SetString("FurthestLevelReached", SceneManager.GetActiveScene().name);

		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void Update () {
		if(spawningWaves)
		{
			waveDelays[waveTracker] -= Time.deltaTime;

			if(waveDelays[waveTracker] < 0)
			{
				Instantiate(waves[waveTracker], waveSpawnPoint.position, waveSpawnPoint.rotation);

				waveTracker++;

				if(waveTracker >= waveDelays.Length)
				{
					spawningWaves = false;
					if(bossBattle != null)
					{
						bossBattle.SetActive(true);
					}
				}
			}
		}

		if(powerUpCounter > 0)
		{
			powerUpCounter -= Time.deltaTime;

			if(powerUpCounter <= 0)
			{
				thePlayer.moveSpeed = playerSpeed;
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			if(pauseScreen.activeSelf)
			{
				pauseScreen.SetActive(false);
				Time.timeScale = 1f;
			} else {
				pauseScreen.SetActive(true);
				Time.timeScale = 0;
			}
		}
	}


	public void dropPowerUp(Vector3 enemyPosition)
	{
		if(Random.Range(0, 100) < powerUpChance)
		{
			Instantiate(powerUps[Random.Range(0, powerUps.Length)], enemyPosition, new Quaternion(0,0,0,0));
		}
	}

	public void ActivateSpeedPower()
	{
		powerUpCounter = powerUpLength;
		thePlayer.moveSpeed = playerSpeed * speedMultiplier;

		Debug.Log("Picked");
	}

	public void KillPlayer()
	{
		playerLives -= 1;
		livesText.text = "LIVES: " + playerLives;

		if(playerLives >= 0)
		{
			Instantiate(explosion, thePlayer.transform.position, thePlayer.transform.rotation);
			thePlayer.gameObject.SetActive(false);
			thePlayer.moveSpeed = playerSpeed;
			thePlayer.doubleShot = false;
			thePlayer.transform.position = playerSpawnPoint.position;
			thePlayer.gameObject.SetActive(true);
			thePlayer.shield.SetActive(true);
		} else {
			livesText.text = "ALL LIVES LOST";
			Instantiate(explosion, thePlayer.transform.position, thePlayer.transform.rotation);
			thePlayer.gameObject.SetActive(false);
			gameOverScreen.SetActive(true);
			Time.timeScale = 0f;
		}

		PlayerPrefs.SetInt("CurrentLives", playerLives);
	}

	public void AddScore(int scoreToAdd)
	{
		currentScore += scoreToAdd;
		scoreText.text = currentScore + " :SCORE";

		if(currentScore > currentHiScore)
		{
			currentHiScore = currentScore;
			hiScoreText.text = currentHiScore + " :HI-SCORE";
		}
	}
}