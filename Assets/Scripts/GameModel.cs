using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModel: Singleton <GameModel>
{
	private bool isPlayer1CardHeld;
	private bool isPlayer2CardHeld;
	public bool areGameVariableReady;

	private bool hasPlayer1SelectedPath1;
	private bool hasPlayer1SelectedPath2;
	private bool hasPlayer1SelectedPath3;
	private bool hasPlayer2SelectedPath1;
	private bool hasPlayer2SelectedPath2;
	private bool hasPlayer2SelectedPath3;

	private int player1Revenue;
	private int player2Revenue;
	private float speed;
	private List<Vector3> path1List;
	private List<Vector3> path2List;
	private List<Vector3> path3List;
	private List<Vector3> path1ListReversed;
	private List<Vector3> path2ListReversed;
	private List<Vector3> path3ListReversed;


	public bool IsPlayer1CardHeld
	{
		get{ return isPlayer1CardHeld;}
		set{ isPlayer1CardHeld = value;}
	}

	public bool IsPlayer2CardHeld
	{
		get{ return isPlayer2CardHeld;}
		set{ isPlayer2CardHeld = value;}
	}

	public bool AreGameVariableReady
	{
		get{ return areGameVariableReady;}
		set{ areGameVariableReady = value;}
	}

	public bool HasPlayer1SelectedPath1
	{
		get{ return hasPlayer1SelectedPath1;}
		set{ hasPlayer1SelectedPath1 = value;}
	}

	public bool HasPlayer1SelectedPath2
	{
		get{ return hasPlayer1SelectedPath2;}
		set{ hasPlayer1SelectedPath2 = value;}
	}

	public bool HasPlayer1SelectedPath3
	{
		get{ return hasPlayer1SelectedPath3;}
		set{ hasPlayer1SelectedPath3 = value;}
	}

	public bool HasPlayer2SelectedPath1
	{
		get{ return hasPlayer2SelectedPath1;}
		set{ hasPlayer2SelectedPath1 = value;}
	}

	public bool HasPlayer2SelectedPath2
	{
		get{ return hasPlayer2SelectedPath2;}
		set{ hasPlayer2SelectedPath2 = value;}
	}

	public bool HasPlayer2SelectedPath3
	{
		get{ return hasPlayer2SelectedPath3;}
		set{ hasPlayer2SelectedPath3 = value;}
	}

	public int Player1Revenue
	{
		get{ return player1Revenue;}
		set{ player1Revenue = value;}
	}

	public int Player2Revenue
	{
		get{ return player2Revenue;}
		set{ player2Revenue = value;}
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

	public List<Vector3> Path1ListReversed
	{
		get{ return path1ListReversed;}
	}

	public List<Vector3> Path2ListReversed
	{
		get{ return path2ListReversed;}
	}

	public List<Vector3> Path3ListReversed
	{
		get{ return path3ListReversed;}
	}

	public void SetUpGameVariables()
	{
		isPlayer1CardHeld = false;
		isPlayer2CardHeld = false;
		areGameVariableReady = false;

		hasPlayer1SelectedPath1 = false;
		hasPlayer1SelectedPath2 = false;
		hasPlayer1SelectedPath3 = false;
		hasPlayer2SelectedPath1 = false;
		hasPlayer2SelectedPath2 = false;
		hasPlayer2SelectedPath3 = false;

		player1Revenue = 0;
		player2Revenue = 0;
		speed = 2.0f;
		path1List = new List<Vector3> {
			new Vector3 (-0.59f, -3.03f, 0.0f),
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
			new Vector3 (0.55f, -2.96f, 0.0f),
			new Vector3 (1.78f, -1.49f, 0.0f),
			new Vector3 (1.48f, -1.28f, 0.0f),
			new Vector3 (1.95f, -0.91f, 0.0f),
			new Vector3 (1.95f, 1.79f, 0.0f),
			new Vector3 (1.5f, 2.11f, 0.0f),
			new Vector3 (1.71f, 2.43f, 0.0f),
			new Vector3 (0.53f, 3.71f, 0.0f)
		};

		path1ListReversed = new List<Vector3> ();
		path1ListReversed.AddRange (path1List);
		path1ListReversed.Reverse ();
		path2ListReversed = new List<Vector3> ();
		path2ListReversed.AddRange (path2List);
		path2ListReversed.Reverse ();
		path3ListReversed = new List<Vector3> ();
		path3ListReversed.AddRange (path3List);
		path3ListReversed.Reverse ();
	}
}
