using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private AudioClip _sound;

    /// <summary>
    /// 
    /// </summary>
    public void JouerSonEffet() {
        SoundManager.Instance._effectSource.PlayOneShot(_sound);
    }

    public void JouerSonVoix() {
        SoundManager.Instance._voiceSource.PlayOneShot(_sound);
    }
}
