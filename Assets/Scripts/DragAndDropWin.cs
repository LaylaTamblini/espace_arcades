using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropWin : MonoBehaviour
{
    private int _pointsToWin;
    private int _currentPoints;
    public GameObject _lesFormes;
    public GameObject _panneau;

    // Start is called before the first frame update
    void Start()
    {
        _pointsToWin = _lesFormes.transform.childCount;
        Debug.Log("Il y a " + _pointsToWin + " à gagner.");
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPoints >= _pointsToWin) {
            _panneau.SetActive(true);
        }
        
    }

    public void AddPoints() {
        _currentPoints ++;
        Debug.Log("Vous avez gagné " + _currentPoints + " point(s).");
    }
}
