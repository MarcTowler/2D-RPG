using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    [SerializeField] int currentLevel;
    [SerializeField] int currentXP;
    [SerializeField] int[] toLevelUp;
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;
    public int currentHP;
    public int currentAttack;
    public int currentDefense;

    private PlayerHealthManager playerHealth;

	// Use this for initialization
	void Start () {
        currentHP      = HPLevels[1];
        currentAttack  = attackLevels[1];
        currentDefense = defenseLevels[1];

        playerHealth = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentXP >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
	}

    public void AddExperience(int xpToAdd)
    {
        currentXP += xpToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP      = HPLevels[currentLevel];
        currentAttack  = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];

        playerHealth.playerMaxHealth = currentHP;
        playerHealth.playerCurrentHealth += currentHP + HPLevels[currentLevel - 1];
    }
}
