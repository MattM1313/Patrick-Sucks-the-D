using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
	public static AudioManager me;

	public AudioSource musicChannel;
	public AudioSource soundEffectChannel;
	public AudioClip[] audioClips;

	void Start () {
		DontDestroyOnLoad(this);

		musicChannel.loop = true;
		soundEffectChannel.loop = false;
		me = this;
	}
	
	public void PlayClip(int id, AudioChannel channel)
	{
		SetClip(id, channel);
		Play(channel);
	}
	public void Play(AudioChannel channel) {
		switch (channel)
		{
			case AudioChannel.Music:
				if (musicChannel.clip == null) return;

				musicChannel.Play(); 
				break;
			case AudioChannel.SoundEffects:
				if (soundEffectChannel.clip == null) return;

				soundEffectChannel.Play(); 
				break;
			default:
				break;
		}
	}
	public void Pause(AudioChannel channel) {
		switch (channel)
		{
			case AudioChannel.Music:
				musicChannel.Pause(); 
				break;
			case AudioChannel.SoundEffects:
				soundEffectChannel.Pause();
				break;
			default:
				break;
		}
	}
	public void Stop(AudioChannel channel) {
		switch (channel)
		{
			case AudioChannel.Music:
				musicChannel.Stop(); 
				break;
			case AudioChannel.SoundEffects:
				soundEffectChannel.Stop(); 
				break;
			default:
				break;
		}
	}

	public void ToggleLoop(AudioChannel channel)
	{
		switch (channel)
		{
			case AudioChannel.Music:
				musicChannel.loop = !musicChannel.loop;
				break;
			case AudioChannel.SoundEffects:
				soundEffectChannel.loop = !musicChannel.loop;
				break;
			default:
				break;
		}
	}
	public bool IsClipCurrentlySet(int id, AudioChannel channel)
	{
		switch (channel)
		{
			case AudioChannel.Music:
				if (musicChannel.clip == audioClips[id]) { return true; }
				break;
			case AudioChannel.SoundEffects:
				if (soundEffectChannel.clip == audioClips[id]) { return true; }
				break;
			default:
				break;
		}
		return false;
	}
	public void SetClip(int id, AudioChannel channel)
	{
		if (IsClipCurrentlySet(id, channel)) return;

		switch (channel)
		{
			case AudioChannel.Music:
				musicChannel.clip = audioClips[id];
				break;
			case AudioChannel.SoundEffects:
				soundEffectChannel.clip = audioClips[id];
				break;
			default:
				break;
		}
	}
}

public enum AudioChannel
{
	Music,
	SoundEffects
}
