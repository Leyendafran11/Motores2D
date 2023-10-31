using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLateralMovement : MonoBehaviour{


    public float velocityX = 7;
    public float jumpForce = 10; 
    public float inputX;
    public bool jump = false;
    public bool isGrounded = false;
    
    Rigidbody2D rb;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update(){

        inputX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded){

            jump = true;
        }
       
    }

    private void FixedUpdate(){
       rb.velocity = new Vector2(inputX * velocityX, rb.velocity.y);

        Vector2 aux = sprite.transform.localScale;

		if (rb.velocity.x > 0) aux.x = Mathf.Abs(aux.x);
        else if(rb.velocity.x < 0) aux.x = -Mathf.Abs(aux.x);

        sprite.transform.localScale = aux;

		if (jump && isGrounded){
			rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;

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


    /*public bool IsGrounded(){

        var hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);

        if (!hit) return false;
        if (hit.collider.gameObject.CompareTag("Floor")) return true;
        return false;


    }*/
}
