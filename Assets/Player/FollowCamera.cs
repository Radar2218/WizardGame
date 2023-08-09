using UnityEngine;
using Unity.Mathematics;

public class FollowCamera : MonoBehaviour
{
	public float cameraSpeed, snapDistance;
	public GameObject target;
	public Rect cameraDeadZone;

	void Start()
	{
		math.clamp(cameraSpeed, 0.0f, 1.0f);
		transform.position = virtualTargetPos;
	}

	void Update()
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
