using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats 
{
	[Header("Basic")]
	public Indicator HP;

    [Header("Movimiento")]
    public float movementSpeed;
    [Range(0,1)]public float airMovementSpeed;
	[Range(5,10)] public float aceleration;
    public float maxSpeed=10;

    [Header("Salto")]
    public float jumpSpeed;

    public void resetStats()
    {
        HP.RestartStats();
    }

}
