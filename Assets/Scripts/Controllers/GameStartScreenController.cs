using UnityEngine;
using System.Collections;

public class GameStartScreenController : Singleton<GameStartScreenController>
{
	GameStartScreenReferences gameStartScreenRef;

	public void ShowGameStartMenu(GameStartScreenReferences gameStartScreenReference)
	{
		gameStartScreenRef = gameStartScreenReference;
		gameStartScreenRef.gameObject.SetActive (true);
	}

	public void HideGameStartMenu()
	{
		gameStartScreenRef.gameObject.SetActive (false);
	}


}
