using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Spawner : MonoBehaviour {

	public Enemy Enemy;
	private int waves = 8;
	private int currentWave = 0;
	private float waveRate;
	private float batchRate; // time difference between batch end and another batch start
	private float nextBatchStart;
    private float batchLength;
    private float nextSpawn;
    private float spawnRate;
    private bool round;
    private bool batch;

    public void OnClick()
    {
        round = true;
    }
	
	// Use this for initialization
	void Start () {
        round = false;
        batch = false;
        batchRate = 5f;
        batchLength = 5f;
        spawnRate = 1f;
        nextSpawn = Time.time;
        nextBatchStart = Time.time + batchRate;
	}
	
	// Update is called once per frame
	void Update () {
        BatchManager();
        Batches();
        Enemies();
	}

	void BatchManager()
    {
        // read from file and after each nextbatchstart set batchrate, batchlength, spawnrate...
    }

    void Batches()
    {
        batch = false;
        if (Time.time > nextBatchStart && round)
        {
            if(nextBatchStart + batchLength > Time.time)
            {
                batch = true;
            }
            else
            {
                nextBatchStart = Time.time + batchRate;
            }
        }
    }

    void Enemies()
    {
        if(batch && Time.time > nextSpawn)
        {
            SpawnEnemy(2f, 50f);
            nextSpawn = Time.time + spawnRate;
        }
    }

	void SpawnEnemy(float speed, float health){
		Enemy EnemyInstance = Instantiate (Enemy, transform.position, Quaternion.identity) as Enemy;
		EnemyInstance.Speed = speed;
        EnemyInstance.Health = health;
	}
}
