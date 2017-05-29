using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour {

    [Header("Movements")]
    public float moveSpeed;
    public float rotationSpeed;
    public GameObject target;
    [Space(10)]

    private Vector3 movementVector;

    // Use this for initialization
    void Start()
    {
        movementVector = new Vector3(moveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = (target.transform.position - transform.position);
        Vector3 newAccelerationVector = vectorToTarget.normalized * moveSpeed;

        movementVector = (70 * movementVector + newAccelerationVector) / 71;

        transform.position = transform.position + movementVector * Time.deltaTime;

        // Rotate the sprite
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
