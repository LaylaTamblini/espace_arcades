using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropWin : MonoBehaviour
{
    [Header("GAMEOBJECTS")]
    [SerializeField][Tooltip("Gameobject parent qui regroupe les images.")] private GameObject _images;
    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _panneau;

    [SerializeField] private List<Transform> _positions;
    [SerializeField] private List<GameObject> _planetes;

    [SerializeField] private GameObject _panel01;
    [SerializeField] private GameObject _panel02;

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
        RandomList();
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

    private void RandomList(){
        List<Vector3> vector3pos = new List<Vector3>();

        for (int i = 0; i < _positions.Count; i++) {
            vector3pos.Add(_positions[i].position);
        }

        for (int i = 0; i < vector3pos.Count; i++) {
            Vector3 temp = vector3pos[i];
            int randomIndex = Random.Range(i, vector3pos.Count);
            vector3pos[i] = vector3pos[randomIndex];
            vector3pos[randomIndex] = temp;
            
            if (i <= 3){
                _planetes[i].transform.SetParent(_panel01.transform);
            }

            if (i >= 4){
                _planetes[i].transform.SetParent(_panel02.transform);
            }
        }

        for (int i = 0; i < _planetes.Count; i++) {
            _planetes[i].transform.position = vector3pos[i];

            Debug.Log(_planetes[i].transform.position);


        }
    }
}
