using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepInitiator : MonoBehaviour {

    [Header("Parameters")]
    public int sheepNumber;

    [Header("Collaborators")]
    public GameObject sheepModel;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < sheepNumber; i++)
        {
            GameObject sheep = Instantiate(sheepModel);
            sheep.GetComponent<SheepAI>().target = GameObject.FindGameObjectWithTag("Cursor");
            sheep.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 1);
        }
	}
}
