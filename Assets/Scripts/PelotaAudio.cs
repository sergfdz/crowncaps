using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PelotaAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Solo reproducir si el objeto que la toca no es el suelo o la portería
        if (collision.relativeVelocity.magnitude > 0.2f && collision.collider.CompareTag("Jugador1"))
        {
            audioSource.Play();
        }
        else if (collision.relativeVelocity.magnitude > 0.2f && collision.collider.CompareTag("Jugador2"))
        {
            audioSource.Play();
        }
    }
}
