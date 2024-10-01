using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int CurrentWaypointIndex=0;
    [SerializeField] float speed=2f;
    void Update()
    {
        if (Vector2.Distance(waypoints[CurrentWaypointIndex].transform.position, transform.position) < .1f)
        {
            CurrentWaypointIndex++;
            if (CurrentWaypointIndex >= waypoints.Length)
            {
                CurrentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWaypointIndex].transform.position,Time.deltaTime*speed);
    }
}
