using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [Header("PUZZLE FIELD")]
    [SerializeField] private Transform _puzzleField;

    [Header("GAMEOBJECTS")]
    [SerializeField] private GameObject _btn;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {        
        // fait une copie du GameObject
        // et le met dans la variable button.
        for (int i = 0; i < 8; i++) {
            GameObject button = Instantiate(_btn);
            // nomme le go en fonction
            // de quand il apparait dans la scène.
            button.name = "" + i;
            // Set le parent du go button.
            button.transform.SetParent(_puzzleField, false);
        }
    }
}
