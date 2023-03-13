using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
	public Slider volumeSlider;

	public AudioSource audioSource;

	public void Start()
	{
		volumeSlider.value = audioSource.volume;
	}

	public void Update()
	{
		volumeSlider.value = audioSource.volume;
	}

	public void lowerVolume()
	{
		audioSource.volume -= 0.1f;
	}

	public void increaseVolume()
	{
		audioSource.volume += 0.1f;
	}
}
