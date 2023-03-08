using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopGame : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI _textPoints;
    [SerializeField] private TextMeshProUGUI _textTime;
    [SerializeField] private TextMeshProUGUI _textEssais;

    [SerializeField] private Pop[] _pops;
    [SerializeField] private GameObject[] _lettres;

    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _panneauWin;
    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _panneauDefeat;
    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _panneauDepart;

    [SerializeField][Tooltip("Gameobject parent qui regroupe les images.")] private GameObject _containerLettres;

    // private int _points;
    private int _limiteTemps = 15;
    private int _currentTime;
    public int _pointsToWin;
    public int _currentPoints;

    // private int _points;
    // private int _essais = 3;

    private void Start() {
        // _pointsToWin = _containerLettres.transform.childCount;
        // Debug.Log(_pointsToWin);
    }

    public void Commencer() {
        InvokeRepeating("Timer", 1f, 1f);

        for(int i=0; i<_pops.Length;i++) {
            _pops[i].Activer(true);
        }

        _currentTime = 0;
        _textTime.text = "" +_currentTime;
        // _textEssais.text = "" +_essais;
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
            }
            
            _panneauDefeat.SetActive(true);
        }
    }

    // public void PerdreEssais() {
    //     _essais --;
    //     _textEssais.text = "" + _essais;

    //     if(_essais <= 0) {
    //         CancelInvoke("Timer");

    //         for(int i=0; i<_pops.Length;i++) {
    //             _pops[i].Activer(false);
    //             _lettres[i].SetActive(true);
    //         }
            
    //         _panneauDefeat.SetActive(true);
    //     }
    // }

    // public void AddPoints() {
    //     _currentPoints ++;
    //     Debug.Log(_currentPoints);

    //     if(_currentPoints == _pointsToWin) {
    //         CancelInvoke("Timer");

    //         for(int i=0; i<_pops.Length;i++) {
    //             _pops[i].Activer(false);
    //         }
            
    //         _panneauWin.SetActive(true);
    //     }
    // }
}
