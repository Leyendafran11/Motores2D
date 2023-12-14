using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class addPoints : MonoBehaviour
{	
	//Datos propios
    [SerializeField][Range(1, 10)] private int points=1;

	public UnityEvent pointCollectEvent;

    Data data;

	private void Awake()
	{
		if (GameObject.FindGameObjectWithTag("GameData"))
		{
			data = GameObject.FindGameObjectWithTag("GameData").GetComponent<Data>();
		}
		else
		{
			Debug.Log("Error: GameData Object/tag not found");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")){

			data?.addPoints(points);
			pointCollectEvent.Invoke();
			Destroy(gameObject,0.1f);
		}

	}
}
