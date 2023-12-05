using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class PlayerController : MonoBehaviour, IActorController
{

	[Header("Player Info")]
	[SerializeField] public PlayerDataSO playerData;

	//Referencia a los Stats
	[SerializeField]playerStats stats;
	private SpriteRenderer ren;

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

		playerData?.Initialize(this);

		ren = GetComponentInChildren<SpriteRenderer>();

		//Obtengo el Player Input
		playerInput = GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInput>();

		//Me subscribo a los cambios de HP de los stats
		stats.HP.RestartStats();
		stats.HP.OnIndicatorChange.AddListener(OnHPUpdate);
	}

	private void OnRenderObject()
	{
		playerData?.Initialize(this);	
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

		if (stats.HP.CurrentValue > 0) StartCoroutine(TemporalVulnerability());
	}

	public IEnumerator TemporalVulnerability()
	{

		//Activar la invulnerabilidad utilizando capas
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);

		//Cambios al sprite para que el usuario sepa q es invulnerable 
		Color colorBase = ren.color;

		ren.color = stats.invulnerabilityColor;

		//Esperar el tiempo de la invulnerabilidad
		yield return new WaitForSecondsRealtime(stats.invulneraniltySeconds);

		//Deshacer cambios del sprite
		ren.color = colorBase;

		//Desactivar invulnerabilidad
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
		yield return null;


	}

	
}
