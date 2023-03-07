using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiverGameObject : MonoBehaviour
{
    [SerializeField] private GameObject _GO;

    public void ActiverGO() {
        _GO.SetActive(true);
    }

    public void DesactiverGO() {
        _GO.SetActive(false);
    }
}
