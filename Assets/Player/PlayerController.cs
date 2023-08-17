using UnityEngine;
using Unity.Mathematics;

public class PlayerController : MonoBehaviour
{
	public float speed, jumpSpeed;
	public Vector2 projectileOffset;
	public LayerMask groundMask;
	public GameObject projectile;

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

		if (math.sign(horizontalInput) != 0.0f && math.sign(horizontalInput) != math.sign(transform.localScale.x))
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			rigidbodyComp.velocity = new Vector2(rigidbodyComp.velocity.x, jumpSpeed);
		}

		if (Input.GetButtonDown("Fire1"))
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
			Vector3 rightDirection = mousePosition - transform.position;
			Vector3 upwardsDirection = Vector3.Cross(rightDirection, Vector3.forward);
			Instantiate(projectile, transform.position + new Vector3(projectileOffset.x, projectileOffset.y), Quaternion.LookRotation(rightDirection, upwardsDirection));
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(projectileOffset, 0.2f);
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
