using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropWin : MonoBehaviour
{
    [Header("GAMEOBJECTS")]
    [SerializeField][Tooltip("Gameobject parent qui regroupe les images.")] private GameObject _images;
    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _panneau;
    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _pouceExemple;

    private int _pointsToWin;
    private int _currentPoints;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        // regarde cmb il y a d'enfants dans le go
        // qui comporte les objets.
        _pointsToWin = _images.transform.childCount;
        // Debug.Log("Il y a " + _pointsToWin + " à gagner.")
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        // si les points actuels sont ­>= que
        // les points pour gagner affiche
        // le panneau.
        if (_currentPoints >= _pointsToWin) {
            _panneau.SetActive(true);
        }
    }

    /// <summary>
    /// Permet d'ajouter des points.
    /// </summary>
    public void AddPoints() {
        _currentPoints ++;
        // Debug.Log("Vous avez gagné " + _currentPoints + " point(s).");
    }
}
