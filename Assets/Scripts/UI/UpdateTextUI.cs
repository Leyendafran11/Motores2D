using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextUI : MonoBehaviour
{
    TextMeshProUGUI textUI;

	[SerializeField] Color enableColor = Color.black;
	[SerializeField] Color disableColor = Color.gray;

	private void Start()
	{
		textUI = GetComponent<TextMeshProUGUI>();
	}

	public void UpdateText(string texto)
	{
		textUI.SetText(texto);
	}

	public void UpdateText(string texto, bool enable)
	{
		UpdateText(texto);

		if (enable) textUI.color = enableColor;
		else textUI.color = disableColor;
	}


}
