using UnityEngine;
using System.Collections;

public class UpdateScreenEvents : MonoBehaviour {

	public void Upgrade(int upgradeType)
    {
		if(upgradeType == 1)
        	UpgradeController.Instance.UpgradeTower();
		else if(upgradeType == 2)
			UpgradeController.Instance.UpgradeCharacter();
    }
    public void CancelUpgrade()
    {
        UpgradeController.Instance.CancelUpgrade();
    }

}
