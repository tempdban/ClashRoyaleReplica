using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMover : MonoBehaviour 
{

	public int playerType;
	public float speed;
//	public GameObject characterCard;
//	private Animator anim;
	private int currentPosition;
	private Vector3 targetPosition;
	private List<Vector3> pathList;

	void Start()
	{
//		Debug.Log ("Start");
//		anim = GetComponent<Animator> ();
		currentPosition = 0;
		targetPosition = Vector3.zero;
	}

	void Update()
	{
		if (pathList == null) {
//			Debug.Log ("PathList NULL");
			if (playerType == Constants.PLAYER_1) {
				if (GameModel.Instance.HasPlayer1SelectedPath1) {
					pathList = GameModel.Instance.Path1List;
//					Debug.Log ("Path 1 List loaded");
				} else if (GameModel.Instance.HasPlayer1SelectedPath2) {
					pathList = GameModel.Instance.Path2List;
//					Debug.Log ("Path 2 List loaded");
				} else if (GameModel.Instance.HasPlayer1SelectedPath3) {
					pathList = GameModel.Instance.Path3List;
//					Debug.Log ("Path 3 List loaded");
				}
			} else if (playerType == Constants.PLAYER_2) {
				if (GameModel.Instance.HasPlayer2SelectedPath1) {
					pathList = GameModel.Instance.Path1ListReversed;
//					Debug.Log ("Path 1 Reverse List loaded");
				} else if (GameModel.Instance.HasPlayer2SelectedPath2) {
					pathList = GameModel.Instance.Path2ListReversed;
//					Debug.Log ("Path 2 Reverse List loaded");
				} else if (GameModel.Instance.HasPlayer2SelectedPath3) {
					pathList = GameModel.Instance.Path3ListReversed;
//					Debug.Log ("Path 3 Reverse List loaded");
				}
			}
			targetPosition = pathList [0];
			transform.position = targetPosition;
			GetComponent<Collider2D> ().enabled = false;
//			characterCard.GetComponent<Collider2D> ().enabled = false;
//			Destroy (characterCard);
//			float step = GameModel.Instance.Speed * Time.deltaTime;
//			card.transform.position = Vector3.MoveTowards (card.transform.position, player2CardInitialPosition, step);
		}

		if (pathList != null) {
//			Debug.Log ("PathList NOT NULL");
			float step = speed * Time.deltaTime;
			if (transform.position.Equals (targetPosition)) {
				currentPosition++;
			}

			if (currentPosition < pathList.Count) {
				targetPosition = pathList [currentPosition];

				transform.position = Vector3.MoveTowards (transform.position, targetPosition, step);
			} 
			else 
			{
				targetPosition = Vector3.zero;
			}
		}
	}
}
