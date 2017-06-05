using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour {

    [Header("Collaborators")]
    public GameObject groundModel;

    private GameObject ground1;
    private GameObject ground2;

    // Use this for initialization
    void Start () {
        ground1 = Instantiate(groundModel);
        ground1.transform.position = new Vector3(0f, 0f, 2f);

        InstantiateGroundNextTo(ground1);
    }
	
	// Update is called once per frame
	void Update () {
        
		if (Time.time > 2 && ground1 == null)
        {
            ground1 = ground2;
            InstantiateGroundNextTo(ground1);
        }
        
	}

    void InstantiateGroundNextTo(GameObject ground)
    {
        ground2 = Instantiate(groundModel);
        ground2.transform.position = new Vector3(ground.transform.position.x + 10, 0f, 2f);
    }
}
