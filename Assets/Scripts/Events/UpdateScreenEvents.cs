using UnityEngine;
using System.Collections;

public class UpdateScreenEvents : MonoBehaviour {

    public void Upgrade()
    {
        UpgradeController.Instance.UpgradeTower();
    }
    public void CancelUpgrade()
    {
        UpgradeController.Instance.CancelUpgrade();
    }

}
