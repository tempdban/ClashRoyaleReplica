using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : Singleton<GameController> 
{
	GameReferences gameRef;
	GameObject gameContextObject;

	public void LoadGame(GameObject gameObject)
	{
		gameContextObject = gameObject;
		gameRef = gameContextObject.GetComponent<GameReferences> ();
		GameModel.Instance.AreGameVariableReady = true;
		UpdatePlayersRevenueLabels ();
		GameStartScreenController.Instance.ShowGameStartMenu (gameRef.gameStartScreenRef);

//		Debug.Log ("Path1 List: ");
//		int count1 = 0;
//		foreach(Vector3 position in GameModel.Instance.Path1List)
//		{
//			Debug.Log (count1 + ": " + position);
//			count1++;
//		}
//			
//		Debug.Log ("Path1 List Reversed: ");
//		int count = 0;
//		foreach(Vector3 position in GameModel.Instance.Path1ListReversed)
//		{
//			Debug.Log (count + ": " + position);
//			count++;
//		}
//
//		Debug.Log ("Path1 List Again: ");
//		int count2 = 0;
//		foreach(Vector3 position in GameModel.Instance.Path1List)
//		{
//			Debug.Log (count2 + ": " + position);
//			count2++;
//		}

	}
	public void StartGame()
	{
		GameStartScreenController.Instance.HideGameStartMenu ();
		CardMovementController.Instance.Init (gameContextObject);
	}

	public void UpdatePlayerRevenue(int playerType, int killEarning)
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

}
