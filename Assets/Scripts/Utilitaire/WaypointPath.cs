using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    // tableau waypoints
    [SerializeField] private Transform[] _waypoints;

    // movement speed
    [SerializeField] private float _speed = 2f;

    // index du waypoint actuel
    private int _waypointIndex = 0;


	private void Start () {

        // la position du perso est la même que le premier waypoint
        transform.position = _waypoints[_waypointIndex].transform.position;
	}
	
	private void Update () {
        Move();
	}

    /// <summary>
    /// fait déplacer le perso.
    /// </summary>
    private void Move() {
        // si le perso n'a pas atteint le dernier waypoint
        // il peut bouger. Si il a atteint le dernier waypoint, il ne peut plus
        // bouger.
        if (_waypointIndex <= _waypoints.Length - 1) {

            // le perso bouge au prochain waypoint
            transform.position = Vector2.MoveTowards(transform.position,
               _waypoints[_waypointIndex].transform.position,
               _speed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == _waypoints[_waypointIndex].transform.position)
            {
                _waypointIndex += 1;
            }
        }
    }
}
