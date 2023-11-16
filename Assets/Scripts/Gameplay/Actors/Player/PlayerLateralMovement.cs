using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public bool isGrounded = false;
	public bool doubleJump = false;
    
    Rigidbody2D rb;
    SpriteRenderer sprite;
	Animator animator;

	[Header("Eventos generales")]
	public UnityEvent onDie = new();

	void Awake(){

        //Referencia a componentes externos
        stats = GameObject.FindGameObjectWithTag("GameData").GetComponent<Data>().stats;

		playerInput = GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInput>();
		m_move = playerInput.actions["Move"];
		m_jump = playerInput.actions["Jump"];



		//Referencia a componentes propios
		rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
		animator = GetComponentInChildren<Animator>();

		//Me subscribo a los cambios de HP de los stats
		stats.HP.RestartStats();
		stats.HP.OnIndicatorChange.AddListener(OnHPUpdate);


	}

    // Update is called once per frame
    void Update(){

        inputX = m_move.ReadValue<Vector2>().x;
	}

    private void FixedUpdate(){

		LateralMove();
		Flip();
		Jump();

		//Actualizamos el animator
		UpdateAnimator();

	}

	private void UpdateAnimator()
	{
		animator.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
		animator.SetFloat("velocityY",Mathf.Abs(rb.velocity.y));
		animator.SetBool("isGrounded",isGrounded);
	}

	private void LateralMove()
	{
		float modified=0f;
		if (isGrounded) modified = 1;
		else modified = stats.airMomentum;


		rb.AddForce(Vector2.right* inputX * stats.aceleration * modified);

		//Detener la velocidad en la maxima declarada

		Vector3 vel = rb.velocity;

		if (vel.magnitude >= stats.maxSpeed * modified)
		{
			rb.velocity = vel.normalized * stats.maxSpeed * modified;
		}


		
		

	}
	//Flipear el sprite para el lado correspondiente
	private void Flip()
	{
		Vector2 aux = sprite.transform.localScale;

		if (rb.velocity.x > 0) aux.x = Mathf.Abs(aux.x);
		else if (rb.velocity.x < 0) aux.x = -Mathf.Abs(aux.x);

		sprite.transform.localScale = aux;
	}

    private void Jump()
    {
		if (m_jump.triggered && (isGrounded || doubleJump))
		{
			
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce(Vector2.up * stats.jumpSpeed, ForceMode2D.Impulse);

			if (!doubleJump)
			{
				doubleJump = true;
			}
			else if (doubleJump)
			{
				doubleJump = false;
			}

		}

		
	}

	private void OnHPUpdate(float value)
	{
		if (value <= 0)
		{
			onDie.Invoke();
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
		return stats;
	}

	public GameObject getGameObject()
	{
		return gameObject;
	}

	public void onHeal(float heal)
	{
		throw new System.NotImplementedException();
	}

	public void onDamage(float damage)
	{
		stats.HP.CurrentValue -= damage;
	}

}
