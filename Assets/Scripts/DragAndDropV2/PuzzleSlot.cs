using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _victorySound;

    public void Placed() {
        _audioSource.PlayOneShot(_victorySound);
    }
}
