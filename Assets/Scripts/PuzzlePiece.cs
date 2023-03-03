using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _pickupSound;
    [SerializeField] private AudioClip _dropSound;

    [SerializeField] private SpriteRenderer _renderer;

    private bool _dragging;
    private bool _placed;

    private Vector2 _offset;
    private Vector2 _originalPos;

    private PuzzleSlot _slot;

    public void Init(PuzzleSlot slot) {
        _renderer.sprite =  slot.Renderer.sprite;
        _slot = slot;
    }

    private void Awake() {
        _originalPos = transform.position;
    }

    private void Update() {
        if(_placed) return;
        if(!_dragging) return;
        var mousePosition = GetMousePos();
        // snap de la souris sur le go
        transform.position = mousePosition - _offset;
    }

    /// <summary>
    /// Pendant le click de la souris.
    /// </summary>
    private void OnMouseDown() {
        _dragging = true;
        _audioSource.PlayOneShot(_pickupSound);
        // snap de la souris sur le go
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    /// <summary>
    /// Après le click de la souris.
    /// </summary>
    private void OnMouseUp() {
        // si la position du piece et du slot est plus grande que 3
        // sinon retourne à sa position original
        if (Vector2.Distance(transform.position, _slot.transform.position) < 3)  {
            transform.position = _slot.transform.position;
            _slot.Placed();
            _placed = true;
        } else {
            _dragging = false;
            _audioSource.PlayOneShot(_dropSound);
            transform.position = _originalPos;
        }
    }

    /// <summary>
    /// Retourne la position de la souris à l'écran.
    /// </summary>
    /// <returns></returns>
    private Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
