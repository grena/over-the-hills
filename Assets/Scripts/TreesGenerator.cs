using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesGenerator : MonoBehaviour {

    public GameObject[] obstacleModels;
    public int maxObstacles;

    private List<GameObject> obstacles;
    private int count = 0;

    // Use this for initialization
    void Start () {
        obstacles = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        obstacles.RemoveAll(item => item == null);

        if (count < maxObstacles)
        {
            CreateNewObstacle();
        }
	}

    void CreateNewObstacle()
    {
        int index = Random.Range(0, obstacleModels.Length);
        GameObject obstacle = Instantiate(obstacleModels[index]);

        Vector3 pos = new Vector3(Camera.main.transform.position.x + Random.Range(5f, 10f), Random.Range(-5f, 5f), 0f);
        obstacle.transform.position = pos;

        count++;

        //obstacles.Add(obstacle);
    }
}
