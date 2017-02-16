using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D theRB;

	public float moveSpeed;
	public Vector2 moveInput;
	public Transform topLeft;
	public Transform bottomRight;

	private Animator anim;

	public GameObject bullet;
	public Transform bulletPoint;

	public float shotDelay;
	private float shotCounter;

	public GameObject shield;

	public bool doubleShot;
	public Transform doubleShot1;
	public Transform doubleShot2;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		theRB.velocity = moveInput * moveSpeed;

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, topLeft.position.x, bottomRight.position.x), Mathf.Clamp(transform.position.y, bottomRight.position.y, topLeft.position.y), transform.position.z);

		anim.SetFloat("Movement", moveInput.y);

		if(Input.GetButtonDown("Fire1"))
		{
			if(doubleShot)
			{
				Instantiate(bullet, doubleShot1.position, doubleShot1.rotation);
				Instantiate(bullet, doubleShot2.position, doubleShot2.rotation);
			} else {
				Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
			}

			shotCounter = shotDelay;
		}

		if(Input.GetButton("Fire1"))
		{
			shotCounter -= Time.deltaTime;

			if(shotCounter <= 0)
			{
				if(doubleShot)
				{
					Instantiate(bullet, doubleShot1.position, doubleShot1.rotation);
					Instantiate(bullet, doubleShot2.position, doubleShot2.rotation);
				} else {
					Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
				}

				shotCounter = shotDelay;
			}
		}
	}

}