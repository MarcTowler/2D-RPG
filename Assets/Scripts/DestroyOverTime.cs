using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{
	public float timerToDestroy;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		timerToDestroy -= Time.deltaTime;

		if(timerToDestroy <= 0)
		{
			Destroy (gameObject);
		}
	}
}

