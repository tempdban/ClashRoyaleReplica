using UnityEngine;
using System.Collections;

public class CardMover : MonoBehaviour {

	private Rigidbody2D rb;
	private Collider2D c2D;
	private bool isPlayerTapped;
//	private bool shouldAllowPlayerMovement;
//	private GameObject player;
	private Vector3 worldPoint;
	private Vector3 endPoint;
//	private float startTime;


	public void Start()
	{
//		player = gameObject;
		isPlayerTapped = false;
//		shouldAllowPlayerMovement = false;
		rb = GetComponent<Rigidbody2D> ();
		c2D = GetComponent<Collider2D> ();
//		shouldAllowPlayerMovement = true;
//		Input.multiTouchEnabled = true;
	}

	void FixedUpdate()
	{
		if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown (0))) {
			Debug.Log ("Touch Began");
			Vector3 worldPoint = Vector3.zero;
			#if UNITY_EDITOR
			worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//for touch device
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			#endif

			if (c2D.OverlapPoint (worldPoint)) {
				Debug.Log ("Inside");
				isPlayerTapped = true;
//					startTime = Time.time;
			} 
			else 
			{
				Debug.Log ("Outside");
				isPlayerTapped = false;
			}
		}

		if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || (Input.GetAxisRaw ("Mouse X") != 0 || Input.GetAxisRaw ("Mouse Y") != 0))) {
//				Debug.Log ("Touch Moved");

			#if UNITY_EDITOR
			worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//for touch device
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			#endif

			gameObject.GetComponent<Rigidbody2D>().MovePosition(worldPoint);
			Debug.Log (worldPoint);
		}

		if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp (0))))
		{
			Debug.Log ("Touch Ended");
			isPlayerTapped = false;

		}



//		if ((Input.touchCount > 0 && Input.GetTouch (1).phase == TouchPhase.Began) || (Input.GetMouseButtonDown (1))) {
//			Debug.Log ("Touch Began 1");
//			Vector3 worldPoint = Vector3.zero;
//			#if UNITY_EDITOR
//			worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			//for touch device
//			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
//			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
//			#endif
//
//			if (c2D.OverlapPoint (worldPoint)) {
//				Debug.Log ("Inside");
//				isPlayerTapped = true;
//				//					startTime = Time.time;
//			} 
//			else 
//			{
//				Debug.Log ("Outside");
//				isPlayerTapped = false;
//			}
//		}
//
//		if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch (1).phase == TouchPhase.Moved) || (Input.GetAxisRaw ("Mouse X") != 0 || Input.GetAxisRaw ("Mouse Y") != 0))) {
//			//				Debug.Log ("Touch Moved");
//
//			#if UNITY_EDITOR
//			worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			//for touch device
//			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
//			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
//			#endif
//
//			gameObject.GetComponent<Rigidbody2D>().MovePosition(worldPoint);
//			Debug.Log (worldPoint);
//		}
//
//		if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch (1).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp (0))))
//		{
//			Debug.Log ("Touch Ended 1");
//			isPlayerTapped = false;
//
//		}
	}
}
