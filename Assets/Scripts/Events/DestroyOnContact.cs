using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Bullet") {
			Destroy (other.gameObject);
		}
	}
}
