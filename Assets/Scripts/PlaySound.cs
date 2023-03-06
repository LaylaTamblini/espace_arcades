using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;

    public void JouerSon() {
        SoundManager.Instance._effectSource.PlayOneShot(_sound);
    }
}
