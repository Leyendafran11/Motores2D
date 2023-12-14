using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionController : MonoBehaviour
{
    //Referencia al playerController
    PlayerController playerController;
    playerStats stats;

    //Referencia al input
    InputAction m_action1, m_action2;

	private void Start()
	{
		//Referencia al playerController
		playerController = GetComponent<PlayerController>();
        stats = (playerStats) playerController.getStats();

		//Referencia de PlayerActionController
		m_action1 = playerController.playerInput.actions["Action1"];
		m_action2 = playerController.playerInput.actions["Action2"];
	}

	private void Update()
	{
		//Accion1
		if (m_action1.triggered)
		{
			Debug.Log("Action1");
			if (stats.action1)
			{
				Instantiate(stats.action1,transform);
			}
		}

		//Accion2
		if (m_action2.triggered)
		{
			Debug.Log("Action2");
			if (stats.action2)
			{
				Instantiate(stats.action2,transform.position,Quaternion.identity);
			}
		}
	}
}
