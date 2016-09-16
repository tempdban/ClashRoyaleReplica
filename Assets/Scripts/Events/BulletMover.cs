using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour 
{
	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	}
}
