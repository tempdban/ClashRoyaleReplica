using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardMovementController : Singleton<CardMovementController> 
{
	CardMovementReferences cardMovementRef;
	private bool shouldAllowCardDragging;
	private bool isPlayer1CardTapped;
	private bool isPlayer2CardTapped;
	private Dictionary<int, GameObject> tappedCardsDictionary;
	private GameObject player1Card;
	private GameObject player2Card;

	public void Init(GameObject gameObject)
	{
		cardMovementRef = gameObject.GetComponent<CardMovementReferences> ();
		shouldAllowCardDragging = true;
		tappedCardsDictionary = new Dictionary<int, GameObject> ();
	}

	void FixedUpdate()
	{
		int tapCount = Input.touchCount;
		for (int i = 0; i < tapCount; i++) 
		{
			Touch touch = Input.GetTouch (i);
			if (touch.phase == TouchPhase.Began) 
			{
				Debug.Log ("Touch Began # " + i);
				Vector3 worldPoint = Camera.main.ScreenToWorldPoint (touch.position);
				for(int j = 0; j < cardMovementRef.playerCards.Length; j++) 
				{
					GameObject card = cardMovementRef.playerCards[j];
					if (card.GetComponent<Collider2D> ().OverlapPoint (worldPoint)) 
					{
						Debug.Log ("Inside");

						if (player1Card == null && j < cardMovementRef.playerCards.Length / 2)
						{
							player1Card = card;
							tappedCardsDictionary.Add (touch.fingerId, card);
							Debug.Log ("Player Card 1 Assigned");
							Debug.Log ("Touch # " + touch.fingerId);
							Debug.Log ("Card # " + j);
//							isPlayer1CardTapped = true;
							break;
						}
						else if (player2Card == null && j < cardMovementRef.playerCards.Length)
						{
							player2Card = card;
							tappedCardsDictionary.Add (touch.fingerId, card);
							Debug.Log ("Player Card 2 Assigned");
							Debug.Log ("Touch # " + touch.fingerId);
							Debug.Log ("Card # " + j);
//							isPlayer2CardTapped = true;
							break;
						}
					} 

				}

			}

			if (tappedCardsDictionary.ContainsKey(touch.fingerId) && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
			{
				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
				GameObject card = null;
				if (tappedCardsDictionary.TryGetValue (touch.fingerId, out card)) 
				{
					Rigidbody2D rb = card.GetComponent<Rigidbody2D> ();
					rb.position = worldPoint;
//					Debug.Log (worldPoint);
				}


			}

			if (tappedCardsDictionary.ContainsKey(touch.fingerId) && touch.phase == TouchPhase.Ended)
			{
				Debug.Log ("Touch End # " + touch.fingerId);
				GameObject card = null;
				if (tappedCardsDictionary.TryGetValue (touch.fingerId, out card)) 
				{
					if (card.Equals (player1Card)) 
					{
						player1Card = null;
						Debug.Log ("Player Card 1 Nullified");
					}
					else if(card.Equals (player2Card))
					{
						player2Card = null;
						Debug.Log ("Player Card 2 Nullified");
					}
				}
				tappedCardsDictionary.Remove (touch.fingerId);
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
