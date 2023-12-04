using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerStats : Stats
{
	[Header("Movement")]
	[Range(0, 1)] public float airMomentum;
	[Range(5, 10)] public float aceleration;
	public float maxSpeed = 10;

	[Header("Jump")]
	public float jumpSpeed;

	[Header("Invulnerability")]
    public Color invulnerabilityColor = Color.red;
    [Range(0, 3)] public float invulneraniltySeconds = 1f;
        
}
