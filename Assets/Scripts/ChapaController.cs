using UnityEngine;

public class ChapaController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    private bool isDragging = false;

    public float power = 10f;
    public float maxDragDistance = 2f;
    private LineRenderer lineRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.enabled = false;
        }
    }

    private void Update()
    {

        if (!EsMiTurno()) return;

        if (isDragging)
        {
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rawDirection = startPos - currentPos;
            Vector2 clampedDirection = Vector2.ClampMagnitude(rawDirection, maxDragDistance);

            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(0, startPos);
                lineRenderer.SetPosition(1, startPos + clampedDirection);
            }
        }
    }

    private void OnMouseDown()
    {

        if (!EsMiTurno() || GameManager.instance.haLanzado) return;

        if (rb.linearVelocity.magnitude < 0.1f)
        {
            startPos = transform.position;
            isDragging = true;
            if (lineRenderer != null) lineRenderer.enabled = true;
        }
    }

    private void OnMouseUp()
    {

        if (!EsMiTurno() || GameManager.instance.haLanzado) return;

        if (isDragging)
        {
            Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rawDirection = startPos - endPos;
            Vector2 clampedForce = Vector2.ClampMagnitude(rawDirection, maxDragDistance) * power;

            rb.AddForce(clampedForce, ForceMode2D.Impulse);
            isDragging = false;
            if (lineRenderer != null) lineRenderer.enabled = false;

            GameManager.instance.haLanzado = true;
            GameManager.instance.Invoke("CambiarTurno", 2f); // Cambia de turno tras 2 segundos
        }
    }

    private bool EsMiTurno()
    {
        return (CompareTag("Jugador1") && GameManager.instance.turnoActual == GameManager.TurnoJugador.Jugador1)
            || (CompareTag("Jugador2") && GameManager.instance.turnoActual == GameManager.TurnoJugador.Jugador2);
    }
}
