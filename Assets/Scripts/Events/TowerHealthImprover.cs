using UnityEngine;
using System.Collections;

public class TowerHealthImprover : Tower 
{
	public int percentageHealthImprove;

	void Start()
	{
		//setting up character data
		this.CurrentHealth = totalHealth;
		UpdateHealthBar();
		healthBar.color = Constants.PLAYER_HEALTH_BAR_COLORS[playerType - 1];
		healthBarBorder.color = Constants.PLAYER_HEALTH_BAR_BORDER_COLORS[playerType - 1];
	}

	private void UpdateHealthBar()
	{
		healthBar.transform.localScale = new Vector3((this.CurrentHealth / totalHealth), 1.0f, 1.0f);
	}
}
