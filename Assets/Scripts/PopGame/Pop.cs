using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    [Header("SCRIPTS")]
    [SerializeField] private PopGame _popGameScript;

    [Header("AUDIO")]
    [SerializeField][Tooltip("Son d'explosion quand on touche le pop.")] private AudioClip _audioExplosion;


    private float _vitesse;
    private float _limiteX = 8f;
    private float _limiteY = 6f;

    // private AudioSource _audio;
    // private Animator _anim;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // _anim = GetComponent<Animator>();
        // _audio = GetComponent<AudioSource>();
        Recycler();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.up * _vitesse * Time.deltaTime, Space.World);
        if(transform.position.y > _limiteY) {
             Recycler();
        }
    }

    /// <summary>
    /// Active ou desactive le gameobject
    /// selon la valeur bool.
    /// </summary>
    /// <param name="valeur"></param>
    public void Activer(bool valeur) {
        gameObject.SetActive(valeur);
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown() {
        Recycler();
        // _anim.SetTrigger("boum");
        SoundManager.Instance._effectSource.PlayOneShot(_audioExplosion);
        // _popGameScript.AddPoints();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Recycler() {
        // Debug.Log("Est recyclé");
        float posX = Random.Range(-_limiteX, _limiteX);
        float size = Random.Range(0.5f, 2.5f);

        _vitesse = Random.Range(1f,10f);
        transform.localScale =  new Vector3(size, size, size);
        transform.position = new Vector3(posX,-7f,0);
    }
}
