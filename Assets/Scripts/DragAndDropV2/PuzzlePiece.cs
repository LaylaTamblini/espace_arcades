using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _pickSound;
    [SerializeField] private AudioClip _dropSound;
    [SerializeField] private AudioClip _errorSound;

    private bool _dragging;
    private Vector2 _offset;
    private Vector2 _originalPos;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _originalPos = transform.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(!_dragging) return;

        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {  
        _dragging = true;
        _audioSource.PlayOneShot(_pickSound);
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    /// <summary>
    /// OnMouseUp is called when the user has released the mouse button.
    /// </summary>
    void OnMouseUp()
    {
        _dragging = false;
        _audioSource.PlayOneShot(_errorSound);
        transform.position = _originalPos;
    }

    /// <summary>
    /// Retourne la position
    /// de la souris sur l'écran.
    /// </summary>
    /// <returns></returns>
    Vector2 GetMousePos() {
        return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
