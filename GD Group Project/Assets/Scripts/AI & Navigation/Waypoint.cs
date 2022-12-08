using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint mNextWaypoint;

    private Vector3 _mPosition;


    // Start is called before the first frame update
    void Start()
    {
        // caching the Waypoint's position to avoid accessing the transform everytime
        _mPosition = transform.position;
    }

    // convenience method to quickly get distance between waypoint and character
    public float GetDistance(Vector3 characterPosition)
    {
        return Vector3.Distance(_mPosition, characterPosition);
    }

    // get the direction from the character to waypoint to handle character movement
    public Vector3 GetDirection(Vector3 characterPosition)
    {
        Vector3 heading = _mPosition - characterPosition;
        return heading / heading.magnitude;
    }

    public Waypoint GetNextWaypoint()
    {
        return mNextWaypoint;
    }

    public Vector3 GetPosition()
    {
        return _mPosition;
    }
}
// Credit https://www.noveltech.dev/patrolling-system/
