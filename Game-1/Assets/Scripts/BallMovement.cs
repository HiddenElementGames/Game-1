using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
	// The force applied in the y direction when the ball is spawned
    [SerializeField] private float speed;

	// scale factor for the force applied in the x direction when hitting the paddle
	[SerializeField] private float hitPaddleForceXScale;

	Rigidbody2D ballRigidbody;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		// Move the ball downwards at the start of the game
		ballRigidbody = GetComponent<Rigidbody2D>();
		ballRigidbody.linearVelocityY = -speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// check if the ball ran into the player, if so, move the ball relative to the players position
		if (collision.gameObject.GetComponent<PlayerPaddleMovement>() != null)
		{
			// Calculate the offset from the center of the paddle (-1 to 1)
			float paddleWidth = collision.collider.bounds.size.x;
			float ballPosition = transform.position.x;
			float paddleCenter = collision.transform.position.x;

			// Normalize the offset: 0 = center, -1 = left edge, 1 = right edge
			float offsetFromCenter = (ballPosition - paddleCenter) / (paddleWidth / 2);

			// Clamp to ensure we stay within -1 to 1 range
			offsetFromCenter = Mathf.Clamp(offsetFromCenter, -1f, 1f);

			// Apply force based on offset (more force at edges, less at center)
			float forceToApply = hitPaddleForceXScale * offsetFromCenter * speed / 2;
			ballRigidbody.AddRelativeForceX(forceToApply);

			// normalize the velocity to maintain consistent speed
			ballRigidbody.linearVelocity = ballRigidbody.linearVelocity.normalized * speed;
		}
	}
}
