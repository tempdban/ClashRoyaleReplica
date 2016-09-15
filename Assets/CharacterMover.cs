using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMover : MonoBehaviour 
{

	public int playerType;
	public GameObject characterCard;
	private Animator anim;
//	private GameObject character;
	private int currentPosition;
	private Vector3 targetPosition;
	private List<Vector3> pathList;

//	public CharacterMover(int playerType, GameObject characterCard, Vector3 cardReturningPosition)
//	{
//		currentPosition = 0;
//		targetPosition = Vector3.zero;
//		this.playerType = playerType;
//		this.characterCard = characterCard;
//
//		CardReferences cardRef = characterCard.GetComponent<CardReferences> ();
//		if (cardRef.character != null)
//		{
//			Debug.Log ("Character prefab exists");
//			Debug.Log ("Card position:" + characterCard.transform.position);
//			Debug.Log ("Card rotation:" + characterCard.transform.rotation);
//			GameObject character =  Instantiate(cardRef.character, characterCard.transform.position, characterCard.transform.rotation) as GameObject;
//
//			Debug.Log ("Character Initialized");
//		}
//	}

	void Start()
	{
		anim = GetComponent<Animator> ();
		currentPosition = 0;
		targetPosition = Vector3.zero;
	}

	void Update()
	{
//		Debug.Log ("Update");
		if (pathList == null) {
			if (playerType == Constants.PLAYER_1) {
				if (GameModel.Instance.HasPlayer1SelectedPath1) {
					pathList = GameModel.Instance.Path1List;
					Debug.Log ("Path 1 List loaded");
				} else if (GameModel.Instance.HasPlayer1SelectedPath2) {
					pathList = GameModel.Instance.Path2List;
					Debug.Log ("Path 2 List loaded");
				} else if (GameModel.Instance.HasPlayer1SelectedPath3) {
					pathList = GameModel.Instance.Path3List;
					Debug.Log ("Path 3 List loaded");
				}
			} else if (playerType == Constants.PLAYER_2) {
				if (GameModel.Instance.HasPlayer2SelectedPath1) {
					pathList = GameModel.Instance.Path1ListReversed;
					Debug.Log ("Path 1 Reverse List loaded");
				} else if (GameModel.Instance.HasPlayer2SelectedPath2) {
					pathList = GameModel.Instance.Path2ListReversed;
					Debug.Log ("Path 2 Reverse List loaded");
				} else if (GameModel.Instance.HasPlayer2SelectedPath3) {
					pathList = GameModel.Instance.Path3ListReversed;
					Debug.Log ("Path 3 Reverse List loaded");
				}
			}
			targetPosition = pathList [0];
			transform.position = targetPosition;
			GetComponent<Collider2D> ().enabled = false;
			characterCard.GetComponent<Collider2D> ().enabled = false;
//			Destroy (characterCard);
//			float step = GameModel.Instance.Speed * Time.deltaTime;
//			card.transform.position = Vector3.MoveTowards (card.transform.position, player2CardInitialPosition, step);
		}

		if (pathList != null) {

			float step = GameModel.Instance.Speed * Time.deltaTime;
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













//	void Update()
//	{
//		Debug.Log ("Update");
//		if (pathList == null) {
//			if (playerType == Constants.PLAYER_1) {
//				if (GameModel.Instance.HasPlayer1SelectedPath1) {
//					pathList = GameModel.Instance.Path1List;
//					Debug.Log ("Path 1 List loaded");
//				} else if (GameModel.Instance.HasPlayer1SelectedPath2) {
//					pathList = GameModel.Instance.Path2List;
//					Debug.Log ("Path 2 List loaded");
//				} else if (GameModel.Instance.HasPlayer1SelectedPath3) {
//					pathList = GameModel.Instance.Path3List;
//					Debug.Log ("Path 3 List loaded");
//				}
//			} else if (playerType == Constants.PLAYER_2) {
//				if (GameModel.Instance.HasPlayer2SelectedPath1) {
//					pathList = GameModel.Instance.Path1List;
//					Debug.Log ("Path 1 Reverse List loaded");
//				} else if (GameModel.Instance.HasPlayer2SelectedPath2) {
//					pathList = GameModel.Instance.Path2List;
//					Debug.Log ("Path 2 Reverse List loaded");
//				} else if (GameModel.Instance.HasPlayer2SelectedPath3) {
//					pathList = GameModel.Instance.Path3List;
//					Debug.Log ("Path 3 Reverse List loaded");
//				}
//				pathList.Reverse ();
//			}
//			targetPosition = pathList [0];
//			character.GetComponent<Collider2D> ().enabled = false;
//			characterCard.GetComponent<Collider2D> ().enabled = false;
//			//			Destroy (characterCard);
//			//			float step = GameModel.Instance.Speed * Time.deltaTime;
//			//			card.transform.position = Vector3.MoveTowards (card.transform.position, player2CardInitialPosition, step);
//		}
//
//		if (pathList != null) {
//
//			float step = GameModel.Instance.Speed * Time.deltaTime;
//			if (character.transform.position.Equals (targetPosition)) {
//				currentPosition++;
//			}
//
//			if (currentPosition < pathList.Count) {
//				targetPosition = pathList [currentPosition];
//
//				character.transform.position = Vector3.MoveTowards (character.transform.position, targetPosition, step);
//			}
//		}
//	}







//		if (pathList == null) 
//		{
//			if (GameModel.Instance.IsPath1Selected)
//				pathList = GameModel.Instance.Path1List;
//			else if (GameModel.Instance.IsPath2Selected)
//				pathList = GameModel.Instance.Path2List;
//			else if (GameModel.Instance.IsPath3Selected)
//				pathList = GameModel.Instance.Path3List;
//		}
//
//		if (pathList != null) {
//
//			float step = GameModel.Instance.Speed * Time.deltaTime;
//			if (transform.position.Equals (targetPosition)) {
//				currentPosition++;
//			}
//
//			if (currentPosition < pathList.Count) {
//				targetPosition = pathList [currentPosition];
//
//				transform.position = Vector3.MoveTowards (transform.position, targetPosition, step);
//			}
//		}
//	}
}
