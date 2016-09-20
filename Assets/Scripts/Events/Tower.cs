using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour 
{
	public int playerType;
	public int killEarning;
	public int upgradeCost;
	public float totalHealth;
	public string towerName;
	public SpriteRenderer healthBar;
	public SpriteRenderer healthBarBorder;
    private float currentHealth;

	public float CurrentHealth
	{
		get { return currentHealth; }
		set { currentHealth = value; }
	}

}
