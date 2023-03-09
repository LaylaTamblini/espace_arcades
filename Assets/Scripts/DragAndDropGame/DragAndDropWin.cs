using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropWin : MonoBehaviour
{
    [Header("GAMEOBJECT")]
    [SerializeField][Tooltip("")] private GameObject _images;
    [SerializeField][Tooltip("")] private GameObject _panneau;
    [SerializeField][Tooltip("")] private GameObject _animation1;
    [SerializeField][Tooltip("")] private GameObject _animation2;
    [SerializeField][Tooltip("")] private GameObject _btn1;
    [SerializeField][Tooltip("")] private GameObject _btn2;
    [SerializeField][Tooltip("")] private GameObject _panel;

    [Header("LIST")]
    [SerializeField][Tooltip("")] private List<Transform> _positions;
    [SerializeField][Tooltip("")] private List<GameObject> _planetes;

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
        StartCoroutine(PremierTutoriel());
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        // si les points actuels sont ­>= que
        // les points pour gagner affiche
        // le panneau.
        if (_currentPoints >= _pointsToWin) {
            _panel.SetActive(false);
            _btn1.SetActive(false);
            _btn2.SetActive(false);
        }
    }

    /// <summary>
    /// Permet d'ajouter des points.
    /// </summary>
    public void AddPoints() {
        _currentPoints ++;
        // Debug.Log("Vous avez gagné " + _currentPoints + " point(s).");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator PremierTutoriel(){
         _animation1.SetActive(true);
         yield return new WaitForSeconds(3f);
         _animation1.SetActive(false);
         StartCoroutine(DeuxiemeTutoriel());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeuxiemeTutoriel(){
         _animation2.SetActive(true);
         yield return new WaitForSeconds(1f);
         _animation2.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    private void RandomList(){
        List<PlanetPosition> planetPositions = new List<PlanetPosition>();

        for (int i = 0; i < _positions.Count; i++) {
            // création des PlanetPosition selon la classe PlanetPosition
            planetPositions.Add(new PlanetPosition(_positions[i].position, _positions[i].parent));
        }

        for (int i = 0; i < _planetes.Count; i++) {
            // ça prend une position random dans la liste des positions de planete
            int randomIndex = Random.Range(0, planetPositions.Count);
            // assigne la position
            _planetes[i].transform.position = planetPositions[randomIndex]._position;
            // assigne le nouveau parent selon sa position
            _planetes[i].transform.SetParent(planetPositions[randomIndex]._parent);
            // enleve la position pour éviter les doublons
            planetPositions.Remove(planetPositions[randomIndex]);
            // Vector3 temp = vector3pos[i];
            // int randomIndex = Random.Range(i, vector3pos.Count);
            // vector3pos[i] = vector3pos[randomIndex];
            // vector3pos[randomIndex] = temp;
            
            // if (i <= 3){
            //     _planetes[i].transform.SetParent(_panel01.transform);
            // }

            // if (i >= 4){
            //     _planetes[i].transform.SetParent(_panel02.transform);
            // }
        }

        // for (int i = 0; i < _planetes.Count; i++) {
        //     _planetes[i].transform.position = vector3pos[i];
        //     Debug.Log(_planetes[i].transform.position);
        // }
    }
}
