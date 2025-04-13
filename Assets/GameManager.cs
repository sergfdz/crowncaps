using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia estática para acceder desde otros scripts

    public TextMeshProUGUI puntosJugador1Text; // Texto para jugador 1
    public TextMeshProUGUI puntosJugador2Text; // Texto para jugador 2

    public int puntosJugador1 = 0; // Puntos jugador 1
    public int puntosJugador2 = 0; // Puntos jugador 2

    public Transform posicionChapa1Jugador1;
    public Transform posicionChapa2Jugador1;
    public Transform posicionChapa3Jugador1;
    public Transform posicionChapa4Jugador1;
    public Transform posicionChapa1Jugador2;
    public Transform posicionChapa2Jugador2;
    public Transform posicionChapa3Jugador2;
    public Transform posicionChapa4Jugador2;
    public Transform posicionPelotaInicial;
    
    public GameObject chapa1Jugador1;
    public GameObject chapa2Jugador1;
    public GameObject chapa3Jugador1;
    public GameObject chapa4Jugador1;
    public GameObject chapa1Jugador2;
    public GameObject chapa2Jugador2;
    public GameObject chapa3Jugador2;
    public GameObject chapa4Jugador2;
    public GameObject pelota;

    private void Awake()
    {
        // Asegurarnos de que haya solo una instancia de GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }

    // Método para sumar un gol al Jugador 1
    public void GolJugador1()
    {
        puntosJugador1++;
        Debug.Log("¡Gol del Jugador 1!");
        puntosJugador1Text.text = $"{puntosJugador1}"; // Actualiza el UI
        ReiniciarPosiciones(); // Reinicia posiciones al marcar un gol
    }

    // Método para sumar un gol al Jugador 2
    public void GolJugador2()
    {
        puntosJugador2++;
        Debug.Log("¡Gol del Jugador 2!");
        puntosJugador2Text.text = $"{puntosJugador2}"; // Actualiza el UI
        ReiniciarPosiciones(); // Reinicia posiciones al marcar un gol
    }

    void ReiniciarPosiciones()
    {
        pelota.transform.position = posicionPelotaInicial.position;
        pelota.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        pelota.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        chapa1Jugador1.transform.position = posicionChapa1Jugador1.position;
        chapa1Jugador1.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        chapa1Jugador1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        chapa2Jugador1.transform.position = posicionChapa2Jugador1.position;
        chapa2Jugador1.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        chapa2Jugador1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        chapa3Jugador1.transform.position = posicionChapa3Jugador1.position;
        chapa3Jugador1.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        chapa3Jugador1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        chapa4Jugador1.transform.position = posicionChapa4Jugador1.position;
        chapa4Jugador1.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        chapa4Jugador1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        chapa1Jugador2.transform.position = posicionChapa1Jugador2.position;
        chapa1Jugador2.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        chapa1Jugador2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        chapa2Jugador2.transform.position = posicionChapa2Jugador2.position;
        chapa2Jugador2.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        chapa2Jugador2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        chapa3Jugador2.transform.position = posicionChapa3Jugador2.position;
        chapa3Jugador2.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        chapa3Jugador2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        chapa4Jugador2.transform.position = posicionChapa4Jugador2.position;
        chapa4Jugador2.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        chapa4Jugador2.GetComponent<Rigidbody2D>().angularVelocity = 0f;

    }
}
