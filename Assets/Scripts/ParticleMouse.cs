using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMouse : MonoBehaviour
{
    [SerializeField] private GameObject _particles;
    [SerializeField] private AudioClip _audioClip;
    private Vector2 _mousePos;


    // Start is called before the first frame update
    void Start()
    {
        _particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _particles.SetActive(true);
            _particles.transform.position = new Vector3(_mousePos.x, _mousePos.y, 0f);
        }

        if (Input.GetMouseButtonUp(0)) {
            _particles.SetActive(false);
            SoundManager.Instance._effectSource.PlayOneShot(_audioClip);
        }
    }
}
