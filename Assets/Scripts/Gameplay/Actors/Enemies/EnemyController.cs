using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class EnemyController : MonoBehaviour, IActorController
{

	[SerializeField] EnemyStats stats;
	[SerializeField] public EnemyDataSO enemyData;

	[Header("Eventos generales")]
	public UnityEvent onDie = new();

	private void Awake()
	{
		//Me subscribo a los cambios de HP de los stats
		stats.HP.OnIndicatorChange.AddListener(OnHPUpdate);
	}

	private void OnRenderObject()
	{
		enemyData?.Initialize(this);
	}

	private void OnHPUpdate(float value)
	{
		if (value <= 0)
		{
			onDie.Invoke();
			Destroy(gameObject,0.5f);
		}
	}

	//Metodos de la interfaz
	public GameObject getGameObject()
	{
		return gameObject;
	}

	public Stats getStats()
	{
		return stats;
	}

	public void onDamage(float damage)
	{
		stats.HP.CurrentValue -= damage;
	}

	public void onHeal(float heal)
	{
		throw new System.NotImplementedException();
	}
}
