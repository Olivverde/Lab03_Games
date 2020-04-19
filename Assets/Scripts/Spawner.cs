using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject plantillaJugador;
    private GameObject jugador;
    private Colisiones jugadorScript;
    public Material invulnerableMaterial;
    
    private bool hadAllCoins;
    private byte coins;
    public Text label;

    private AudioSource reproductor;
    public AudioClip spawning;
    public AudioClip gettingAllCoins;


    void Start()
    {
        reproductor = GetComponent<AudioSource>();
        hadAllCoins = false;
        coins = 0;
        Time.timeScale = 1;
        updateLabel();
        spawnPlayer();
        jugadorScript.resetCoins();

        if (reproductor && spawning)
        {
            reproductor.clip = spawning;
            reproductor.Play();
        }
        
    }

    public void spawnPlayer()
    {
        if (!jugador && plantillaJugador && Time.timeScale != 0)
        {
            jugador = Instantiate(plantillaJugador, new Vector3(0, 3, 0), Quaternion.identity);
            jugadorScript = jugador.GetComponent<Colisiones>();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            spawnPlayer();
    }

    private void FixedUpdate()
    {
        if (jugador && coins != jugadorScript.coinsGotten())
        {
            coins = jugadorScript.coinsGotten();
            updateLabel();
        }
        if (jugador && !hadAllCoins && jugadorScript.coinsGotten() == 3)
        {
            if (reproductor && gettingAllCoins)
            {
                reproductor.clip = gettingAllCoins;
                reproductor.Play();
                if(invulnerableMaterial)
                    jugador.GetComponent<Renderer>().material = invulnerableMaterial;
            }
            hadAllCoins = true;
        }
    }

    public void changeVolume(float newVolumen)
    {
        reproductor.volume = newVolumen;
    }
    public void updateLabel()
    {
        if(label)
            label.text = "Coins: " + coins;
    }
}
