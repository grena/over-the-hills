using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour {

    [Header("Movements")]
    public float moveSpeed;
    public float rotationSpeed;
    public GameObject target;
    public float fleeDistance;
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
        GameObject wolf = GameObject.FindGameObjectWithTag("Wolf");
        if (wolf != null && Vector3.Distance(wolf.transform.position, transform.position) <= fleeDistance)
        {
            Flee(wolf);   
        }
        else
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        Vector3 vectorToTarget = (target.transform.position - transform.position);
        Vector3 newAccelerationVector = vectorToTarget.normalized * moveSpeed;

        movementVector = (70 * movementVector + newAccelerationVector) / 71;
        Vector3 cleanMovementVector = new Vector3(movementVector.x, movementVector.y, 0f);

        transform.position = transform.position + cleanMovementVector * Time.deltaTime;

        // Rotate the sprite
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    void Flee(GameObject wolf)
    {
        //Debug.Log("FLEEING WOLF AT " + wolf.transform.position);
		Vector3 vectorToFleeTarget = (transform.position - wolf.transform.position);
        Vector3 newAccelerationVector = vectorToFleeTarget.normalized * moveSpeed;

        //Debug.Log("NEW VECTOR = " + newAccelerationVector);

        movementVector = (70 * movementVector + newAccelerationVector) / 71;
        Vector3 cleanMovementVector = new Vector3(movementVector.x, movementVector.y, 0f);

        transform.position = transform.position + cleanMovementVector * Time.deltaTime;

        // Rotate the sprite
        float angle = Mathf.Atan2(vectorToFleeTarget.y, vectorToFleeTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
