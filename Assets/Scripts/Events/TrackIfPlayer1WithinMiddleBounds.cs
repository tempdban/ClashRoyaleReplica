using UnityEngine;
using System.Collections;

public class TrackIfPlayer1WithinMiddleBounds : MonoBehaviour 
{
	void OnTriggerStay2D(Collider2D other) 
	{
		if (GameModel.Instance.IsPlayer1CardHeld)
		{
//			other.GetComponent<Rigidbody2D> ().position = GameModel.Instance.Path2List[0];
			GameModel.Instance.HasPlayer1SelectedPath1 = false;
			GameModel.Instance.HasPlayer1SelectedPath2 = true;
			GameModel.Instance.HasPlayer1SelectedPath3 = false;
//			Debug.Log ("Path 2 Selected");
//			GameModel.Instance.IsPlayer1CardReleased = false;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (GameModel.Instance.IsPlayer1CardHeld) {
			GameModel.Instance.HasPlayer1SelectedPath2 = false;
		}
	}
}
