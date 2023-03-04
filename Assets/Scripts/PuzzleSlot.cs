using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _completeSound;

    public SpriteRenderer Renderer;

    public void Placed() {
        SoundManager.Instance._effectSource.PlayOneShot(_completeSound);
    }
}
