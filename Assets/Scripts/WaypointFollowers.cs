using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace waypoints
{
    public class WaypointFollowers : MonoBehaviour
    {
        [SerializeField] private GameObject[] waypoints;
        private int currentWaypointIndex = 0;
        private bool earthquakeActive;

        [SerializeField] private float speed = 2f;

        private void Update()
        {
            if(earthquakeActive)
            {
                if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Length)
                    {
                        currentWaypointIndex = 0;
                    }
                }
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            }
        }
    }
}
