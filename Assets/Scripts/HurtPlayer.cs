using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageNumber;
    private PlayerStats stats;

	// Use this for initialization
	void Start () {
        stats = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            currentDamage = damageToGive - stats.currentDefense;

            if(currentDamage <= 0)
            {
                currentDamage = 1;
            }

            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            GameObject clone = Instantiate(damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
