using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI puntosJugador1Text;
    public TextMeshProUGUI puntosJugador2Text;
    public TextMeshProUGUI mensajeVictoriaText;
    public Image imagenEndGame;
    public AudioSource audioGol; 

    public int puntosJugador1 = 0;
    public int puntosJugador2 = 0;

    public Transform posicionChapa1Jugador1;
    public Transform posicionChapa2Jugador1;
    public Transform posicionChapa3Jugador1;
    public Transform posicionChapa4Jugador1;
    public Transform posicionChapa1Jugador2;
    public Transform posicionChapa2Jugador2;
    public Transform posicionChapa3Jugador2;
    public Transform posicionChapa4Jugador2;
    public Transform posicionChapaAd1Jugador1;
    public Transform posicionChapaAd2Jugador1;
    public Transform posicionChapaAd3Jugador1;
    public Transform posicionChapaAd4Jugador1;
    public Transform posicionChapaAd1Jugador2;
    public Transform posicionChapaAd2Jugador2;
    public Transform posicionChapaAd3Jugador2;
    public Transform posicionChapaAd4Jugador2;
    public Transform posicionPelotaInicial;

    public GameObject imagenGol;

    public GameObject chapa1Jugador1;
    public GameObject chapa2Jugador1;
    public GameObject chapa3Jugador1;
    public GameObject chapa4Jugador1;
    public GameObject chapa1Jugador2;
    public GameObject chapa2Jugador2;
    public GameObject chapa3Jugador2;
    public GameObject chapa4Jugador2;

    public GameObject chapaAdicional1Jugador1;
    public GameObject chapaAdicional2Jugador1;
    public GameObject chapaAdicional3Jugador1;
    public GameObject chapaAdicional4Jugador1;
    public GameObject chapaAdicional1Jugador2;
    public GameObject chapaAdicional2Jugador2;
    public GameObject chapaAdicional3Jugador2;
    public GameObject chapaAdicional4Jugador2;

    public GameObject[] chapasJugador1;
    public GameObject[] chapasJugador2;
    public GameObject pelota;
    public GameObject campo;

    public GameObject porteroIzq;
    public GameObject porteroDer;


    public enum TurnoJugador { Jugador1, Jugador2 }
    public TurnoJugador turnoActual = TurnoJugador.Jugador1;
    public bool haLanzado = false;

    void Start()
    {
        porteroIzq.SetActive(false);
        porteroDer.SetActive(false);
        chapaAdicional1Jugador1.SetActive(false);
        chapaAdicional2Jugador1.SetActive(false);
        chapaAdicional3Jugador1.SetActive(false);
        chapaAdicional4Jugador1.SetActive(false);
        chapaAdicional1Jugador2.SetActive(false);
        chapaAdicional2Jugador2.SetActive(false);
        chapaAdicional3Jugador2.SetActive(false);
        chapaAdicional4Jugador2.SetActive(false);
        
        // Aplica los colores seleccionados
        campo.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorCampo;

        chapa1Jugador1.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador1;
        chapa2Jugador1.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador1;
        chapa3Jugador1.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador1;
        chapa4Jugador1.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador1;

        chapa1Jugador2.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador2;
        chapa2Jugador2.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador2;
        chapa3Jugador2.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador2;
        chapa4Jugador2.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador2;

        chapaAdicional1Jugador1.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador1;
        chapaAdicional2Jugador1.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador1;
        chapaAdicional3Jugador1.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador1;
        chapaAdicional4Jugador1.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador1;

        chapaAdicional1Jugador2.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador2;
        chapaAdicional2Jugador2.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador2;
        chapaAdicional3Jugador2.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador2;
        chapaAdicional4Jugador2.GetComponent<SpriteRenderer>().color = ConfigEquipos.colorJugador2;

        
        ActualizarOpacidadChapas();
        if (imagenGol != null)
            imagenGol.SetActive(false);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void GolJugador1()
    {
        if (audioGol != null) audioGol.Play();
        StartCoroutine(MostrarGolVisual(true));
        StartCoroutine(ProcesarGol("Jugador1"));
    }

    public void GolJugador2()
    {
        if (audioGol != null) audioGol.Play();
        StartCoroutine(MostrarGolVisual(false));
        StartCoroutine(ProcesarGol("Jugador2"));
    }

    public void CambiarTurno()
    {
    haLanzado = false;
    turnoActual = (turnoActual == TurnoJugador.Jugador1) ? TurnoJugador.Jugador2 : TurnoJugador.Jugador1;
    ActualizarOpacidadChapas();
    Debug.Log("Turno cambiado a: " + turnoActual);
    }

    void ReiniciarPosiciones()
    {
        pelota.transform.position = posicionPelotaInicial.position;
        pelota.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        pelota.GetComponent<Rigidbody2D>().angularVelocity = 0f;

        ReiniciarChapa(chapa1Jugador1, posicionChapa1Jugador1);
        ReiniciarChapa(chapa2Jugador1, posicionChapa2Jugador1);
        ReiniciarChapa(chapa3Jugador1, posicionChapa3Jugador1);
        ReiniciarChapa(chapa4Jugador1, posicionChapa4Jugador1);
        ReiniciarChapa(chapa1Jugador2, posicionChapa1Jugador2);
        ReiniciarChapa(chapa2Jugador2, posicionChapa2Jugador2);
        ReiniciarChapa(chapa3Jugador2, posicionChapa3Jugador2);
        ReiniciarChapa(chapa4Jugador2, posicionChapa4Jugador2);
        ReiniciarChapa(chapaAdicional1Jugador1, posicionChapaAd1Jugador1);
        ReiniciarChapa(chapaAdicional2Jugador1, posicionChapaAd2Jugador1);
        ReiniciarChapa(chapaAdicional3Jugador1, posicionChapaAd3Jugador1);
        ReiniciarChapa(chapaAdicional4Jugador1, posicionChapaAd4Jugador1);
        ReiniciarChapa(chapaAdicional1Jugador2, posicionChapaAd1Jugador2);
        ReiniciarChapa(chapaAdicional2Jugador2, posicionChapaAd2Jugador2);
        ReiniciarChapa(chapaAdicional3Jugador2, posicionChapaAd3Jugador2);
        ReiniciarChapa(chapaAdicional4Jugador2, posicionChapaAd4Jugador2);
    }

    void TerminarPartido(string mensajeGanador)
    {
        ResultadoFinal.mensajeGanador = mensajeGanador;
        ResultadoFinal.puntosJugador1 = puntosJugador1;
        ResultadoFinal.puntosJugador2 = puntosJugador2;
        UnityEngine.SceneManagement.SceneManager.LoadScene("FinPartido");
    }

    void ReiniciarChapa(GameObject chapa, Transform posicion)
    {
        chapa.transform.position = posicion.position;
        var rb = chapa.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    public void ActualizarOpacidadChapas()  
    {
        // Define el valor de opacidad
        float opacidadActiva = 1f;  
        float opacidadInactiva = 0.3f;  

        // Jugador 1
        CambiarOpacidadChapa(chapa1Jugador1, turnoActual == TurnoJugador.Jugador1 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapa2Jugador1, turnoActual == TurnoJugador.Jugador1 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapa3Jugador1, turnoActual == TurnoJugador.Jugador1 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapa4Jugador1, turnoActual == TurnoJugador.Jugador1 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapaAdicional1Jugador1, turnoActual == TurnoJugador.Jugador1 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapaAdicional2Jugador1, turnoActual == TurnoJugador.Jugador1 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapaAdicional3Jugador1, turnoActual == TurnoJugador.Jugador1 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapaAdicional4Jugador1, turnoActual == TurnoJugador.Jugador1 ? opacidadActiva : opacidadInactiva);

        // Jugador 2
        CambiarOpacidadChapa(chapa1Jugador2, turnoActual == TurnoJugador.Jugador2 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapa2Jugador2, turnoActual == TurnoJugador.Jugador2 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapa3Jugador2, turnoActual == TurnoJugador.Jugador2 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapa4Jugador2, turnoActual == TurnoJugador.Jugador2 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapaAdicional1Jugador2, turnoActual == TurnoJugador.Jugador2 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapaAdicional2Jugador2, turnoActual == TurnoJugador.Jugador2 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapaAdicional3Jugador2, turnoActual == TurnoJugador.Jugador2 ? opacidadActiva : opacidadInactiva);
        CambiarOpacidadChapa(chapaAdicional4Jugador2, turnoActual == TurnoJugador.Jugador2 ? opacidadActiva : opacidadInactiva);
    }

    private void CambiarOpacidadChapa(GameObject chapa, float opacidad)
    {
        SpriteRenderer renderer = chapa.GetComponent<SpriteRenderer>();
        Color color = renderer.color;
        color.a = opacidad;  
        renderer.color = color;  
    }

    void SetChapasYpelotaVisibles(bool visible)
    {
        foreach (GameObject chapa in chapasJugador1)
        {
            var sr = chapa.GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = visible;
        }

        foreach (GameObject chapa in chapasJugador2)
        {
            var sr = chapa.GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = visible;
        }

        if (pelota != null)
        {
            var sr = pelota.GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = visible;
        }

    }

    private IEnumerator ProcesarGol(string jugador)
{
    yield return new WaitForSeconds(2.0f); 

    if (jugador == "Jugador1")
    {
        puntosJugador1++;
        puntosJugador1Text.text = $"{puntosJugador1}";
        Debug.Log("¡Gol del Jugador 1!");

        if (puntosJugador1 >= 1)
            porteroDer.SetActive(true);

        if (puntosJugador1 >= 2){
            chapaAdicional1Jugador2.SetActive(true);
            chapaAdicional2Jugador2.SetActive(true);
            chapaAdicional3Jugador2.SetActive(true);
            chapaAdicional4Jugador2.SetActive(true);
        }

        if (puntosJugador1 >= 3)
        {
            TerminarPartido("¡Jugador 1 gana!");
            yield break;
        }
    }
    else if (jugador == "Jugador2")
    {
        puntosJugador2++;
        puntosJugador2Text.text = $"{puntosJugador2}";
        Debug.Log("¡Gol del Jugador 2!");

        if (puntosJugador2 >= 1)
            porteroIzq.SetActive(true);

        if (puntosJugador2 >= 2){
            chapaAdicional1Jugador1.SetActive(true);
            chapaAdicional2Jugador1.SetActive(true);
            chapaAdicional3Jugador1.SetActive(true);
            chapaAdicional4Jugador1.SetActive(true);
        }

        if (puntosJugador2 >= 3)
        {
            TerminarPartido("¡Jugador 2 gana!");
            yield break;
        }
    }

    ReiniciarPosiciones();
    ActualizarOpacidadChapas();
}

    IEnumerator MostrarGolVisual(bool espejo)
    {
        if (imagenGol != null)
        {
            imagenGol.transform.localScale = new Vector3(espejo ? -1 : 1, 1, 1);

            SetChapasYpelotaVisibles(false); 
            imagenGol.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            imagenGol.SetActive(false);
            SetChapasYpelotaVisibles(true);
        }
    }

}
