using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
	//Puntos
	[Header("Sistema de puntos")]
    [SerializeField]private int points;

	[Header("Sistema de Stats")]
	[SerializeField]public playerStats stats;


	private void Awake()
	{
		int numInstance = FindObjectsOfType<Data>().Length;

		if (numInstance != 1)
		{
			Destroy(this.gameObject);
		}
		else
		{
			DontDestroyOnLoad(this.gameObject);
		}
	}




	//Metodos de modificacion
	//public int Points { get => points; set => points = value; }
	public void addPoints(int value)
	{
		if (value <= 0) return;
		points += value;
	}

	public int getPoints()
	{
		return points;
	}


}
