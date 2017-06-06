using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour {

    [Header("Movements")]
    public float moveSpeed;
    public float rotationSpeed;
    [Space(10)]

    public float detectionRadius;

    private GameObject target;
    private Vector3 movementVector;

    // Use this for initialization
    void Start () {
        movementVector = new Vector3(moveSpeed, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            MoveToTarget();
        }
        else
        {
            WaitForTarget();
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

    void WaitForTarget()
    {
        GameObject[] sheeps = GameObject.FindGameObjectsWithTag("Sheep");

        foreach (GameObject sheep in sheeps)
        {
            if (Vector3.Distance(sheep.transform.position, transform.position) <= detectionRadius)
            {
                target = sheep;
                break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("DESTROYING !!!");
        if (col.gameObject.CompareTag("Sheep"))
        {
            Destroy(col.gameObject);
        }
    }
}
