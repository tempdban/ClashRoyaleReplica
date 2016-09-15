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


}
