using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField] private GameObject _scrollBar;
    [SerializeField] private AudioClip _swipeSound;
    private float _scrollPos = 0;
    private float []_pos;

    private bool _isMoving = false;

    // Update is called once per frame
    void Update()
    {
        _pos = new float[transform.childCount];
        float distance = 1f/ (_pos.Length - 1f);

        for(int i = 0; i < _pos.Length; i++) {
            _pos[i] = distance * i;
        }

        if (Input.GetMouseButton (0)) {
            _isMoving = true;
            _scrollPos = _scrollBar.GetComponent<Scrollbar>().value;
        } else {

            for (int i = 0; i < _pos.Length; i++) {

                if (_scrollPos < _pos[i] + (distance/2) && _scrollPos > _pos[i] - (distance/2)) {
                    _scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp (_scrollBar.GetComponent<Scrollbar>().value, _pos[i], 0.1f);
                }

            }

        }

        if (_isMoving == true) {
            for (int i = 0; i < _pos.Length; i++) {

                    if (_scrollPos < _pos[i] + (distance/2) && _scrollPos > _pos[i] - (distance/2)) {
                        transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f,1f), 0.1f);

                        for (int a = 0; a < _pos.Length; a++) {
                            if (a!=i) {
                                transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f,0.8f), 0.1f);
                            }
                            
                        }
                    }
            }
        }
        
    }
}
