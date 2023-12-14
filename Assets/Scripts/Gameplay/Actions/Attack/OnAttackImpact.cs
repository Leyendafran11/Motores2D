using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackImpact : MonoBehaviour
{

	[SerializeField] float damage = 1;
	[SerializeField] string originTag = "";

	public void Initialized(string newTag)
	{
		originTag = newTag;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(originTag)) return;
		if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
		{
			collision.gameObject.GetComponentInParent<IActorController>().onDamage(damage);
			Destroy(gameObject);
		}
	}

	
}
