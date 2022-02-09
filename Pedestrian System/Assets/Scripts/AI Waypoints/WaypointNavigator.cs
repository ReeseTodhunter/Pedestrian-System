using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    PedestrianController controller;
    public Waypoint currentWaypoint;

    void Awake()
    {
        controller = GetComponent<PedestrianController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.reachedDestination)
        {
            bool shouldBranch = false;

            if(currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
            }

            if(shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
            }
            else
            {
                if (controller.direction == 0)
                {
                    if (currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        controller.direction = 1;
                    }
                }
                else if (controller.direction == 1)
                {
                    if (currentWaypoint.previousWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                        controller.direction = 0;
                    }
                }
            }
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
