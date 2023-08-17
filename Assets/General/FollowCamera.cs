using UnityEngine;
using Unity.Mathematics;

public class FollowCamera : MonoBehaviour
{
	public float cameraSpeed, snapDistance;
	public GameObject target;

	private Rect cameraDeadZone;

	void Start()
	{
		math.clamp(cameraSpeed, 0.0f, 1.0f);
		transform.position = virtualTargetPos;

		LogicManager logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
		cameraDeadZone = new(logicManager.screenRect);
		
		Camera cameraComponent = GetComponent<Camera>();

		cameraDeadZone.y += cameraComponent.orthographicSize;
		cameraDeadZone.height -= 2.0f * cameraComponent.orthographicSize;
		if (cameraDeadZone.height < 0.0f) cameraDeadZone.height = 0.0f;
		
		cameraDeadZone.x += cameraComponent.orthographicSize * Screen.width / Screen.height;
		cameraDeadZone.width -= 2.0f * cameraComponent.orthographicSize * Screen.width / Screen.height;
		if (cameraDeadZone.width < 0.0f) cameraDeadZone.width = 0.0f;
	}

	void FixedUpdate()
	{
		Vector3 distance = virtualTargetPos - transform.position;
		
		if (distance.magnitude < snapDistance)
			transform.position = virtualTargetPos;
		else
			transform.position += distance * cameraSpeed * Time.deltaTime;
	}

	Vector3 virtualTargetPos
	{
		get
		{
			return new
			(
				math.clamp(target.transform.position.x, cameraDeadZone.xMin, cameraDeadZone.xMax),
				math.clamp(target.transform.position.y, cameraDeadZone.yMin, cameraDeadZone.yMax),
				transform.position.z
			);
		}
	}
}
