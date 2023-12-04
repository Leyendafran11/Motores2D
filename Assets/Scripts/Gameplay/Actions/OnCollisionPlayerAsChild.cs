using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionPlayerAsChild : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		var player = collision.gameObject.GetComponent<IActorController>().getGameObject().transform;
		player.SetParent(transform);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		var player = collision.gameObject.GetComponentInParent<IActorController>().getGameObject().transform;
		player.SetParent(null);
	}
}

