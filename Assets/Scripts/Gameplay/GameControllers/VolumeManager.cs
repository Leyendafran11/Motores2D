using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeManager : MonoBehaviour
{
	Volume volume;
	Vignette vignetteFilter;

	private void Start()
	{
		volume = GetComponent<Volume>();
		volume.profile.TryGet(out vignetteFilter);
	}

	public void enableVignette(float second)
	{
		vignetteFilter.active = true;
		StartCoroutine(activateVignetteFilter(vignetteFilter.intensity,0f,1f, second));
	}

	public void disableVignette()
	{
		vignetteFilter.active = false;
		vignetteFilter.intensity.Override(0f);
	}

	public IEnumerator activateVignetteFilter(ClampedFloatParameter volumeFloat,float initValue,float endValue,float seconds)
	{
		volumeFloat.Override(initValue);

		float elapsedTime = 0f;
		
		while (elapsedTime < seconds)
		{
			float t = elapsedTime / seconds;

			vignetteFilter.intensity.Override(Mathf.Lerp(initValue, endValue, t));

			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();	
		}

		vignetteFilter.intensity.Override(endValue);
	}
}
