using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Spawner : MonoBehaviour {

	public Enemy Enemy;
	private int waves = 8;
	private int currentWave = 0;
	private float waveRate;
	private float spawnRate;
	private float nextSpawn;

	
	// Use this for initialization
	void Start () {
		spawnRate = 2f;
		nextSpawn = Time.time + spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn){
			nextSpawn = Time.time + spawnRate;
			SpawnEnemy();
		}
	}

	public void NextWave(){
		
	}

	private void SpawnEnemy(){
		Enemy EnemyInstance = Instantiate (Enemy, transform.position, Quaternion.identity) as Enemy;
		EnemyInstance.Speed = 1;
	}
}
