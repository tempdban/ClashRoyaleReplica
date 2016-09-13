using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMover : MonoBehaviour 
{
	private Animator anim;
	private int currentPosition;
	private Vector3 targetPosition;
	private List<Vector3> pathList;


	void Start()
	{
		anim = GetComponent<Animator> ();
		currentPosition = 0;
		targetPosition = Vector3.zero;


	}

	void Update()
	{
		if (pathList == null) 
		{
			if (GameModel.Instance.IsPath1Selected)
				pathList = GameModel.Instance.Path1List;
			else if (GameModel.Instance.IsPath2Selected)
				pathList = GameModel.Instance.Path2List;
			else if (GameModel.Instance.IsPath3Selected)
				pathList = GameModel.Instance.Path3List;
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
		}
	}
}
