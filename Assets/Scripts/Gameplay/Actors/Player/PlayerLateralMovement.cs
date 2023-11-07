using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLateralMovement : MonoBehaviour, IActorController
{
    //Referencia a los Stats
    playerStats stats;

	//Referencia al player input
	PlayerInput playerInput;

	InputAction m_move;
	InputAction m_jump;

	//Parametros privados
    public float inputX;
    public bool jump = false;
    public bool isGrounded = false;
	public int jumpLeft = 1;
    
    Rigidbody2D rb;
    SpriteRenderer sprite;
   
    void Awake(){

        //Referencia a componentes externos
        stats = GameObject.FindGameObjectWithTag("GameData").GetComponent<Data>().stats;

		playerInput = GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInput>();
		m_move = playerInput.actions["Move"];
		m_jump = playerInput.actions["Jump"];



		//Referencia a componentes propios
		rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update(){

        inputX = m_move.ReadValue<Vector2>().x;

        if (m_jump.triggered && jumpLeft>0){

            jump = true;
			
        }
	}

    private void FixedUpdate(){

		LateralMove();
		Jump();
	

	}

	private void LateralMove()
	{
		float modified=0f;
		if (isGrounded) modified = 1;
		else modified = stats.airMovementSpeed;


		rb.AddForce(Vector2.right* inputX * stats.aceleration * modified);
		
		//rb.velocity = new Vector2(inputX * speed * stats.aceleration, rb.velocity.y);

		Vector3 vel = rb.velocity;
		if (vel.magnitude > stats.maxSpeed)
		{
			rb.velocity = vel.normalized * stats.maxSpeed;
		}

		Vector2 aux = sprite.transform.localScale;

		if (rb.velocity.x > 0) aux.x = Mathf.Abs(aux.x);
		else if (rb.velocity.x < 0) aux.x = -Mathf.Abs(aux.x);

		sprite.transform.localScale = aux;

	}

    private void Jump()
    {
		if (jump && jumpLeft>0)
		{
			jumpLeft--;
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce(Vector2.up * stats.jumpSpeed, ForceMode2D.Impulse);
			jump = false;
			


		}

		if (isGrounded) 
		{
			jumpLeft = 1;
		}
	}


	private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.CompareTag("Floor")){

            isGrounded = true;

        }

		
	}

	private void OnCollisionExit2D(Collision2D collision){

		if (collision.gameObject.CompareTag("Floor")){

			isGrounded = false;

		}


	}

	public Stats getStats()
	{
		throw new System.NotImplementedException();
	}

	public GameObject getGameObject()
	{
		throw new System.NotImplementedException();
	}

	public void onHeal(float heal)
	{
		throw new System.NotImplementedException();
	}

	public void onDamagae(float damage)
	{
		throw new System.NotImplementedException();
	}


	/*public bool IsGrounded(){

        var hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);

        if (!hit) return false;
        if (hit.collider.gameObject.CompareTag("Floor")) return true;
        return false;


    }*/
}
