using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    [Header("CAMERA")]
    [SerializeField][Tooltip("Main camera du projet pour position de la souris.")] private Camera _camera;

    [Header("SCRIPTS")]
    [SerializeField][Tooltip("Script qui détermine les conditions de victoire.")] private DragAndDropWin _winScript;

    [Header("GAMEOBJECTS")]
    [SerializeField][Tooltip("Le container d'une image pour le puzzle.")] private GameObject _imgContainer;
    [SerializeField][Tooltip("L'image qui doit aller dans son container.")] private GameObject _img;

    [Header("AUDIO")]
    [SerializeField][Tooltip("Son quand l'image est sélectionnée.")] private AudioClip _audioSelected;
    [SerializeField][Tooltip("Son quand l'image est sélectionnée n'est pas placée dans son container.")] private AudioClip _audioError;
    [SerializeField][Tooltip("Son quand l'image est sélectionnée est placée dans son container.")] private AudioClip _audioWin;

    // première position
    // du click à l'écran.
    private float _startPosX;
    private float _startPosY;

    // bouge ou pas.
    private bool _moving;
    // fini ou pas.
    private bool _finish;

    // collider du go.
    private Collider2D _imgCollider;

    // position où on veut
    // replacer l'object si echec.
    private Vector3 _resetPosition;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        _resetPosition = this.transform.localPosition;
        // Debug.Log("Position reset au start : " + _resetPosition);
        _imgCollider = GetComponent<Collider2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        // si n'est pas dans la forme noire
        // donc pas finish.
        if(_finish == false) {
            // si l'objet bouge.
            if(_moving) {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = _camera.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - _startPosX, mousePos.y - _startPosY, this.gameObject.transform.localPosition.z);
            }
        }
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    private void OnMouseDown() {        
        // si le button mouse est down
        // enregistre la position de la
        // mouse en x et y.
        // + moving est à true ( donc en déplacement ).
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = _camera.ScreenToWorldPoint(mousePos);

            _startPosX = mousePos.x - this.transform.localPosition.x;
            _startPosY = mousePos.y - this.transform.localPosition.y;

            _moving = true;
            
            SoundManager.Instance._effectSource.PlayOneShot(_audioSelected);
        }
    }

    /// <summary>
    /// OnMouseUp is called when the user has released the mouse button.
    /// </summary>
    void OnMouseUp() {
        // est false quand la mouse
        // est up.
        _moving = false;

        // distance entre la forme et
        // son conteneur.
        float  distance = Vector3.Distance(_img.transform.position, _imgContainer.transform.position);

        // si la distance et moin grande que un
        // place l'objet dans le conteneur
        // (donc la forme noire).
        if (distance < 1) {
            _img.transform.position = _imgContainer.transform.position;
            _img.transform.localScale = _imgContainer.transform.localScale;
            _finish = true;
            // désactive le collider du go
            // pour enlever l'intéraction qui
            // ajoutais des points même si l'objet
            // était dans la forme noire.
            _imgCollider.enabled = !_imgCollider.enabled;
            _winScript.AddPoints();
            SoundManager.Instance._effectSource.PlayOneShot(_audioWin);
            } else {
            // sinon, replace l'objet à sa position
            // de départ.
            this.transform.localPosition = _resetPosition;
            // Debug.Log("Je reset ma position.");
            // Debug.Log("Position reset au reset : " + _resetPosition);
            SoundManager.Instance._effectSource.PlayOneShot(_audioError);
        }   
    }
}
