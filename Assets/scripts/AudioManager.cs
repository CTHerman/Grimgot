using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public const string GAME_OVER = "gameOver";
	public const string INFECTED = "infected";

	public static AudioClip music;
	public static AudioClip alert, charge, charging, collect, collect2, collect3, death1, drop, explode, fall, halt, jump, lose1, powerup, stomp, stop, takeoff, womp;
	static AudioSource audioSource;
	static AudioSource musicSource;
	private int audioSampler = 0;

	public static AudioManager instance;

	private void Awake() {
		alert = Resources.Load<AudioClip>("Audio/Sfx/alert");
		charge = Resources.Load<AudioClip>("Audio/Sfx/charge");
		charging = Resources.Load<AudioClip>("Audio/Sfx/charging");
		collect = Resources.Load<AudioClip>("Audio/Sfx/collect");
		collect2 = Resources.Load<AudioClip>("Audio/Sfx/collect2");
		collect3 = Resources.Load<AudioClip>("Audio/Sfx/collect3");
		death1 = Resources.Load<AudioClip>("Audio/Sfx/death1");
		drop = Resources.Load<AudioClip>("Audio/Sfx/drop");
		explode = Resources.Load<AudioClip>("Audio/Sfx/explode");
		fall = Resources.Load<AudioClip>("Audio/Sfx/fall");
		halt = Resources.Load<AudioClip>("Audio/Sfx/halt");
		jump = Resources.Load<AudioClip>("Audio/Sfx/jump");
		lose1 = Resources.Load<AudioClip>("Audio/Sfx/lose1");
		powerup = Resources.Load<AudioClip>("Audio/Sfx/powerup");
		stomp = Resources.Load<AudioClip>("Audio/Sfx/stomp");
		stop = Resources.Load<AudioClip>("Audio/Sfx/stop");
		takeoff = Resources.Load<AudioClip>("Audio/Sfx/takeoff");
		womp = Resources.Load<AudioClip>("Audio/Sfx/womp");
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
		if (Input.GetKeyDown(KeyCode.Period)) {
			audioSampler++;
			if (audioSampler > 17) audioSampler = 0;
			Play(audioSampler);
		} else if (Input.GetKeyDown(KeyCode.Comma)) {
			audioSampler--;
			if (audioSampler < 0) audioSampler = 17;
			Play(audioSampler);
		} else if (Input.GetKeyDown(KeyCode.Slash)) {
			Play(audioSampler);
		}
	}

	public static void Play(string name) {
		switch (name) {
			case GAME_OVER:
				//audioSource.PlayOneShot(gameOver);
				break;
			case INFECTED:
				//audioSource.PlayOneShot(infected);
				break;
		}
	}

    public static void Play(int audioSampler) {
		switch (audioSampler) {
			case 0:
				audioSource.PlayOneShot(alert);
				Debug.Log("alert");
				break;
			case 1:
				audioSource.PlayOneShot(charge);
				Debug.Log("charge");
				break;
			case 2:
				audioSource.PlayOneShot(charging);
				Debug.Log("charging");
				break;
			case 3:
				audioSource.PlayOneShot(collect);
				Debug.Log("collect");
				break;
			case 4:
				audioSource.PlayOneShot(collect2);
				Debug.Log("collect2");
				break;
			case 5:
				audioSource.PlayOneShot(collect3);
				Debug.Log("collect3");
				break;
			case 6:
				audioSource.PlayOneShot(death1);
				Debug.Log("death1");
				break;
			case 7:
				audioSource.PlayOneShot(drop);
				Debug.Log("drop");
				break;
			case 8:
				audioSource.PlayOneShot(explode);
				Debug.Log("explode");
				break;
			case 9:
				audioSource.PlayOneShot(fall);
				Debug.Log("fall");
				break;
			case 10:
				audioSource.PlayOneShot(halt);
				Debug.Log("halt");
				break;
			case 11:
				audioSource.PlayOneShot(jump);
				Debug.Log("jump");
				break;
			case 12:
				audioSource.PlayOneShot(lose1);
				Debug.Log("lose1");
				break;
			case 13:
				audioSource.PlayOneShot(powerup);
				Debug.Log("powerup");
				break;
			case 14:
				audioSource.PlayOneShot(stomp);
				Debug.Log("stomp");
				break;
			case 15:
				audioSource.PlayOneShot(stop);
				Debug.Log("stop");
				break;
			case 16:
				audioSource.PlayOneShot(takeoff);
				Debug.Log("takeoff");
				break;
			case 17:
				audioSource.PlayOneShot(womp);
				Debug.Log("womp");
				break;
			default:
				audioSampler = 0;
				audioSource.PlayOneShot(alert);
				Debug.Log("alert");
				break;
		}
	}
}
