using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardMover : MonoBehaviour 
{


	public float playerSpeed;
	public Boundary boundary;
	public GameObject character;

	private Rigidbody2D rb;
	private Collider2D c2D;
	private bool isPlayerTapped;
	private List<bool> areCardsTapped;
    private bool shouldAllowPlayerMovement;
    private bool playerOwnMovement;
	private int player1FingerID;
	private int player2FingerID;
    //	private GameObject player;
    private Vector3 worldPoint;
	private Vector3 endPoint;
    //	private float startTime;
    


    public void Start()
	{
//		player = gameObject;
		isPlayerTapped = false;
		areCardsTapped = new List<bool> (){ false, false };
        playerOwnMovement = false;
        shouldAllowPlayerMovement = false;
        rb = GetComponent<Rigidbody2D> ();
		c2D = GetComponent<Collider2D> ();
        shouldAllowPlayerMovement = true;
        //		Input.multiTouchEnabled = true;
    }

//	void FixedUpdate()
//	{
//		int tapCount = Input.touchCount;
//		for (int i = 0; i < tapCount; i++)
//		{
//			Touch touch = Input.GetTouch(i);
//			if (touch.phase == TouchPhase.Began) 
//			{
//				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
//				if (c2D.OverlapPoint(worldPoint))
//				{
//					Debug.Log("Inside");
//					isPlayerTapped = true;
//				}
//				else
//				{
//					Debug.Log("Outside");
//					isPlayerTapped = false;
//				}
//
//			}
//
//		}
//
//		if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
//            {
//                Debug.Log("Touch Began");
//                Vector3 worldPoint = Vector3.zero;
//#if UNITY_EDITOR
//                worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//                //for touch device
//#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
//			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//#endif
//
//                if (c2D.OverlapPoint(worldPoint))
//                {
//                    Debug.Log("Inside");
//                    isPlayerTapped = true;
//                }
//                else
//                {
//                    Debug.Log("Outside");
//                    isPlayerTapped = false;
//                }
//            }
//
//            if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)))
//            {
////				Debug.Log ("Touch Moved");
//
//#if UNITY_EDITOR
//                worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//                //for touch device
//#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
//			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//#endif
//
////                gameObject.GetComponent<Rigidbody2D>().MovePosition(worldPoint);
//				rb.position = worldPoint;
////				Debug.Log (worldPoint);
//				rb.position = new Vector2 (
//					Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
//					Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax));
//            }
//
//            if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0))))
//            {
//                Debug.Log("Touch Ended");
//                shouldAllowPlayerMovement = false;
//                isPlayerTapped = false;
//                playerOwnMovement = true;
//
//				GameModel.Instance.SetUpGameVariables ();
//				GameModel.Instance.IsCardReleased = true;
//
//				if (character != null)
//				{
//					Instantiate(character, transform.position, transform.rotation);
//				}
//
//				Destroy (gameObject);
//
//            }
//        }
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//		int tapCount = Input.touchCount;
//		Touch touch = null;
//		Touch touch2 = null;
//
//		if (tapCount == 1)
//		{
//			touch = Input.GetTouch (0); 
//			player1FingerID = touch.fingerId;
//		}
//		else if (Input.touchCount == 2) 
//		{
//			touch = Input.GetTouch (0); 
//			player1FingerID = touch.fingerId;
//
//			touch2 = Input.GetTouch (1);
//			player2FingerID = touch.fingerId;
//		}
//
//		if (Input.GetTouch(i).position.x < Screen.width / 4) 
//		{
//			
//		}
//
//		for ( var i = 0 ; i < tapCount ; i++ ) 
//		{
//			Touch touch = Input.GetTouch(i);
//			player1FingerID = touch.fingerId;
//			if (touch.position.x < Screen.width / 4) 
//			{
//				player1FingerID = touch.fingerId;
//				Debug.Log("Player 1 FingerID" + player1FingerID);
//			}
//			else if(touch.position.x > 3 * Screen.width / 4)
//			{
//				player2FingerID = touch.fingerId;
//				Debug.Log("Player 2 FingerID" + player2FingerID);
//			}
//
////			if (touch.phase == TouchPhase.Began) 
////			{
////				if (touch.fingerId.Equals (player1FingerID)) 
////				{
////					Debug.Log("Player 1 Touch Began");
////				}
////				else if (touch.fingerId.Equals (player2FingerID)) 
////				{
////					Debug.Log("Player 2 Touch Began");
////				}
////			}
////
////			if (touch.phase == TouchPhase.Moved) 
////			{
////				if (touch.fingerId.Equals (player1FingerID)) 
////				{
////					Debug.Log("Player 1 Touch Moved");
////				}
////				else if (touch.fingerId.Equals (player2FingerID)) 
////				{
////					Debug.Log("Player 2 Touch Moved");
////				}
////			}
////
////			if (touch.phase == TouchPhase.Ended) 
////			{
////				if (touch.fingerId.Equals (player1FingerID)) 
////				{
////					Debug.Log("Player 1 Touch End");
////				}
////				else if (touch.fingerId.Equals (player2FingerID)) 
////				{
////					Debug.Log("Player 2 Touch End");
////				}
////			}
//
//		}
//
//
////        if (shouldAllowPlayerMovement)
////        {
////            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
////            {
////                Debug.Log("Touch Began");
////                Vector3 worldPoint = Vector3.zero;
////#if UNITY_EDITOR
////                worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
////                //for touch device
////#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
////			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
////#endif
////
////                if (c2D.OverlapPoint(worldPoint))
////                {
////                    Debug.Log("Inside");
////                    isPlayerTapped = true;
////                }
////                else
////                {
////                    Debug.Log("Outside");
////                    isPlayerTapped = false;
////                }
////            }
////
////            if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)))
////            {
//////				Debug.Log ("Touch Moved");
////
////#if UNITY_EDITOR
////                worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
////                //for touch device
////#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
////			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
////#endif
////
//////                gameObject.GetComponent<Rigidbody2D>().MovePosition(worldPoint);
////				rb.position = worldPoint;
//////				Debug.Log (worldPoint);
////				rb.position = new Vector2 (
////					Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
////					Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax));
////            }
////
////            if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0))))
////            {
////                Debug.Log("Touch Ended");
////                shouldAllowPlayerMovement = false;
////                isPlayerTapped = false;
////                playerOwnMovement = true;
////
////				GameModel.Instance.SetUpGameVariables ();
////				GameModel.Instance.IsCardReleased = true;
////
////				if (character != null)
////				{
////					Instantiate(character, transform.position, transform.rotation);
////				}
////
////				Destroy (gameObject);
////
////            }
////        }
//////        if(playerOwnMovement)
//////        {
//////            GetComponent<Rigidbody2D>().velocity = transform.up * playerSpeed;
//////        }
//    }
}
