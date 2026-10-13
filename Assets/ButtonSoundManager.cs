using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] audioclip = new AudioClip[12];
    float volume = 0.5f;
    public TMP_Text volumetextsfx;
    void Awake()
    {
        audiosource = this.GetComponent<AudioSource>();
    }
    public void RandomBranchSound()
    {
        int randomint = Random.Range(0, 12);
        audiosource.PlayOneShot(audioclip[randomint]);
    }
    public void Louder()
    {
        RandomBranchSound();
        if (volume < 1.0f)
        {
            volume += 0.1f;
            audiosource.volume = volume;
            volumetextsfx.text = Mathf.RoundToInt(volume * 100) + "%";
        }
    }
    public void Quieter()
    {
       RandomBranchSound();
        if (volume > 0.01f)
        {
            volume -= 0.1f;
            audiosource.volume = volume;
            volumetextsfx.text = Mathf.RoundToInt(volume * 100) + "%";
        }
    }
}
