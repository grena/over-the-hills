using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public Vector3 target;

	private Vector3 movementVector;

	// Use this for initialization
	void Start () {
		target = new Vector3 (50000, 0, -10);
	}

	// Update is called once per frame
	void Update () {
		Vector3 vectorToTarget = (target - Camera.main.transform.position);
		Vector3 newAccelerationVector = vectorToTarget.normalized * moveSpeed;

		movementVector = (70 * movementVector + newAccelerationVector) / 71;

		Camera.main.transform.position = Camera.main.transform.position + movementVector * Time.deltaTime;
	}
}
