using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour {

    public GameObject[] obstacleModels;
    public GameObject wolfModel;

    public float intervalSecondTree = 1f;
    public int maxTreesPerBatch = 5;
    public float intervalSecondWolf = 4f;
    public float percentChanceWolf = 10f;

    private List<GameObject> obstacles;

    // Use this for initialization
    void Start () {
        obstacles = new List<GameObject>();

        StartCoroutine("TryToPutWolf");
        StartCoroutine("PopulateTrees");
    }
	
	// Update is called once per frame
	void Update () {
        obstacles.RemoveAll(item => item == null);
    }

    void CreateWolf()
    {
        Debug.Log("POPULATE WOLF");
        GameObject wolf = Instantiate(wolfModel);

        Vector3 pos = new Vector3(Camera.main.transform.position.x + UnityEngine.Random.Range(8f, 13f), UnityEngine.Random.Range(-3f, 3f), 0f);
        wolf.transform.position = pos;
    }

    void CreateTree()
    {
        int index = UnityEngine.Random.Range(0, obstacleModels.Length);
        GameObject obstacle = Instantiate(obstacleModels[index]);

        Vector3 pos = new Vector3(Camera.main.transform.position.x + UnityEngine.Random.Range(8f, 13f), UnityEngine.Random.Range(-3f, 3f), 0f);
        obstacle.transform.position = pos;

        obstacles.Add(obstacle);
    }

    IEnumerator PopulateTrees()
    {
        for (;;)
        {
            int quantity = UnityEngine.Random.Range(0, maxTreesPerBatch);

            for (int i = 0; i < quantity; i++)
            {
                CreateTree();
            }

            yield return new WaitForSeconds(intervalSecondTree);
        }
    }

    IEnumerator TryToPutWolf()
    {
        for (;;)
        {
            bool noWolf = GameObject.FindGameObjectWithTag("Wolf") == null;

            if (noWolf)
            {
                float rand = UnityEngine.Random.Range(0f, 100f);
                if (rand < percentChanceWolf)
                {
                    CreateWolf();
                }
            }
            
            yield return new WaitForSeconds(intervalSecondWolf);
        }
    }
}
