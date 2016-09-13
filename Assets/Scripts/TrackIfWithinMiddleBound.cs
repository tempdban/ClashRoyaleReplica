using UnityEngine;
using System.Collections;

public class TrackIfWithinMiddleBound : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other) 
	{
		if (GameModel.Instance.IsCardReleased)
		{
			other.GetComponent<Rigidbody2D> ().position = new Vector2 (0.03f, -2.72f);
			GameModel.Instance.IsPath1Selected = false;
			GameModel.Instance.IsPath2Selected = true;
			GameModel.Instance.IsPath3Selected = false;
			Debug.Log ("Card Repositioned");
		}
	}
}
