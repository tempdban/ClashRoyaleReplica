using UnityEngine;
using System.Collections;

public class TrackIfWithinRightBound : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other) 
	{
		if (GameModel.Instance.IsCardReleased)
		{
			other.GetComponent<Rigidbody2D> ().position = new Vector2 (0.9f, -2.72f);
			GameModel.Instance.IsPath1Selected = false;
			GameModel.Instance.IsPath2Selected = false;
			GameModel.Instance.IsPath3Selected = true;
			Debug.Log ("Card Repositioned");
		}
	}
}
