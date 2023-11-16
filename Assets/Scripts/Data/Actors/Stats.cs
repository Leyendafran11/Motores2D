using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats 
{
	[Header("Basic")]
	public Indicator HP;


    [Header("Attack")]
    public float basicAttack;

    [Header("Movement")]
    [Range(0,1)]public float airMomentum;
	[Range(5,10)] public float aceleration;
    public float maxSpeed=10;

    [Header("Jump")]
    public float jumpSpeed;

    public void resetStats()
    {
        HP.RestartStats();
    }

}
