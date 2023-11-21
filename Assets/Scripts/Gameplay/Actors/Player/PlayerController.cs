using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IActorController
{

	//Referencia a los Stats
	[SerializeField]playerStats stats;

	//Referencia al player input
	[HideInInspector]public PlayerInput playerInput;

	[Header("Eventos generales")]
	public UnityEvent onDie = new();

	private void Awake()
	{

		//Sinconizar los stats con GameData
		if (GameObject.FindGameObjectWithTag("GameData"))
		{
			//Referencia a componentes externos
			stats = GameObject.FindGameObjectWithTag("GameData").GetComponent<Data>().stats;
		}
		else
		{
			Debug.Log("Error: GameData Object/tag not found");
		}
		

		//Obtengo el Player Input
		playerInput = GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInput>();

		//Me subscribo a los cambios de HP de los stats
		stats.HP.RestartStats();
		stats.HP.OnIndicatorChange.AddListener(OnHPUpdate);
	}

	private void OnHPUpdate(float value)
	{
		if (value <= 0)
		{
			onDie.Invoke();
		}
	}
	public Stats getStats()
	{
		return stats;
	}

	public GameObject getGameObject()
	{
		return gameObject;
	}

	public void onHeal(float heal)
	{
		throw new System.NotImplementedException();
	}

	public void onDamage(float damage)
	{
		stats.HP.CurrentValue -= damage;
	}
}
