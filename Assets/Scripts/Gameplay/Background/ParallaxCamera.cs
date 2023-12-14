using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxCamera : MonoBehaviour
{
	public delegate void ParallaxCameraDelegate(Vector3 deltaMovement);
	public ParallaxCameraDelegate onCameraTranslate;

	private Vector3 oldPosition;


	void Start()
	{
		oldPosition = transform.position;
	}

	void FixedUpdate()
	{
		if (transform.position.x != oldPosition.x || transform.position.y != oldPosition.y)
		{
			if (onCameraTranslate != null)
			{
				Vector3 delta = oldPosition - transform.position;
				onCameraTranslate(delta);
			}

			oldPosition = transform.position;
		}
	}
}
