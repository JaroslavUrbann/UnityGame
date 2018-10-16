using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float Speed;
	public float Health;
	public float Size;
	public float pathOffset = 0.5f;
	private float speedOffset = 0.2f;
	public SpriteRenderer Sprite;
    public Transform[] Waypoints;
	private int waypointIndex = 0;
	private Vector3[] waypoints;

	void Start () {
		waypoints = new Vector3[Waypoints.Length + 1];
		waypoints[waypointIndex] = new Vector3(Waypoints[waypointIndex].transform.position[0] + Random.Range(-pathOffset, pathOffset),
											Waypoints[waypointIndex].transform.position[1] + Random.Range(-pathOffset, pathOffset),
											Waypoints[waypointIndex].transform.position[2]);
		Speed = Speed + Random.Range(-speedOffset, speedOffset);
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
        if (waypointIndex < Waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex],
               Speed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex])
            {
				waypointIndex += 1;
				waypoints[waypointIndex] = new Vector3(Waypoints[waypointIndex].transform.position[0] + Random.Range(-pathOffset, pathOffset),
													Waypoints[waypointIndex].transform.position[1] + Random.Range(-pathOffset, pathOffset),
													Waypoints[waypointIndex].transform.position[2]);
            }
        }
		else{
			Destroy(gameObject);
			Debug.Log("Remove life here");
		}
    }
}