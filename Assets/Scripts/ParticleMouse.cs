using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMouse : MonoBehaviour
{
    [Header("GAMEOBJECT")]
    [SerializeField] private GameObject _particles;
    
    private Vector2 _mousePos;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        _particles.SetActive(false);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _particles.SetActive(true);
            _particles.transform.position = new Vector3(_mousePos.x, _mousePos.y, 0f);
        }

        if (Input.GetMouseButtonUp(0)) {
            Invoke("SetActiveFalse",1.5f);
        }
    }

    private void SetActiveFalse(){
            _particles.SetActive(false);
    }
}
