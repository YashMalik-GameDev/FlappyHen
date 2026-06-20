using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip shameSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioSource backgroundMusic;
    private float jumpVolume = 0.1f;
    private float scoreVolume = 2f;
    private float crashVolume = 1.5f;

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
        audioSource.PlayOneShot(shameSound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound,jumpVolume);
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }
}
