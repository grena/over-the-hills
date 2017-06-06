using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreCalculator : MonoBehaviour {

    private Text textGUI;

	// Use this for initialization
	void Start () {
        textGUI = GameObject.Find("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        int score = (int) Math.Round(Camera.main.transform.position.x, 0) * 10;
        textGUI.text = "Score: " + score;
	}
}
