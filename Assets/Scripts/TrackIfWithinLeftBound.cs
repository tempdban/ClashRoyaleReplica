using UnityEngine;
using System.Collections;

public class TrackIfWithinLeftBound : MonoBehaviour 
{

	void OnTriggerStay2D(Collider2D other) 
	{
		if (GameModel.Instance.IsCardReleased)
		{
			other.GetComponent<Rigidbody2D> ().position = new Vector2 (-0.79f, -2.72f);
			GameModel.Instance.IsPath1Selected = true;
			GameModel.Instance.IsPath2Selected = false;
			GameModel.Instance.IsPath3Selected = false;
			Debug.Log ("Card Repositioned");
		}
	}

}
