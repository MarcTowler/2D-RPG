using UnityEngine;
using System.Collections;

public class VillagerMovement : MonoBehaviour
{
	public float moveSpeed;
	private Rigidbody2D rb;
	public bool isMoving;
	public float walkTime;
	public float waitTime;
	private float walkCounter;
	private float waitCounter;
	private int walkDirection;
	public Collider2D walkZone;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isMoving) {
			walkCounter -= Time.deltaTime;

			switch (walkDirection) {

			//up
			case 0:
				rb.velocity = new Vector2 (0, moveSpeed);
				break;
			
			//right
			case 1:
				rb.velocity = new Vector2 (moveSpeed, 0);
				break;
			
			//down
			case 2:
				rb.velocity = new Vector2 (0, -moveSpeed);
				break;
			
			//left
			case 3:
				rb.velocity = new Vector2 (-moveSpeed, 0);
				break;
			}

			if (walkCounter < 0) {
				isMoving = false;
				walkCounter = waitTime;
			}
		} else {
			waitCounter -= Time.deltaTime;

			if (waitCounter < 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection()
	{
		walkDirection = Random.Range (0, 4);
		isMoving = true;
		walkCounter = walkTime;

	}
}

