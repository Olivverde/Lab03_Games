using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @author: Olivverde (Oliver Josue de Leon Milian)
* Plataformas moviles y juegos
* Class's purpose:
* Oscillation class allows the oscillation of an object
*/


public class Oscillation : MonoBehaviour
{
    //3D vector
    private Vector3 initialPosition;
    private int velocity = 1;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Transform the position per frame, following the sin ecuation in a specific axis
        transform.localPosition = initialPosition + new Vector3(0, 0, Mathf.Sin(Time.time * velocity));
    }
}