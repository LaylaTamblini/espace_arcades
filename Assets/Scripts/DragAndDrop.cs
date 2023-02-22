using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject _imgContainer;

    [SerializeField]
    private GameObject _img;

    [SerializeField]
    private Camera _camera;
    
    [SerializeField]
    private DragAndDropWin _winScript;

    // première position
    // du click à l'écran
    private float _startPosX;
    private float _startPosY;

    // bouge ou pas
    private bool _moving;
    // fini ou pas
    private bool _finish;

    // collider du go
    private Collider2D _imgCollider;

    // position où on veut 
    // replacer l'object si echec
    private Vector3 _resetPosition;

    // Start is called before the first frame update
    void Start() {
        _resetPosition = this.transform.localPosition;
        Debug.Log("Position reset au start : " + _resetPosition);
        _imgCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update() {
        // si n'est pas dans la forme noire
        // donc pas finish
        if(_finish == false) {
            // si l'objet bouge
            if(_moving) {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = _camera.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - _startPosX, mousePos.y - _startPosY, this.gameObject.transform.localPosition.z);
            }
        }
    }

    // marche pour pc/mobile
    private void OnMouseDown() {
        // si le button mouse est down
        // enregistre la position de la
        // mouse en x et y
        // + moving est à true ( donc en déplacement )
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = _camera.ScreenToWorldPoint(mousePos);

            _startPosX = mousePos.x - this.transform.localPosition.x;
            _startPosY = mousePos.y - this.transform.localPosition.y;

            _moving = true;

            ////////////////////////////////////////////////////
            // JOUER UN SON ON CLICK
        }
        
    }

    private void OnMouseUp() {
        // est false quand la mouse
        // est up
        _moving = false;

        // distance entre la forme et
        // son conteneur
        float  distance = Vector3.Distance(_img.transform.position, _imgContainer.transform.position);

        // si la distance et moin grande que un
        // place l'objet dans le conteneur
        // (donc la forme noire)
        if (distance < 1) {
            _img.transform.position = _imgContainer.transform.position;
            _finish = true;
            // désactive le collider du go
            // pour enlever l'intéraction qui
            // ajoutais des points même si l'objet
            // était dans la forme noire
            _imgCollider.enabled = !_imgCollider.enabled;
            _winScript.AddPoints();
            //////////////////////////////////////////
            // JOUER UN SON QUAND OBJET DANS CONTAINER
         } else {
            // sinon, replace l'objet à sa position
            // de départ
            this.transform.localPosition = _resetPosition;
            Debug.Log("Je reset ma position.");
            Debug.Log("Position reset au reset : " + _resetPosition);
            ////////////////////////////////////////////////////
            // JOUER UN SON QUAND OBJET RESET DONC PAS CONTAINER
         }
    }
}
