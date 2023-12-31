using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IActorController))]
public class OnActorTouchDamager : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
		{
			float damage = GetComponent<IActorController>().getStats().basicAttack;

			collision.gameObject.GetComponent<IActorController>().onDamage(damage);
		}
	}
}
