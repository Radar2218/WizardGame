using UnityEngine;
using Unity.Mathematics;

public class ParallaxEffect : MonoBehaviour
{
	public float positionInLayer;
	
	private Camera mainCamera;
	private float xPosition0, spriteWidth;

	void Start()
	{
		positionInLayer = math.clamp(positionInLayer, 0.0f, 1.0f);

		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
		xPosition0 = transform.position.x;

		if (xPosition0 == 0.0f && positionInLayer < 1.0f)
			Instantiate(gameObject, transform.position + new Vector3(spriteWidth, 0, 0), transform.rotation);
	}
	
	void Update()
	{
		float cameraPosX = mainCamera.transform.position.x;
		float newXPosition = xPosition0 + mainCamera.transform.position.x * positionInLayer;

		transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

		if (positionInLayer < 1.0f)
		{
			if (cameraPosX - newXPosition > spriteWidth)
				xPosition0 += spriteWidth * 2;
			if (cameraPosX - newXPosition < -spriteWidth)
				xPosition0 -= spriteWidth * 2;
		}
	}
}
