using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePlatform : MonoBehaviour
{
    [Header("Plataforma Movement Parameters")]
    [SerializeField] float speed;

    int nextPosition;
    [SerializeField] List<Vector3> positions;

    public UnityEvent OnActionEnded;

	private void Start()
	{
		//rellenarlo con nla ruta
		Transform patrolGO = gameObject.transform.Find("Patrol");
		for (int i = 0; i < patrolGO.childCount; i++)
		{
			positions.Add(patrolGO.GetChild(i).position);
		}

		positions.Add(transform.position);

		//Siguiente Posicion
		nextPosition = 0;
	}

	public void Move()
	{
		Debug.Log("Moviendo...");
		StartCoroutine(MoveToNextPosition());
	}

	private IEnumerator MoveToNextPosition()
	{
		while (transform.position != positions[nextPosition])
		{
			transform.position = Vector3.MoveTowards(transform.position, positions[nextPosition], speed*Time.fixedDeltaTime);
			yield return new WaitForFixedUpdate();
		}

		nextPosition = (nextPosition+1)%positions.Count;
		OnActionEnded.Invoke();
	}
}
