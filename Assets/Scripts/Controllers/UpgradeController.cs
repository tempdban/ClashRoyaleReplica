using UnityEngine;
using System.Collections;

public class UpgradeController : Singleton<UpgradeController> {

    GameObject towerUpgrade;
    GameReferences gameRef;

    public void ShowUpgradeDialogue(GameObject tower, GameReferences gameReference)
    {
        gameRef = gameReference;
        towerUpgrade = tower;
        gameRef.upgradeScreen.SetActive(true);
        Debug.Log("Popup Opened");
    }

    public void UpgradeTower()
    {
        float percentageHealthIncrease = towerUpgrade.GetComponent<Tower>().totalHealth * (GameModel.Instance.HealthIncreasePerUpgrade / 100.0f);
        towerUpgrade.GetComponent<Tower>().totalHealth += percentageHealthIncrease;
        percentageHealthIncrease = towerUpgrade.GetComponent<Tower>().CurrentHealth * (GameModel.Instance.HealthIncreasePerUpgrade / 100.0f);
        towerUpgrade.GetComponent<Tower>().CurrentHealth += percentageHealthIncrease;
        gameRef.upgradeScreen.SetActive(false);
    }
}
