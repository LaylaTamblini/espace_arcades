using System.Collections.Generic;
using UnityEngine;

public class PlanetPosition {
    
    public Vector3 _position { get; private set; }
    public Transform _parent { get; private set; }

    //mettre en objet la position d'une planete
    //avec son parent
    // '' objet virtuel ''
    public PlanetPosition(Vector3 pos, Transform par) {
        this._position = pos;
        this._parent = par;
    }

}