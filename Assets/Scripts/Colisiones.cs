using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisiones : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 15;
    private bool canJump = false;
    public static byte monedasRecolectadas;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Saltar();
        }
    }

    private void FixedUpdate()
    {
        if (rb && Time.timeScale != 0)
            rb.AddForce(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
    }

    private void Saltar()
    {

         if(rb && canJump && Time.timeScale != 0)
            rb.AddForce(0, 5, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collider)
    {
        //Destroy(collision.gameObject); //Destruye lo que sea con lo que se choque
        //Destroy(this); //El Script es this, o sea, se destruye el script
        //Destroy(gameObject); //Destruye la pelota (o el objeto al que esto esté adjunto)

        if (collider.gameObject.CompareTag("Suelo"))
        {
            canJump = true;
        }
        else if (collider.gameObject.CompareTag("Hazard") && monedasRecolectadas < 3)
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            monedasRecolectadas++;
        }
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Suelo"))
            canJump = false;
    }

    public byte coinsGotten()
    {
        return monedasRecolectadas;
    }

    public void resetCoins()
    {
        monedasRecolectadas = 0;
    }
}
