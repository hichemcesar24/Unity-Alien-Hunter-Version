using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour {

	public float moveSpeedX;
	public float moveSpeedY;

	private Rigidbody2D theRB;

	public float rotateSpeed;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		theRB.velocity = new Vector2(moveSpeedX, moveSpeedY);

		transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (Random.Range(rotateSpeed / 2f, rotateSpeed) * Time.deltaTime));
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

}