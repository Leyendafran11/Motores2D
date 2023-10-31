using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSound : MonoBehaviour
{

    public AudioClip audioSFX;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        
    }

	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (audioSource == null) return;

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Sonido Moneda");
            //audioSource.PlayOneShot(audioSFX);
            AudioSource.PlayClipAtPoint(audioSFX, transform.position);
            Destroy(gameObject);
        }
	}
}
