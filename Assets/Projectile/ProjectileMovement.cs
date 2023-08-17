using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
	public float speed, deadZoneOffset;

	private Rect projectileDeadZone;
	private Rigidbody2D rigidbodyComp;

	void Start()
	{
		LogicManager logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
		projectileDeadZone = new(logicManager.screenRect);

		projectileDeadZone.x -= deadZoneOffset;
		projectileDeadZone.width += 2 * deadZoneOffset;
		projectileDeadZone.y -= deadZoneOffset;
		projectileDeadZone.height += 2 * deadZoneOffset;
		
		rigidbodyComp = GetComponent<Rigidbody2D>();
		rigidbodyComp.velocity = transform.right * speed;
	}

	void Update()
	{
		if (!projectileDeadZone.Contains(transform.position))
			Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag != "Player")
			Destroy(gameObject);
	}
}
