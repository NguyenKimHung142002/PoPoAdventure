using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentIndexWP = 0;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length != 0)
        {
            if (Vector2.Distance(waypoints[currentIndexWP].transform.position, transform.position) < .1f)
            {
                currentIndexWP++;
                if (currentIndexWP >= waypoints.Length)
                {
                    currentIndexWP = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndexWP].transform.position, Time.deltaTime * speed);
        }
    }
}
