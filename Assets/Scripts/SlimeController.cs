using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private bool moving;
    [SerializeField] float timeBetweenMove;
    private float timeBetweenMoveCounter;
    [SerializeField] float timeToMove;
    private float moveCounter;
    private Vector3 direction;
    [SerializeField] float reloadPause;
    private bool reloading;
    private GameObject thePlayer;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //moveCounter = timeToMove;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        moveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if(moving)
        {
            moveCounter -= Time.deltaTime;
            rb.velocity = direction;

            if(moveCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //moveCounter = timeToMove;
                moveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                direction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

        if(reloading)
        {
            reloadPause -= Time.deltaTime;

            if(reloadPause < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                thePlayer.SetActive(true);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.SetActive(false);
            reloading = true;
            thePlayer = collision.gameObject;
        }
    }
}
