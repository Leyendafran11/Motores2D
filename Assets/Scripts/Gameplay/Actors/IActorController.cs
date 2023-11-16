using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActorController
{
	//Stats
	public Stats getStats();

	//Referencia
	public GameObject getGameObject();

	//Metodos gestion HP
	public void onHeal(float heal);

	public void onDamage(float damage);
}
