using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // singleton
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;
    [SerializeField] private AudioSource _voiceSource;

    /// <summary>
    /// 
    /// </summary>
    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ChangeMasterVolume(float value) {
        AudioListener.volume = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public void ChangeMusicVolume(float value) {
        _musicSource.volume = value;

    }

    /// <summary>
    /// 
    /// </summary>
    public void ChangeEffectVolume(float value) {
        _effectSource.volume = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public void ChangeVoiceVolume(float value) {
        _voiceSource.volume = value;
    }

}
