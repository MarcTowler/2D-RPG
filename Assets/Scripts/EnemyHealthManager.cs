using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{

	public int MaxHealth;
	public int CurrentHealth;

	private PlayerStats thePS;
	public int expToGive;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;	
		thePS = FindObjectOfType<PlayerStats> ();
	}

	// Update is called once per frame
	void Update () {
		if(CurrentHealth <= 0)
		{
			Destroy (gameObject);

			thePS.AddExperience (expToGive);
		}
	}

	public void HurtEnemy(int damage)
	{
		CurrentHealth -= damage;
	}

	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth;
	}
}

