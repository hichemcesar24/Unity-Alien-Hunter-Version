using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public bool isShield;
	public bool isSpeed;
	public bool isDouble;
	public bool isExtraLife;

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(isShield)
			{
				other.GetComponent<PlayerController>().shield.SetActive(true);
				Destroy(gameObject);
			}

			if(isSpeed)
			{
				FindObjectOfType<GameManager>().ActivateSpeedPower();
				Destroy(gameObject);
			}

			if(isDouble)
			{
				other.GetComponent<PlayerController>().doubleShot = true;
				Destroy(gameObject);
			}

			if(isExtraLife)
			{
				FindObjectOfType<GameManager>().playerLives += 1;
				Destroy(gameObject);
			}
		}
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

}