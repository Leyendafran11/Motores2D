using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFilledImageUI : MonoBehaviour
{

    Image img;
	// Start is called before the first frame update
	private void Awake()
	{
		img = GetComponent<Image>();	
	}

	public void UpdateFilledImage(float value)
    {
        img.fillAmount = value; 
    }

    
}
