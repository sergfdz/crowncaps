using UnityEngine;
using TMPro;

public class UIResultado : MonoBehaviour
{
    public TextMeshProUGUI textoGanador;
    public TextMeshProUGUI textoResultado;

    void Start()
    {
        textoGanador.text = ResultadoFinal.mensajeGanador;
        textoResultado.text = $"{ResultadoFinal.puntosJugador1} - {ResultadoFinal.puntosJugador2}";
    }

    public void VolverAlMenu()
    {
        // Aquí puedes cargar la escena del menú principal
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal"); 
    }
    public void ReiniciarPartida()
    {
        // Aquí puedes cargar la escena del partido
        UnityEngine.SceneManagement.SceneManager.LoadScene("CampoChapas"); 
    }
}
