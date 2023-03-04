using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderEffect;
    [SerializeField] private Slider _sliderVoice;

    // Start is called before the first frame update
    void Start() {
        _sliderMusic.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));

        _sliderEffect.onValueChanged.AddListener(val => SoundManager.Instance.ChangeEffectVolume(val));

        _sliderVoice.onValueChanged.AddListener(val => SoundManager.Instance.ChangeVoiceVolume(val));
    }
}
