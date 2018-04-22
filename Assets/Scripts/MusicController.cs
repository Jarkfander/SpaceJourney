using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour {

	[SerializeField]
	private AudioClip[] playList;
	private AudioSource audioSource;

	[SerializeField]
	float delayBetweenSongs = 10.0f;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		if(playList.Length == 0){
			Destroy(audioSource);
			Destroy(this);
		}
		StartCoroutine(playNextSongAfter(0.0f));
	}

	float SetRandomSong(){

		int clipIndex = Random.Range(0, playList.Length);
		audioSource.clip = playList[clipIndex];

		audioSource.Play();

		return audioSource.clip.length;
	}

	IEnumerator playNextSongAfter(float timeToWait){
		yield return new WaitForSeconds(timeToWait);
		float timeToWaitBeforeNextSong = SetRandomSong() + delayBetweenSongs;
		StartCoroutine(playNextSongAfter(timeToWaitBeforeNextSong));
	}
}
