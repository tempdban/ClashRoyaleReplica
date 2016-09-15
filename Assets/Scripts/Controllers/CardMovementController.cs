using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardMovementController : Singleton<CardMovementController> 
{
	CardMovementReferences cardMovementRef;
	private bool shouldAllowCardDragging;
	private Dictionary<int, GameObject> tappedCardsDictionary;
	private GameObject player1Card;
	private Vector3 player1CardInitialPosition;
	private GameObject player2Card;
	private Vector3 player2CardInitialPosition;

	public void Init(GameObject gameObject)
	{
		cardMovementRef = gameObject.GetComponent<CardMovementReferences> ();
		shouldAllowCardDragging = true;
		tappedCardsDictionary = new Dictionary<int, GameObject> ();
	}

	void FixedUpdate()
	{
		if (shouldAllowCardDragging)
		{
			int tapCount = Input.touchCount;
			for (int i = 0; i < tapCount; i++) 
			{
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began || (Input.GetMouseButtonDown(0)))
				{
					Debug.Log ("Touch Began # " + i);
					Vector3 worldPoint = Camera.main.ScreenToWorldPoint (touch.position);
					for (int j = 0; j < cardMovementRef.playerCards.Length; j++) 
					{
						GameObject card = cardMovementRef.playerCards [j];
						if (card.GetComponent<Collider2D> ().OverlapPoint (worldPoint)) 
						{
							Debug.Log ("Inside");

							if (player1Card == null && j < cardMovementRef.playerCards.Length / 2)
							{
								player1Card = card;
								player1CardInitialPosition = card.transform.position;
								tappedCardsDictionary.Add (touch.fingerId, card);
								Debug.Log ("Player Card 1 Assigned");
								Debug.Log ("Touch # " + touch.fingerId);
								Debug.Log ("Card # " + j);
								break;
							} 
							else if (player2Card == null && j < cardMovementRef.playerCards.Length)
							{
								player2Card = card;
								player2CardInitialPosition = card.transform.position;
								tappedCardsDictionary.Add (touch.fingerId, card);
								Debug.Log ("Player Card 2 Assigned");
								Debug.Log ("Touch # " + touch.fingerId);
								Debug.Log ("Card # " + j);
								break;
							}
							else if(player1Card != null)
							{
								Debug.Log ("Player Card 1 Not Null");
								Debug.Log ("Card # " + j);
							}
							else if(player2Card != null)
							{
								Debug.Log ("Player Card 2 Not Null");
								Debug.Log ("Card # " + j);
							}

						} 

					}

				}

				if (tappedCardsDictionary.ContainsKey (touch.fingerId) && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)) 
				{
					Vector3 worldPoint = Camera.main.ScreenToWorldPoint (touch.position);
					GameObject card = null;
					if (tappedCardsDictionary.TryGetValue (touch.fingerId, out card))
					{
						Rigidbody2D rb = card.GetComponent<Rigidbody2D> ();
						rb.position = worldPoint;
						if (card.Equals (player1Card))
						{
							rb.position = new Vector2 (
								Mathf.Clamp (rb.position.x, cardMovementRef.player1Boundary.xMin, cardMovementRef.player1Boundary.xMax), 
								Mathf.Clamp (rb.position.y, cardMovementRef.player1Boundary.yMin, cardMovementRef.player1Boundary.yMax));
						}
						else if (card.Equals (player2Card))
						{
							rb.position = new Vector2 (
								Mathf.Clamp (rb.position.x, cardMovementRef.player2Boundary.xMin, cardMovementRef.player2Boundary.xMax), 
								Mathf.Clamp (rb.position.y, cardMovementRef.player2Boundary.yMin, cardMovementRef.player2Boundary.yMax));
						}
					}


				}

				if (tappedCardsDictionary.ContainsKey (touch.fingerId) && touch.phase == TouchPhase.Ended) 
				{
					Debug.Log ("Touch End # " + touch.fingerId);
					GameObject card = null;
					if (tappedCardsDictionary.TryGetValue (touch.fingerId, out card)) 
					{
						if (card.Equals (player1Card)) 
						{
							player1Card = null;
							Debug.Log ("Player Card 1 Nullified");
							GameModel.Instance.IsPlayer1CardReleased = true;
//							CharacterMover characterMover = new CharacterMover (Constants.PLAYER_1, card, player1CardInitialPosition);
							CardReferences cardRef = card.GetComponent<CardReferences> ();
							if (cardRef.character != null)
							{
								GameObject character = Instantiate(cardRef.character, card.transform.position, card.transform.rotation) as GameObject;
								character.GetComponent<CharacterMover> ().playerType = Constants.PLAYER_1;
								character.GetComponent<CharacterMover> ().characterCard = card;
							}
//							float step = GameModel.Instance.Speed * Time.deltaTime;
//							card.transform.position = Vector3.MoveTowards (card.transform.position, player1CardInitialPosition, step);
						} 
						else if (card.Equals (player2Card)) 
						{
							player2Card = null;
							Debug.Log ("Player Card 2 Nullified");
							GameModel.Instance.IsPlayer2CardReleased = true;
//							CharacterMover characterMover = new CharacterMover (Constants.PLAYER_2, card, player2CardInitialPosition);
							CardReferences cardRef = card.GetComponent<CardReferences> ();
							if (cardRef.character != null)
							{
								GameObject character = Instantiate(cardRef.character, card.transform.position, card.transform.rotation) as GameObject;
								character.GetComponent<CharacterMover> ().playerType = Constants.PLAYER_2;
								character.GetComponent<CharacterMover> ().characterCard = card;
							}
//							float step = GameModel.Instance.Speed * Time.deltaTime;
//							card.transform.position = Vector3.MoveTowards (card.transform.position, player2CardInitialPosition, step);
						}

					}
					tappedCardsDictionary.Remove (touch.fingerId);
				}
			}
		}
	}




//	void FixedUpdate()
//	{
//		int tapCount = Input.touchCount;
//		for (int i = 0; i < tapCount; i++) {
//			Touch touch = Input.GetTouch (i);
//			if (touch.phase == TouchPhase.Began) {
//				Debug.Log ("Touch Began # " + i);
//				Vector3 worldPoint = Camera.main.ScreenToWorldPoint (touch.position);
//				for (int j = 0; i < cardMovementRef.playerCards.Length; j++) {
//					GameObject card = cardMovementRef.playerCards [j];
//					if (card.GetComponent<Collider2D> ().OverlapPoint (worldPoint)) {
//						Debug.Log ("Inside");
//
//						if (player1Card == null && j < cardMovementRef.playerCards.Length / 2) {
//							player1Card = card;
//							tappedCardsDictionary [touch.fingerId] = card;
//							//							tappedCardsDictionary.Add (i, card);
//							Debug.Log ("Player Card 1 Assigned");
//							Debug.Log ("Touch # " + i);
//							Debug.Log ("Card # " + j);
//							//							isPlayer1CardTapped = true;
//							break;
//						} else if (player2Card == null && j < cardMovementRef.playerCards.Length) {
//							player2Card = card;
//							tappedCardsDictionary [touch.fingerId] = card;
//							//							tappedCardsDictionary.Add (touch.fingerId, card);
//							Debug.Log ("Player Card 2 Assigned");
//							Debug.Log ("Touch # " + touch.fingerId);
//							Debug.Log ("Card # " + j);
//							//							isPlayer2CardTapped = true;
//							break;
//						}
//					} 
//
//				}
//
//			}
//
//		}
//
//		foreach(KeyValuePair<int, GameObject> cardPair in tappedCardsDictionary)
//		{
//			Touch touch = Input.GetTouch (cardPair.Key);
//			if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
//			{
//				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
//				GameObject card = cardPair.Value;
//				Rigidbody2D rb = card.GetComponent<Rigidbody2D> ();
//				rb.position = worldPoint;
//
//
//			}
//
//
//			if (touch.phase == TouchPhase.Ended)
//			{
//				Debug.Log ("Touch End # " + cardPair.Key);
//				GameObject card = cardPair.Value;
//				if (card.Equals (player1Card)) 
//				{
//					player1Card = null;
//					Debug.Log ("Player Card 1 Nullified");
//				}
//				else if(card.Equals (player2Card))
//				{
//					player2Card = null;
//					Debug.Log ("Player Card 2 Nullified");
//				}
//			}
//
//
//
//		}
//	}

}