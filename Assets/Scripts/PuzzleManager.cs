using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform _slotParent;
    [SerializeField] private Transform _pieceParent;

    /// <summary>
    /// 
    /// </summary>
    private void Start() {
        Spawn();
    }

    /// <summary>
    ///
    /// </summary>
    private void Spawn() {

        // détermine cmb de slots à prendre dans la liste des slots
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(3).ToList();

        for (int i = 0; i < randomSet.Count; i++) {
            // instantiate les slots et les pieces
            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);

            spawnedPiece.Init(spawnedSlot);
        }
    }
}
