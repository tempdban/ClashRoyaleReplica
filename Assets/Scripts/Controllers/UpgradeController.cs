using UnityEngine;
using System.Collections;

public class UpgradeController : Singleton<UpgradeController> {

	Tower towerUpgrade;
	UpgradeScreenReferences upgradeScreenRef;

	public void ShowUpgradeDialogue(Tower tower, UpgradeScreenReferences upgradeScreenReferences)
    {
		upgradeScreenRef = upgradeScreenReferences;
        towerUpgrade = tower;
		GameController.Instance.IsUIOpen = true;
		upgradeScreenRef.gameObject.SetActive(true);

		if (towerUpgrade.playerType == Constants.PLAYER_1) {
			if (towerUpgrade.upgradeCost > GameModel.Instance.Player1Revenue) {
				upgradeScreenRef.upgradeButton.enabled = false;
			}
		}
		else if (towerUpgrade.playerType == Constants.PLAYER_2) {
			if (towerUpgrade.upgradeCost > GameModel.Instance.Player2Revenue) {
				upgradeScreenRef.upgradeButton.enabled = false;
			}
		}
        Debug.Log("Popup Opened");
    }

    public void UpgradeTower()
    {
		GameController.Instance.WithdrawFromPlayerRevenue (towerUpgrade.playerType, towerUpgrade.upgradeCost);

        float percentageHealthIncrease = towerUpgrade.GetComponent<Tower>().totalHealth * (GameModel.Instance.HealthIncreasePerUpgrade / 100.0f);
        towerUpgrade.totalHealth += percentageHealthIncrease;
        percentageHealthIncrease = towerUpgrade.GetComponent<Tower>().CurrentHealth * (GameModel.Instance.HealthIncreasePerUpgrade / 100.0f);
        towerUpgrade.CurrentHealth += percentageHealthIncrease;
		HideUpgradeDialogue ();
    }

	public void HideUpgradeDialogue()
	{
		GameController.Instance.IsUIOpen = false;
		upgradeScreenRef.gameObject.SetActive(false);
	}
}
