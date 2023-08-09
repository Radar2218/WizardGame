using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public GameObject followCamera;
	public Rect cameraDeadZone;

	void Start()
	{
		followCamera.transform.position = new Vector3
		(
			transform.position.x,
			transform.position.y,
			followCamera.transform.position.z
		);
	}

	void Update()
	{
		followCamera.transform.position = new Vector3
		(
			transform.position.x,
			transform.position.y,
			followCamera.transform.position.z
		);
	}
}
