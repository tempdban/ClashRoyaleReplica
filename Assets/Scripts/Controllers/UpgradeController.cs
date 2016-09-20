using UnityEngine;
using System.Collections;

public class UpgradeController : Singleton<UpgradeController> {

	Tower towerUpgrade;
	CharacterMover characterUpgrade;
	UpgradeScreenReferences upgradeScreenRef;

	public void ShowUpgradeDialogue(Tower tower, UpgradeScreenReferences upgradeScreenReferences)
    {
		upgradeScreenRef = upgradeScreenReferences;
        towerUpgrade = tower;
		GameController.Instance.IsUIOpen = true;
        upgradeScreenRef.itemNameLabel.text = tower.towerName;
        upgradeScreenRef.cost.text = "$ "+tower.upgradeCost.ToString();
		upgradeScreenRef.gameObject.SetActive(true);
		upgradeScreenRef.upgradeTowerButton.gameObject.SetActive (true);
		upgradeScreenRef.upgradeCharacterButton.gameObject.SetActive (false);

		if (towerUpgrade.playerType == Constants.PLAYER_1) {
			if (towerUpgrade.upgradeCost > GameModel.Instance.Player1Revenue) {
                upgradeScreenRef.cost.color=Color.red;
				upgradeScreenRef.upgradeTowerButton.enabled = false;
			}
            else
            {
                upgradeScreenRef.cost.color = Color.white;
				upgradeScreenRef.upgradeTowerButton.enabled = true;
            }
		}
		else if (towerUpgrade.playerType == Constants.PLAYER_2) {
			if (towerUpgrade.upgradeCost > GameModel.Instance.Player2Revenue) {
                upgradeScreenRef.cost.color = Color.red;
				upgradeScreenRef.upgradeTowerButton.enabled = false;
			}
            else
            {
                upgradeScreenRef.cost.color = Color.white;
				upgradeScreenRef.upgradeTowerButton.enabled = true;
            }
		}
        Debug.Log("Popup Opened");
    }

	public void ShowCharacterUpgradeDialogue(CharacterMover character, UpgradeScreenReferences upgradeScreenReferences)
	{
		upgradeScreenRef = upgradeScreenReferences;
		characterUpgrade = character;
		GameController.Instance.IsUIOpen = true;
		upgradeScreenRef.itemNameLabel.text = character.characterName;
		upgradeScreenRef.cost.text = "$ "+character.upgradeCost.ToString();
		upgradeScreenRef.gameObject.SetActive(true);
		upgradeScreenRef.upgradeTowerButton.gameObject.SetActive (false);
		upgradeScreenRef.upgradeCharacterButton.gameObject.SetActive (true);

		if (characterUpgrade.playerType == Constants.PLAYER_1) {
			if (characterUpgrade.upgradeCost > GameModel.Instance.Player1Revenue) {
				upgradeScreenRef.cost.color=Color.red;
				upgradeScreenRef.upgradeCharacterButton.enabled = false;
			}
			else
			{
				upgradeScreenRef.cost.color = Color.white;
				upgradeScreenRef.upgradeCharacterButton.enabled = true;
			}
		}
		else if (characterUpgrade.playerType == Constants.PLAYER_2) {
			if (characterUpgrade.upgradeCost > GameModel.Instance.Player2Revenue) {
				upgradeScreenRef.cost.color = Color.red;
				upgradeScreenRef.upgradeCharacterButton.enabled = false;
			}
			else
			{
				upgradeScreenRef.cost.color = Color.white;
				upgradeScreenRef.upgradeCharacterButton.enabled = true;
			}
		}
		Debug.Log("Popup Opened");
	}

    public void UpgradeTower()
    {
		GameController.Instance.WithdrawFromPlayerRevenue (towerUpgrade.playerType, towerUpgrade.upgradeCost);

        float percentageHealthIncrease = towerUpgrade.totalHealth * (GameModel.Instance.HealthIncreasePerUpgrade / 100.0f);
        towerUpgrade.totalHealth += percentageHealthIncrease;
        percentageHealthIncrease = towerUpgrade.CurrentHealth * (GameModel.Instance.HealthIncreasePerUpgrade / 100.0f);
        towerUpgrade.CurrentHealth += percentageHealthIncrease;
		HideUpgradeDialogue ();
    }

	public void UpgradeCharacter()
	{
		GameController.Instance.WithdrawFromPlayerRevenue (characterUpgrade.playerType, characterUpgrade.upgradeCost);

		float percentageHealthIncrease = characterUpgrade.totalHealth * (GameModel.Instance.HealthIncreasePerUpgrade / 100.0f);
		characterUpgrade.totalHealth += percentageHealthIncrease;
		HideUpgradeDialogue ();
	}

	public void HideUpgradeDialogue()
	{
		GameController.Instance.IsUIOpen = false;
		upgradeScreenRef.gameObject.SetActive(false);
	}
    public void CancelUpgrade()
    {
        HideUpgradeDialogue();
    }
}
