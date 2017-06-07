using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ScoreCalculator : MonoBehaviour {

    public int dodgedWolves = 0;

    private bool gameEnded = false;
    private Text textGUI;
    private int distance = 0;
    private int remainingSheeps = 0;    

	// Use this for initialization
	void Start () {
        textGUI = GameObject.Find("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        distance = (int) Math.Round(Camera.main.transform.position.x, 0) * 10;
        remainingSheeps = GameObject.FindGameObjectsWithTag("Sheep").Length;

        textGUI.text = "Distance: " + distance;
        textGUI.text += "      Remaining sheeps: " + remainingSheeps;
        textGUI.text += "      Dodged wolves: " + dodgedWolves;

        if (!gameEnded && remainingSheeps == 0)
        {
            EndGame();
        }

        if (gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Evasion");
            }
        }
    }

    void EndGame()
    {
        gameEnded = true;

        CameraMover moverScript = GetComponent<CameraMover>();
        moverScript.enabled = false;

        int score = distance + dodgedWolves * 250;

        GameObject.Find("IntroText").GetComponent<Text>().text = "SCORE: " + score;
        GameObject.Find("IntroText").GetComponent<Text>().enabled = true;
    }
}
