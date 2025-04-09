using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    private void Start()
    {
        musicSlider.value = AudioManage.Instance.musicSource.volume;
        sfxSlider.value = AudioManage.Instance.sfxSource.volume;
    }
    public void MusicVolume()
    {
        AudioManage.Instance.MusicVolume(musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManage.Instance.SFXVolume(sfxSlider.value);
    }
}
