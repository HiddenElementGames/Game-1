using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPaddleMovement : MonoBehaviour
{
	// attach the player's rigidbody in the inspector
	[SerializeField] private Rigidbody2D playerRigidbody;

	// speed of the paddle, change in the inspector
	[SerializeField] private float speed;

	// Gets called by the input system when the player presses move keys (WASD)
	private void OnMove(InputValue value)
    {
		// get the input
		Vector2 inputVector = value.Get<Vector2>();

		// only move on the x axis
		Vector2 movement = new Vector2(inputVector.x, 0);

		// set the player velocity
		playerRigidbody.linearVelocity = movement * speed;
	}
}
