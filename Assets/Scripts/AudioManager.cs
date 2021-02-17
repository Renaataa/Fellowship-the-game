using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
	public AudioClip clip;
	public static AudioManager Instance = null;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(this.gameObject);
		DontDestroyOnLoad(gameObject);
		source.clip = clip;
		source.Play();
	}
}
