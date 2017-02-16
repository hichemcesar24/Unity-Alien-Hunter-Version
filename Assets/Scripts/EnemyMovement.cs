using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float moveSpeedX;
	public float moveSpeedY;

	private Rigidbody2D theRB;

	public float XTarget;
	public float YTarget;

	public bool moveUp;

	public int moveType; // 0 - moving up at XTarget, 1 - moving down at XTarget, 2 - moving to point

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		switch(moveType)
		{
		case 0:
			if(transform.position.x < XTarget)
			{
				theRB.velocity = new Vector2(-moveSpeedX, -moveSpeedY);
			} else {
				theRB.velocity = new Vector2(-moveSpeedX, 0f);
			}
			break;

		case 1:
			if(transform.position.x < XTarget)
			{
				theRB.velocity = new Vector2(-moveSpeedX, moveSpeedY);
			} else {
				theRB.velocity = new Vector2(-moveSpeedX, 0f);
			}
			break;

		case 2:
			if(transform.position.x < XTarget)
			{
				if(moveUp)
				{
					if(transform.position.y > YTarget)
					{
						theRB.velocity = new Vector2(-moveSpeedX, 0f);
					} else {
						theRB.velocity = new Vector2(-moveSpeedX, moveSpeedY);
					}
				} else {
					if(transform.position.y < YTarget)
					{
						theRB.velocity = new Vector2(-moveSpeedX, 0f);
					} else {
						theRB.velocity = new Vector2(-moveSpeedX, -moveSpeedY);
					}
				}
			} else {
				theRB.velocity = new Vector2(-moveSpeedX, 0f);
			}
			break;
		}

	}


	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}