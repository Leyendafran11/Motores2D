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

  

    public void resetStats()
    {
        HP.RestartStats();
    }

}
