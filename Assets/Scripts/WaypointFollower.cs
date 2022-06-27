using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //lista de objetos a serem chamados por outro objeto
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f; //velocidade da plataforma

    private void Update()
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
