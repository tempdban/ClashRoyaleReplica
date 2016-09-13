using UnityEngine;
using System.Collections;

public class CardMover : MonoBehaviour 
{


	public float playerSpeed;
	public Boundary boundary;
	public GameObject character;

	private Rigidbody2D rb;
	private Collider2D c2D;
	private bool isPlayerTapped;
    private bool shouldAllowPlayerMovement;
    private bool playerOwnMovement;
    //	private GameObject player;
    private Vector3 worldPoint;
	private Vector3 endPoint;
    //	private float startTime;
    


    public void Start()
	{
//		player = gameObject;
		isPlayerTapped = false;
        playerOwnMovement = false;
        shouldAllowPlayerMovement = false;
        rb = GetComponent<Rigidbody2D> ();
		c2D = GetComponent<Collider2D> ();
        shouldAllowPlayerMovement = true;
        //		Input.multiTouchEnabled = true;
    }

	void FixedUpdate()
	{
        if (shouldAllowPlayerMovement)
        {
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
            {
                Debug.Log("Touch Began");
                Vector3 worldPoint = Vector3.zero;
#if UNITY_EDITOR
                worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif

                if (c2D.OverlapPoint(worldPoint))
                {
                    Debug.Log("Inside");
                    isPlayerTapped = true;
                }
                else
                {
                    Debug.Log("Outside");
                    isPlayerTapped = false;
                }
            }

            if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)))
            {
//				Debug.Log ("Touch Moved");

#if UNITY_EDITOR
                worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif

//                gameObject.GetComponent<Rigidbody2D>().MovePosition(worldPoint);
				rb.position = worldPoint;
//				Debug.Log (worldPoint);
				rb.position = new Vector2 (
					Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
					Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax));
            }

            if (isPlayerTapped && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0))))
            {
                Debug.Log("Touch Ended");
                shouldAllowPlayerMovement = false;
                isPlayerTapped = false;
                playerOwnMovement = true;

				GameModel.Instance.SetUpGameVariables ();
				GameModel.Instance.IsCardReleased = true;

				if (character != null)
				{
					Instantiate(character, transform.position, transform.rotation);
				}

				Destroy (gameObject);

            }
        }
//        if(playerOwnMovement)
//        {
//            GetComponent<Rigidbody2D>().velocity = transform.up * playerSpeed;
//        }
    }
}
