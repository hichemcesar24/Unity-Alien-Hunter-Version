using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject bullet;
	public Transform bulletPoint;

	public float shotDelay;
	private float shotCounter;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		shotCounter -= Time.deltaTime;

		if(shotCounter<= 0)
		{
			Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
			shotCounter = shotDelay;
		}
	}

}