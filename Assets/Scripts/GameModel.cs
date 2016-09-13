using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModel: Singleton <GameModel>
{
	private bool isCardReleased;
	private bool isPath1Selected;
	private bool isPath2Selected;
	private bool isPath3Selected;
	private float speed;
	private List<Vector3> path1List;
	private List<Vector3> path2List;
	private List<Vector3> path3List;


	public bool IsCardReleased
	{
		get{ return isCardReleased;}
		set{ isCardReleased = value;}
	}

	public bool IsPath1Selected
	{
		get{ return isPath1Selected;}
		set{ isPath1Selected = value;}
	}

	public bool IsPath2Selected
	{
		get{ return isPath2Selected;}
		set{ isPath2Selected = value;}
	}

	public bool IsPath3Selected
	{
		get{ return isPath3Selected;}
		set{ isPath3Selected = value;}
	}

	public float Speed
	{
		get{ return speed;}
	}

	public List<Vector3> Path1List
	{
		get{ return path1List;}
	}

	public List<Vector3> Path2List
	{
		get{ return path2List;}
	}

	public List<Vector3> Path3List
	{
		get{ return path3List;}
	}

	public void SetUpGameVariables()
	{
		isCardReleased = false;
		isPath1Selected = false;
		isPath2Selected = false;
		isPath3Selected = false;
		speed = 2.0f;
		path1List = new List<Vector3> {
			new Vector3 (-0.79f, -2.72f, 0.0f),
			new Vector3 (-2.07f, -1.38f, 0.0f),
			new Vector3 (-1.89f, -0.75f, 0.0f),
			new Vector3 (-1.87f, 1.9f, 0.0f),
			new Vector3 (-1.749f, 2.349f, 0.0f),
			new Vector3 (-0.55f, 3.69f, 0.0f),
		};

		path2List = new List<Vector3> {
			new Vector3 (0.03f, -2.72f, 0.0f),
			new Vector3 (-0.014f, -1.534f, 0.0f),
			new Vector3 (-0.516f, -1.221f, 0.0f),
			new Vector3 (-0.05f, -0.833f, 0.0f),
			new Vector3 (-0.042f, 1.834f, 0.0f),
			new Vector3 (-0.481f, 2.139f, 0.0f),
			new Vector3 (0.006f, 2.492f, 0.0f),
			new Vector3 (-0.02f, 3.33f, 0.0f)
		};

		path3List = new List<Vector3> {
			new Vector3 (0.9f, -2.72f, 0.0f),
			new Vector3 (1.78f, -1.49f, 0.0f),
			new Vector3 (1.48f, -1.28f, 0.0f),
			new Vector3 (1.95f, -0.91f, 0.0f),
			new Vector3 (1.95f, 1.79f, 0.0f),
			new Vector3 (1.5f, 2.11f, 0.0f),
			new Vector3 (1.71f, 2.43f, 0.0f),
			new Vector3 (0.53f, 3.71f, 0.0f)
		};
	}
}
