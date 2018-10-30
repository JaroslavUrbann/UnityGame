using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float Speed;
	public float Health;
    public Transform[] Waypoints4;
	public Transform[] Waypoints1;
	public float pathOffset = 0.1f;
	private float speedOffset = 0.2f;
	private int waypointIndex = 0;
	private Vector3[] waypoints;

	void Start () {
		waypoints = new Vector3[Waypoints1.Length];
		waypoints[waypointIndex] = new Vector3(Waypoints1[waypointIndex].transform.position[0] + Random.Range(-pathOffset, pathOffset),
											Waypoints1[waypointIndex].transform.position[1] + Random.Range(-pathOffset, pathOffset),
											Waypoints1[waypointIndex].transform.position[2]);
		Speed = Speed + Random.Range(-speedOffset, speedOffset);
		transform.position = waypoints[waypointIndex];
	}
	
	void Update () {
		FollowWaypoints();
		CheckHealth();
	}

	private void CheckHealth(){
		if(Health <= 0){
			Destroy(gameObject);
		}
	}

	private void FollowWaypoints()
    {
        if (waypointIndex < Waypoints1.Length)
        {
			transform.position = Vector2.MoveTowards(transform.position,
			waypoints[waypointIndex],
			Speed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex])
            {
				waypointIndex++;
				if(waypointIndex < Waypoints1.Length){
					waypoints[waypointIndex] = new Vector3(Waypoints1[waypointIndex].transform.position[0] + Random.Range(-pathOffset, pathOffset),
									Waypoints1[waypointIndex].transform.position[1] + Random.Range(-pathOffset, pathOffset),
									Waypoints1[waypointIndex].transform.position[2]);
				}
            }
        }
		else{
			Destroy(gameObject);
			HealthManager.Health--;
		}
    }
}