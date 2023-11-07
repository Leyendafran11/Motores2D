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
		data = GameObject.FindGameObjectWithTag("GameData").GetComponent<Data>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")){

			data.addPoints(points);
			pointCollectEvent.Invoke();
			Destroy(gameObject);
		}

	}
}
