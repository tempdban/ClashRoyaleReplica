using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMover : MonoBehaviour 
{

	public int playerType;
	public float speed;
	public float totalHealth;
	public SpriteRenderer healthBar;
	public SpriteRenderer healthBarBorder;
	public GameObject bullet;
//	private Animator anim;
	private bool shouldSpawnBullets;
	private int currentPosition;
	private float currentHealth;
	private Vector3 targetPosition;
	private List<Vector3> pathList;

	void Start()
	{
//		anim = GetComponent<Animator> ();
		currentPosition = 0;
		targetPosition = Vector3.zero;

		//setting up character data
		currentHealth = totalHealth;
		UpdateHealthBar ();
		Debug.Log ("Total Health: " + totalHealth);
		Debug.Log ("Current Health: " + totalHealth);
		healthBar.color = Constants.PLAYER_HEALTH_BAR_COLORS[playerType - 1];
		healthBarBorder.color = Constants.PLAYER_HEALTH_BAR_BORDER_COLORS[playerType - 1];
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
//			GetComponent<Collider2D> ().enabled = false;
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

	IEnumerator SpawnBullets ()
	{
		while (shouldSpawnBullets)
		{
			Instantiate (bullet, transform.position, transform.rotation);
			yield return new WaitForSeconds (0.2f);
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Character" && (playerType != other.GetComponent<CharacterMover>().playerType)) 
		{
			Debug.Log ("CollisionEnter2D");
			shouldSpawnBullets = true;
			StartCoroutine (SpawnBullets ());
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Character" && (playerType != other.GetComponent<CharacterMover>().playerType)) 
		{
			Debug.Log ("CollisionExit2D");
			shouldSpawnBullets = false;
			StopCoroutine (SpawnBullets ());
		}
	}

	private void UpdateHealthBar()
	{
		healthBar.transform.localScale = new Vector3 ((currentHealth / totalHealth), 1.0f, 1.0f);
	}
}
