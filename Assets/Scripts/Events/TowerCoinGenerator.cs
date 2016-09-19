using UnityEngine;
using System.Collections;

public class TowerCoinGenerator : Tower 
{
	public int percentageBenefitPerKill;
	private bool isHealthNotSet;

	void Update ()
	{
		if (GameModel.Instance.AreGameVariableReady && !isHealthNotSet) 
		{
			//setting up character data
			totalHealth = GameController.Instance.UpdateHealthDependingHealthTower(playerType, totalHealth);
			this.CurrentHealth = totalHealth;
			UpdateHealthBar();
			healthBar.color = Constants.PLAYER_HEALTH_BAR_COLORS[playerType - 1];
			healthBarBorder.color = Constants.PLAYER_HEALTH_BAR_BORDER_COLORS[playerType - 1];
			isHealthNotSet = true;
		}
	}

	private void UpdateHealthBar()
	{
		healthBar.transform.localScale = new Vector3((this.CurrentHealth / totalHealth), 1.0f, 1.0f);
	}

}
