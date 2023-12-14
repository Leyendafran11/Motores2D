using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats : Stats
{
    [Header("Enemy Info")]
    public Type enemyType;

	public float maxSpeed = 10;

	public void Update(EnemyStats newStats)
	{
		HP.Update(newStats.HP);
		maxSpeed = newStats.maxSpeed;
		basicAttack = newStats.basicAttack;
	}


}
