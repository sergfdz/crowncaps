using UnityEngine;

public class AntiStuck : MonoBehaviour
{
    private Rigidbody2D rb;
    private float stuckTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude < 0.05f)
        {
            stuckTimer += Time.deltaTime;
            if (stuckTimer > 2f)
            {
                rb.AddForce(Random.insideUnitCircle.normalized * 0.5f, ForceMode2D.Impulse);
                stuckTimer = 0f;
            }
        }
        else
        {
            stuckTimer = 0f;
        }
    }
}
