using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public const string GAME_OVER = "gameOver";
	public const string INFECTED = "infected";

	public static AudioClip gameOver, infected, music;
	static AudioSource audioSource;
	static AudioSource musicSource;

	public static AudioManager instance;

	private void Awake() {
		gameOver = null;// Resources.Load<AudioClip>("Audio/Sfx/game_over");
		infected = null;//Resources.Load<AudioClip>("Audio/Sfx/infected");
		music = Resources.Load<AudioClip>("Audio/Music/music");
		audioSource = this.GetComponent<AudioSource>();
		musicSource = gameObject.transform.Find("MusicSource").GetComponent<AudioSource>();
	}

	private void Start() {
		musicSource.loop = true;
		musicSource.clip = music;
		musicSource.volume = .4f;
		musicSource.Play();
	}

	private void Update() {
	}

	public static void Play(string name) {
		switch (name) {
			case GAME_OVER:
				audioSource.PlayOneShot(gameOver);
				break;
			case INFECTED:
				audioSource.PlayOneShot(infected);
				break;
		}
	}
}
