using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : Singleton<GameController> 
{
	GameReferences gameRef;
	GameObject gameContextObject;
	bool isUIOpen;

	public bool IsUIOpen 
	{
		get; 
		set;
	}

	public void LoadGame(GameObject gameObject)
	{
		gameContextObject = gameObject;
		gameRef = gameContextObject.GetComponent<GameReferences> ();
		GameModel.Instance.AreGameVariableReady = true;
		UpdatePlayersRevenueLabels ();
		GameStartScreenController.Instance.ShowGameStartMenu (gameRef.gameStartScreenRef);

	}
	public void StartGame()
	{
		GameStartScreenController.Instance.HideGameStartMenu ();
		CardMovementController.Instance.Init (gameContextObject);
	}

	public void DepositInPlayerRevenue(int playerType, int killEarning)
	{
		if (playerType == Constants.PLAYER_1) 
		{
			if (gameRef.player1CoinTower != null && gameRef.player1CoinTower.GetComponent<TowerCoinGenerator> ().CurrentHealth > 0) 
			{
				int percentageEarningIncrease = Mathf.CeilToInt(killEarning * (gameRef.player1CoinTower.GetComponent<TowerCoinGenerator> ().percentageBenefitPerKill / 100.0f));
				GameModel.Instance.Player1Revenue += (killEarning + percentageEarningIncrease);
			} 
			else
			{
				GameModel.Instance.Player1Revenue += killEarning;
			}
		} 
		else if (playerType == Constants.PLAYER_2) 
		{
			if (gameRef.player2CoinTower != null && gameRef.player2CoinTower.GetComponent<TowerCoinGenerator> ().CurrentHealth > 0) 
			{
				int percentageEarningIncrease = Mathf.CeilToInt(killEarning * (gameRef.player2CoinTower.GetComponent<TowerCoinGenerator> ().percentageBenefitPerKill / 100.0f));
				GameModel.Instance.Player2Revenue += (killEarning + percentageEarningIncrease);
			} 
			else
			{
				GameModel.Instance.Player2Revenue += killEarning;
			}
		}

		UpdatePlayersRevenueLabels ();
	}

	public void WithdrawFromPlayerRevenue(int playerType, int cost)
	{
		if (playerType == Constants.PLAYER_1) {
			GameModel.Instance.Player1Revenue -= cost;
		}
		else if (playerType == Constants.PLAYER_2) {
			GameModel.Instance.Player2Revenue -= cost;
		}

		UpdatePlayersRevenueLabels ();
	}

	public void UpdatePlayersRevenueLabels()
	{
		gameRef.player1RevenueLabel.text = "$ " + GameModel.Instance.Player1Revenue.ToString();
		gameRef.player2RevenueLabel.text = "$ " + GameModel.Instance.Player2Revenue.ToString();
	}

	public float UpdateHealthDependingHealthTower(int playerType, float health)
	{
		if (playerType == Constants.PLAYER_1) 
		{
			if (gameRef.player1HealthTower != null && gameRef.player1HealthTower.GetComponent<TowerHealthImprover> ().CurrentHealth > 0) 
			{
				float percentageHealthIncrease = health * (gameRef.player1HealthTower.GetComponent<TowerHealthImprover> ().percentageHealthImprove / 100.0f);
				return (health + percentageHealthIncrease);
			} 
			else
			{
				float percentageHealthIncrease = health * (5.0f/ 100.0f);
				return (health - percentageHealthIncrease);
			}
		} 
		else
		{
			if (gameRef.player2HealthTower != null && gameRef.player2HealthTower.GetComponent<TowerHealthImprover> ().CurrentHealth > 0) 
			{
				float percentageHealthIncrease = health * (gameRef.player2HealthTower.GetComponent<TowerHealthImprover> ().percentageHealthImprove / 100.0f);
				return (health + percentageHealthIncrease);
			} 
			else
			{
				float percentageHealthIncrease = health * (5.0f/ 100.0f);
				return (health - percentageHealthIncrease);
			}
		}
	}
	public void ShowUpgradePopup(Tower tower)
    {
		UpgradeController.Instance.ShowUpgradeDialogue(tower, gameRef.upgradeScreenRef);
    }

}
