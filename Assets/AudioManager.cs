using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioclip = new AudioClip[7];
    public AudioSource audiosource;
    public AudioSource treecutAudiosource;
    public TMP_Text volumetext;
    public TMP_Text volumetreecuttext;
    public ButtonSoundManager buttonsound;
    float volume = 0.5f;
    float volumetreecut = 0.5f;
    int currentNoteIndex = 0;
    void Awake()
    {
        PlayNextSong(currentNoteIndex);
    }
    void Update()
    {
        if (!audiosource.isPlaying)
        {
            currentNoteIndex = (currentNoteIndex + 1);
            if(currentNoteIndex == 7)
            {
                currentNoteIndex = 0;
            }
            PlayNextSong(currentNoteIndex);
        }
    }
    void PlayNextSong(int currentNoteIndex)
    {
        AudioSource[] audiosources = FindObjectsOfType<AudioSource>();
        foreach(AudioSource audio in audiosources)
        {
            audio.Stop();
        }
        if (currentNoteIndex >= 0 && currentNoteIndex < audioclip.Length)
        {
            audiosource.PlayOneShot(audioclip[currentNoteIndex]);
        }

    }
    public void Louder()
    {
        buttonsound.RandomBranchSound();
        if (volume < 1.0f)
        {
            volume += 0.1f;
            audiosource.volume = volume;
            volumetext.text = Mathf.RoundToInt(volume * 100) + "%";
        }
    }
    public void Quieter()
    {
        buttonsound.RandomBranchSound();
        if (volume > 0.01f)
        {
            volume -= 0.1f;
            audiosource.volume = volume;
            volumetext.text = Mathf.RoundToInt(volume * 100) + "%";
        }
    }
    public void Loudertreecut()
    {
        buttonsound.RandomBranchSound();
        if (volumetreecut < 1.0f)
        {
            volumetreecut += 0.1f;
            treecutAudiosource.volume = volumetreecut;
            volumetreecuttext.text = Mathf.RoundToInt(volumetreecut * 100) + "%";
        }
    }
    public void Quietertreecut()
    {
        buttonsound.RandomBranchSound();
        if (volumetreecut > 0.1f)
        {
            volumetreecut -= 0.1f;
            treecutAudiosource.volume = volumetreecut;
            volumetreecuttext.text = Mathf.RoundToInt(volumetreecut * 100) + "%";
        }
    }
}
