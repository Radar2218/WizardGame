using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed, jumpSpeed;
	public LayerMask groundMask;

	private Rigidbody2D rigidbodyComp;
	private CapsuleCollider2D capsuleCollider;

	void Start()
	{
		rigidbodyComp = GetComponent<Rigidbody2D>();
		capsuleCollider = GetComponent<CapsuleCollider2D>();
	}

	void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		rigidbodyComp.velocity = new Vector2(speed * horizontalInput, rigidbodyComp.velocity.y);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			rigidbodyComp.velocity = new Vector2(rigidbodyComp.velocity.x, jumpSpeed);
		}
	}

	bool isGrounded
	{
		get {
			return Physics2D.CapsuleCast
			(
				capsuleCollider.bounds.center,
				capsuleCollider.bounds.size,
				capsuleCollider.direction,
				0.0f,
				Vector2.down,
				0.1f,
				groundMask
			);
		}
	}
}
