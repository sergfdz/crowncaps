using UnityEngine;

public class ChapaController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    private bool isDragging = false;

    public float power = 10f; // Fuerza del tiro
    public float maxDragDistance = 2f; // Distancia máxima que se puede arrastrar

    private LineRenderer lineRenderer; // Línea para la flecha

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rawDirection = startPos - currentPos;

            // Limitar la distancia máxima
            Vector2 clampedDirection = Vector2.ClampMagnitude(rawDirection, maxDragDistance);

            // Dibujar la flecha desde el centro de la chapa hacia la dirección limitada
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, startPos + clampedDirection);
        }
    }

    private void OnMouseDown()
    {
        if (rb.linearVelocity.magnitude < 0.1f)
        {
            startPos = transform.position; // Usamos el centro real de la chapa como inicio
            isDragging = true;
            lineRenderer.enabled = true;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rawDirection = startPos - endPos;

            // Limitar la fuerza aplicada con la misma distancia máxima
            Vector2 clampedForce = Vector2.ClampMagnitude(rawDirection, maxDragDistance) * power;

            rb.AddForce(clampedForce, ForceMode2D.Impulse);
            isDragging = false;
            lineRenderer.enabled = false;
        }
    }
}
