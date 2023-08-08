using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed, jumpSpeed;
	private Rigidbody2D rigidbodyComp;

	public void Start()
	{
		rigidbodyComp = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		rigidbodyComp.velocity = new Vector2(speed * horizontalInput, rigidbodyComp.velocity.y);

		if (Input.GetButtonDown("Jump"))
		{
			rigidbodyComp.velocity = new Vector2(rigidbodyComp.velocity.x, jumpSpeed);
		}
	}
}
