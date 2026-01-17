using UnityEngine;

public class BrickSpriteRandomizer : MonoBehaviour
{

    [SerializeField] private Sprite[] brickSprites;

    private  float[] brickRotations = { 0f, 90f, 180f, 270f };

	/// <summary>
	/// Start is called once before the first execution of Update after the MonoBehaviour is created
	/// </summary>
	void Start()
    {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

		// set random sprite
		int randomSpriteIndex = Random.Range(0, brickSprites.Length);
		spriteRenderer.sprite = brickSprites[randomSpriteIndex];

		// set random rotation
		float randomRotation = brickRotations[Random.Range(0, brickRotations.Length)];
		transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
	}
}
