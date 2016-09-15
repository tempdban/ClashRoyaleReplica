using UnityEngine;
using System.Collections;

public class TrackIfPlayer1WithinLeftBounds : MonoBehaviour 
{
	void OnTriggerStay2D(Collider2D other) 
	{
		if (GameModel.Instance.IsPlayer1CardHeld)
		{
//			other.GetComponent<Rigidbody2D> ().position = GameModel.Instance.Path1List[0];
			GameModel.Instance.HasPlayer1SelectedPath1 = true;
			GameModel.Instance.HasPlayer1SelectedPath2 = false;
			GameModel.Instance.HasPlayer1SelectedPath3 = false;
//			Debug.Log ("Path 1 Selected");
//			GameModel.Instance.IsPlayer1CardReleased = false;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (GameModel.Instance.IsPlayer1CardHeld) {
			GameModel.Instance.HasPlayer1SelectedPath1 = false;
		}
	}
}
