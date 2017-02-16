using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shield")
		{
			other.gameObject.SetActive(false);
			Destroy(gameObject);
		}

		if(other.gameObject.tag == "Player")
		{
			FindObjectOfType<GameManager>().KillPlayer();
			Destroy(gameObject);
		}


	}

}