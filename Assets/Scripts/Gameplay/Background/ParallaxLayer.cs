using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
	// Start is called before the first frame update
	public Vector3 parallaxFactor = Vector3.one;


	public void Move(Vector3 delta)
	{
		Vector3 newPos = transform.localPosition;
		newPos.x -= delta.x * parallaxFactor.x;
		newPos.y -= delta.y * parallaxFactor.y;

		transform.localPosition = newPos;
	}
}
