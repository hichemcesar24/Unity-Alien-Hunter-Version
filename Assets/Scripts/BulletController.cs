using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float moveSpeed;

	public GameObject bulletImpact;

	public bool hurtPlayer;

	public GameObject enemyExplosion;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Instantiate(bulletImpact, transform.position, transform.rotation);
		Destroy(gameObject);

		if(other.tag == "Enemy")
		{
			FindObjectOfType<GameManager>().dropPowerUp(other.transform.position);

			FindObjectOfType<GameManager>().AddScore(other.GetComponent<PointValue>().value);

			Instantiate(enemyExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}

		if(other.tag == "Player" && hurtPlayer)
		{
			FindObjectOfType<GameManager>().KillPlayer();
		}

		if(other.tag == "Shield")
		{
			other.gameObject.SetActive(false);
		}

		if(other.tag == "BossLaserTop" && Boss1.canBeHurt)
		{
			FindObjectOfType<Boss1>().topHandHealth -= 1;
		}

		if(other.tag == "BossLaserBottom" && Boss1.canBeHurt)
		{
			FindObjectOfType<Boss1>().bottomHandHealth -= 1;
		}

		if(other.tag == "BossMain" && Boss1.canBeHurt)
		{
			FindObjectOfType<Boss1>().mainHealth -= 1;
		}
	}


	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}