using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(EnemyController))]
public class EnemyPatrol : MonoBehaviour
{
    //Referencia el enemy controller
    EnemyStats stats;
    SpriteRenderer sprite;
    Rigidbody2D rb;

	

    //Patrulla
    [SerializeField]int currentDestination = 0;
    [SerializeField] List<Vector3> patrolDestination;
	[SerializeField] bool inverseFlip = false;

	Coroutine coroutine;

	private void Start()
	{
		//obtenemos los stats
        stats = (EnemyStats) GetComponent<EnemyController>().getStats();
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        //obtengo la lista de puntos
        patrolDestination = new List<Vector3>();

        //añadimos la pos inicial
        patrolDestination.Add(transform.position);

        //rellenarlo con nla ruta
        Transform patrolGO = gameObject.transform.Find("Patrol");
        for (int i = 0; i < patrolGO.childCount; i++) {
            patrolDestination.Add(patrolGO.GetChild(i).position);
        }

        //Inicializo la pos inicial
        currentDestination = 0;

		coroutine=StartCoroutine(Patrol());
	}
	private void Update()
	{
        
	}

	private IEnumerator Patrol()
    {
        //Compruebo si he llegado
        while (true)
        {
			if (Vector3.Distance(transform.position, patrolDestination[currentDestination]) < 0.3f)
			{
				currentDestination = (currentDestination + 1) % patrolDestination.Count;
				yield return new WaitForSecondsRealtime(1f);
			}

			//Me muevo al sig destino
			Vector3 dir = (patrolDestination[currentDestination] - transform.position).normalized;
			rb.velocity = dir * stats.maxSpeed;

			Flip();

			yield return new WaitForEndOfFrame();

		}
	}

	private void Flip()
	{
		Vector2 aux = sprite.transform.localScale;

		if (rb.velocity.x > 0) aux.x = Mathf.Abs(aux.x);
		else if (rb.velocity.x < 0) aux.x = -Mathf.Abs(aux.x);

        if(inverseFlip) aux.x = -aux.x;

		sprite.transform.localScale = aux;
	}
}
