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
    public GameObject action1;
    public GameObject action2;

  

    public void resetStats()
    {
        HP.RestartStats();
    }
	


}
