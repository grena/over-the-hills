using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour {

    [Header("Movements")]
    public float moveSpeed;
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
        Vector3 toTargetVector = (target.transform.position - transform.position);
        Vector3 newAccelerationVector = toTargetVector.normalized * moveSpeed;

        movementVector = (50 * movementVector + newAccelerationVector) / 51;

        transform.position = transform.position + movementVector;
    }
}
