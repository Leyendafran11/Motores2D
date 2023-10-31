using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;

    Rigidbody2D rbody;

	private void Awake()
	{
		rbody = GetComponent<Rigidbody2D>();	
	}

	private void FixedUpdate()
	{
		Vector2 currentPos = rbody.position;
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector2 inputVector = UpRightToIsometric(horizontalInput, verticalInput);
		inputVector = Vector2.ClampMagnitude(inputVector, 1);
		Vector2 movement = inputVector * movementSpeed;
		Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
		rbody.MovePosition(newPos);	
	}

	private Vector2 UpRightToIsometric(float horizontal, float vertical)
	{
		return new Vector2(vertical + horizontal, (vertical - horizontal) / 2).normalized;
	}
}
