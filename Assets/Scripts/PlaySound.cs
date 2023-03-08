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
    public void JouerSon() {
        SoundManager.Instance._effectSource.PlayOneShot(_sound);
    }
}
