using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerStats : Stats
{
	[Header("Movement")]
	[Range(0, 1)] public float airMomentum;
	[Range(5, 20)] public float aceleration;
	public float maxSpeed = 10;

	[Header("Jump")]
	public float jumpSpeed;

	[Header("Invulnerability")]
    public Color invulnerabilityColor = Color.red;
    [Range(0, 3)] public float invulneraniltySeconds = 1f;


	public void Update(playerStats newStats)
	{
		HP.Update(newStats.HP);
		aceleration = newStats.aceleration;
		maxSpeed = newStats.maxSpeed;
		airMomentum = newStats.airMomentum;	
		jumpSpeed = newStats.jumpSpeed;	
		invulnerabilityColor = newStats.invulnerabilityColor;
		invulneraniltySeconds = newStats.invulneraniltySeconds;
		basicAttack = newStats.basicAttack;
		action1 = newStats.action1;
		action2 = newStats.action2;	
	}
        
}
