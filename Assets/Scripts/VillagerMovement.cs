using UnityEngine;
using System.Collections;

public class VillagerMovement : MonoBehaviour
{
	public float moveSpeed;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private Rigidbody2D rb;
	public bool isMoving;
	public float walkTime;
	public float waitTime;
	private float walkCounter;
	private float waitCounter;
	private int walkDirection;
	public Collider2D walkZone;
	private bool hasWalkZone = false;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();

		//Is a walking zone set?
		if (walkZone != null) {
			//set the minimum and maximum points that the villager is allowed to walk inside
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;

			hasWalkZone = true;
		}
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

				//Is there a boundary and if so, are we going outside it
				if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
					isMoving = false;
					waitCounter = waitTime;
				}

				break;
			
			//right
			case 1:
				rb.velocity = new Vector2 (moveSpeed, 0);

				if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
					isMoving = false;
					waitCounter = waitTime;
				}

				break;
			
			//down
			case 2:
				rb.velocity = new Vector2 (0, -moveSpeed);

				if (hasWalkZone && transform.position.y < minWalkPoint.y) {
					isMoving = false;
					waitCounter = waitTime;
				}

				break;
			
			//left
			case 3:
				rb.velocity = new Vector2 (-moveSpeed, 0);

				if (hasWalkZone && transform.position.x < minWalkPoint.x) {
					isMoving = false;
					waitCounter = waitTime;
				}

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

