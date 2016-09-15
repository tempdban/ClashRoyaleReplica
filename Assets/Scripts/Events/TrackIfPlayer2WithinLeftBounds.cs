using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackIfPlayer2WithinLeftBounds : MonoBehaviour 
{
	void OnTriggerStay2D(Collider2D other) 
	{
		if (GameModel.Instance.IsPlayer2CardHeld)
		{
//			other.GetComponent<Rigidbody2D> ().position = GameModel.Instance.Path1ListReversed[0];
			GameModel.Instance.HasPlayer2SelectedPath1 = true;
			GameModel.Instance.HasPlayer2SelectedPath2 = false;
			GameModel.Instance.HasPlayer2SelectedPath3 = false;
//			Debug.Log ("Path 1 Reverse Selected");
//			GameModel.Instance.IsPlayer2CardReleased = false;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (GameModel.Instance.IsPlayer2CardHeld) {
			GameModel.Instance.HasPlayer2SelectedPath1 = false;
		}
	}
	
}
