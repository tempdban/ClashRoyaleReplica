using UnityEngine;
using System.Collections;

public class TrackIfPlayer1WithinRightBounds : MonoBehaviour 
{
	void OnTriggerStay2D(Collider2D other) 
	{
		if (other.tag == "Card" && GameModel.Instance.IsPlayer1CardHeld)
		{
//			other.GetComponent<Rigidbody2D> ().position = GameModel.Instance.Path3List[0];
			GameModel.Instance.HasPlayer1SelectedPath1 = false;
			GameModel.Instance.HasPlayer1SelectedPath2 = false;
			GameModel.Instance.HasPlayer1SelectedPath3 = true;
//			Debug.Log ("Path 3 Selected");
//			GameModel.Instance.IsPlayer1CardReleased = false;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Card" && GameModel.Instance.IsPlayer1CardHeld) {
			GameModel.Instance.HasPlayer1SelectedPath3 = false;
		}
	}
}
