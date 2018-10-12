using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

	public float speed;
	public float personalSpace;
    public Transform[] waypoints;
	private int waypointIndex = 0;

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		FollowWaypoints();
		if(Vector2.Distance(transform.position, target.position) > personalSpace && waypointIndex > waypoints.Length - 1){
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}

	private void FollowWaypoints()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               speed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}