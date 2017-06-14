using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPlayer : MonoBehaviour {

	public AudioClip introMusic;
	public AudioClip gameMusic;
	public AudioClip destroySound;

	// Use this for initialization
	IEnumerator Start () {
        
        AudioSource audio = GetComponent<AudioSource>();
        
		audio.clip = introMusic;
		audio.Play ();

		yield return new WaitForSeconds(10);

        // Destroy fence
        audio.clip = destroySound;
		audio.Play();

		GameObject fence = GameObject.Find("MainFrontFence");
		Destroy (fence);

		yield return new WaitForSeconds(audio.clip.length - 0.5f);
        

		// Start game!
		CameraMover moverScript = GetComponent<CameraMover>();
		moverScript.enabled = true;

        ObstaclesGenerator obstaclesScript = GetComponent<ObstaclesGenerator>();
        obstaclesScript.enabled = true;

        GameObject.Find("IntroText").GetComponent<Text>().enabled = true;
        GameObject.Find("ScoreText").GetComponent<Text>().enabled = true;

        audio.clip = gameMusic;
		audio.Play ();
		audio.time = 27;

        yield return new WaitForSeconds(4);

        GameObject.Find("IntroText").GetComponent<Text>().enabled = false;
    }
}
