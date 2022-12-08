using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingSystem : MonoBehaviour
{
    /*
    public Waypoint mCurrentTargetWaypoint;
    public float mSpeed = 3f;
    public float mDistanceThreshold = 0.2f;

    void Update()
    {
        // check distance to waypoint compared to threshold
        if (mCurrentTargetWaypoint.GetDistance(transform.position) <= mDistanceThreshold)
        {
            // if close enough, get next waypoint
            mCurrentTargetWaypoint = mCurrentTargetWaypoint.GetNextWaypoint();

        }

        // move towards waypoint
        transform.Translate(
            mCurrentTargetWaypoint.GetDirection() * mSpeed * Time.deltaTime
        );
    }
    */
}

    // Credit https://www.noveltech.dev/patrolling-system/