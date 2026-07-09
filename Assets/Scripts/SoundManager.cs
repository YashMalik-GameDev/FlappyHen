using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip shameSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioSource backgroundMusic;
    private float jumpVolume = 0.2f;
    private float scoreVolume = 1.2f;
    private float crashVolume = 1f;
    private float hitVolume = 0.8f;
    private float shameVolume = 0.8f;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayScoreSound()
    {
        audioSource.PlayOneShot(scoreSound,scoreVolume);
    }

    public void PlayCrashSound()
    {
        audioSource.PlayOneShot(crashSound,crashVolume);
    }

    public void PlayShameSound()
    {
        audioSource.PlayOneShot(shameSound,shameVolume);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound,jumpVolume);
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound,hitVolume);
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }
}
