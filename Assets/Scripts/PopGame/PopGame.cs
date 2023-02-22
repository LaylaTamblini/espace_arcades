using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopGame : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI _textPoints;
    [SerializeField] private TextMeshProUGUI _textTime;

    [SerializeField] private Pop[] _pops;

    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _panneauWin;
    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _panneauDepart;

    // private int _points;
    private int _limiteTemps = 10;
    private int _currentTime;

    public void Commencer() {
        InvokeRepeating("Timer", 1f, 1f);

        for(int i=0; i<_pops.Length;i++) {
            // Debug.Log("Activer les pops");
            _pops[i].Activer(true);
        }

        // _points = 0;
        _currentTime = 0;
        // _textPoints.text = "" + _points;
        _textTime.text = "" +_currentTime;
        _panneauDepart.SetActive(false);
    }

    /// <summary>
    /// Permet d'augmenter le temps
    /// </summary>
    private void Timer() {
        _currentTime ++;
        _textTime.text = "" +_currentTime;

        if(_currentTime == _limiteTemps) {
            CancelInvoke("Timer");

            for(int i=0; i<_pops.Length;i++) {
                _pops[i].Activer(false);
                // Debug.Log("Désactiver les pops");
            }

            _panneauWin.SetActive(true);
            Debug.Log("Active le panneau de victoire");
        }
    }

    // /// <summary>
    // /// Permet d'ajouter des points
    // /// quand la fonction est appelée.
    // /// </summary>
    // public void AddPoints()
    // {
    //     _points++;
    //     _textPoints.text = "" + _points;
    // }
}
