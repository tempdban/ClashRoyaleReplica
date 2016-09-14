using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : Singleton<GameController> 
{
	GameReferences gameRef;
	GameObject gameContextObject;

	public void LoadGame(GameObject gameObject)
	{
		gameContextObject = gameObject;
		gameRef = gameContextObject.GetComponent<GameReferences> ();
		GameStartScreenController.Instance.ShowGameStartMenu (gameRef.gameStartScreenRef);
	}

	public void StartGame()
	{
		GameStartScreenController.Instance.HideGameStartMenu ();
		CardMovementController.Instance.Init (gameContextObject);
	}


}
