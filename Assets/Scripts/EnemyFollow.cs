using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

	public float Speed;
    public Transform[] Waypoints;
	private int waypointIndex = 0;

	// Use this for initialization
	void Start () {
		transform.position = Waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		FollowWaypoints();
	}

	private void FollowWaypoints()
    {
        if (waypointIndex <= Waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               Waypoints[waypointIndex].transform.position,
               Speed * Time.deltaTime);
            if (transform.position == Waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}