using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	public float Speed;
	public float Health;
	public Transform[] Waypoints1;
	public Transform[] Waypoints2;
	public Transform[] Waypoints3;
	public Transform[] Waypoints4;
	public float pathOffset = 0.08f;
	private float speedOffset = 0.2f;
	private int waypointIndex = 0;
	private Vector3[] waypoints;
	private Transform[][] allWaypoints;
	private int sceneIndex;

	void Start () {
		sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
		allWaypoints = new Transform[][] {Waypoints1, Waypoints2, Waypoints3, Waypoints4}; 

		waypoints = new Vector3[allWaypoints[sceneIndex].Length];
		waypoints[waypointIndex] = new Vector3(allWaypoints[sceneIndex][waypointIndex].transform.position[0] + Random.Range(-pathOffset, pathOffset),
											allWaypoints[sceneIndex][waypointIndex].transform.position[1] + Random.Range(-pathOffset, pathOffset),
											allWaypoints[sceneIndex][waypointIndex].transform.position[2]);
		Speed = Speed + Random.Range(-speedOffset, speedOffset);
		transform.position = waypoints[waypointIndex];
	}
	
	void Update () {
		FollowWaypoints();
		CheckHealth();
	}

	private void CheckHealth(){
		if(Health <= 0){
			Money.Amount += 5;
			Destroy(gameObject);
		}
	}

	private void FollowWaypoints()
    {
        if (waypointIndex < allWaypoints[sceneIndex].Length)
        {
			transform.position = Vector2.MoveTowards(transform.position,
			waypoints[waypointIndex],
			Speed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex])
            {
				waypointIndex++;
				if(waypointIndex < allWaypoints[sceneIndex].Length){
					waypoints[waypointIndex] = new Vector3(allWaypoints[sceneIndex][waypointIndex].transform.position[0] + Random.Range(-pathOffset, pathOffset),
									allWaypoints[sceneIndex][waypointIndex].transform.position[1] + Random.Range(-pathOffset, pathOffset),
									allWaypoints[sceneIndex][waypointIndex].transform.position[2]);
				}
            }
        }
		else{
			Destroy(gameObject);
			HealthManager.Health--;
		}
    }
}