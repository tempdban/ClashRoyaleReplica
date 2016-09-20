using UnityEngine;
using System.Collections;

public class CharacterUpdateEvents : MonoBehaviour 
{
	public void CharacterUpdateButtonTapped(int buttonID)
	{
		CardMovementController.Instance.ShowCharacterUpgradePopup (buttonID);
	}
}
