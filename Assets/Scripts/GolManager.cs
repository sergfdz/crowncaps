using UnityEngine;

public class GolManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Pelota"))
    {
        // Verifica qué arco fue golpeado
        if (gameObject.name == "PorteriaIzq") // Si es el arco del Jugador 1
        {
            GameManager.instance.GolJugador2(); // Suma al jugador 2
        }
        else if (gameObject.name == "PorteriaDer") // Si es el arco del Jugador 2
        {
            GameManager.instance.GolJugador1(); // Suma al jugador 1
        }
    }
}
}
