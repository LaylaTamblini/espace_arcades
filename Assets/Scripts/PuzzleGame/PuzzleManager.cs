using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private GameObject _slotParent;
    [SerializeField] private GameObject _pieceParent;
    [SerializeField] private GameObject _canvasWin;

    private int _pointsToWin;
    private int _currentPoints;

    private int _randomPos;

    /// <summary>
    /// 
    /// </summary>
    private void Start() {
        // Spawn();
        _pointsToWin = _slotParent.transform.childCount;
    }

    private void Update() {
        if (_currentPoints >= _pointsToWin) {
            _canvasWin.SetActive(true);
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
    private void Spawn() {

        // détermine cmb de slots à prendre dans la liste des slots
        // var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(9).ToList();

        for (int i = 0; i < _slotPrefabs.Count; i++) {
            // instantiate les slots et les pieces
            var spawnedSlot = Instantiate(_slotPrefabs[i], _slotParent.transform.GetChild(i).position, Quaternion.identity);
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.transform.GetChild(i).position, Quaternion.identity);
            
            spawnedPiece.Init(spawnedSlot);
        }
    }
}
