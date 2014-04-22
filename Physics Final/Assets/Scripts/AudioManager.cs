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
        switch (channel)
        {
            case AudioChannel.Music:
                if (musicChannel.clip == audioClips[id]) { return; }
                musicChannel.clip = audioClips[id];
                break;
            case AudioChannel.SoundEffects:
                if (soundEffectChannel.clip == audioClips[id]) { return; }
                soundEffectChannel.clip = audioClips[id];
                break;
            default:
                break;
        }

		Play(channel);
	}
    public void Play(AudioChannel channel) {
        switch (channel)
        {
            case AudioChannel.Music:
                musicChannel.Play(); 
                break;
            case AudioChannel.SoundEffects:
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
}

public enum AudioChannel
{
    Music,
    SoundEffects
}
