using UnityEngine;

public class HomingBullet2D : MonoBehaviour
{
    private Vector2 targetPosition;
    private float moveSpeed = 10f;

    // Called by the shooter script immediately after instantiating the bullet
    public void SetTarget(Vector2 target, float speed)
    {
        targetPosition = target;
        moveSpeed = speed;
    }

    void Update()
    {
        // Move the bullet toward the locked target position every frame
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Destroy the bullet once it reaches the target destination to clean up memory
        if ((Vector2)transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Optional: Destroy on hitting the player or obstacles
        if (collision.CompareTag("Player") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
