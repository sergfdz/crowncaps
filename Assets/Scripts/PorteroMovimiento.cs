using UnityEngine;

public class PorteroMovimiento : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento
    public float limiteSuperior = 2.5f;
    public float limiteInferior = -2.5f;

    private int direccion = 1; // 1 = hacia arriba, -1 = hacia abajo

    void Update()
    {
        transform.Translate(Vector2.up * direccion * velocidad * Time.deltaTime);

        // Cambiar dirección al llegar a los límites
        if (transform.position.y >= limiteSuperior)
            direccion = -1;
        else if (transform.position.y <= limiteInferior)
            direccion = 1;
    }
}