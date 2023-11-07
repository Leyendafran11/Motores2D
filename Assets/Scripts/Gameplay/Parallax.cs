using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float longitud;
	private float posInicial;
    public GameObject cam;
    public float efectoParallax;



    
    void Start()
    {
        posInicial = transform.position.x;  

        longitud = GetComponent<SpriteRenderer>().bounds.size.x;
        

        
    }

    
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - efectoParallax));

        float distancia = (cam.transform.position.x * efectoParallax);

        transform.position = new Vector3(posInicial + distancia, transform.position.y, transform.position.z);

        if (temp > posInicial + longitud) posInicial += longitud;
        else if (temp < posInicial - longitud) posInicial -= longitud;

        
    }
}
