using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPlayer : MonoBehaviour {

	public AudioClip introMusic;
	public AudioClip gameMusic;
	public AudioClip destroySound;

	// Use this for initialization
	IEnumerator Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = introMusic;
		audio.Play ();

		yield return new WaitForSeconds(3);

		// Destroy fence
		audio.clip = destroySound;
		audio.Play();

		GameObject fence = GameObject.Find("MainFrontFence");
		Destroy (fence);

		yield return new WaitForSeconds(audio.clip.length + 2);

		// Start game!
		CameraMover moverScript = GetComponent<CameraMover>();
		moverScript.enabled = true;

		audio.clip = gameMusic;
		audio.Play ();
		audio.time = 28;

		// Display message to "ESCAPE!"
	}
}
