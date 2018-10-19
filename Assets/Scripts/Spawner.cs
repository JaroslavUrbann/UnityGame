using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.IO;

public class Spawner : MonoBehaviour {

	public Enemy Enemy;

	private float wavesLeft;
    private float batchesLeft;

	private float waveRate;
	private float batchRate; // time difference between batch end and another batch start
	private float nextBatchStart;
    private float batchLength;
    private float nextSpawn;
    private float spawnRate;

    private float enemySpeed;
    private float enemyHealth;
    private float enemySize;
    private float enemySprite;

    private bool roundStarted;
    private bool spawnEnemies;

    private StreamReader csvReader;
    private Queue<float[]> wavesList;

    public void OnClick()
    {
        roundStarted = true;
        nextBatchStart = Time.time;
    }

    void loadWaves(){
        string csvPath = System.IO.Path.GetFullPath("WaveDatabase.csv");
        csvReader = new StreamReader(csvPath);
        wavesList = new Queue<float[]>();
        wavesLeft = System.Array.ConvertAll<string, float>(csvReader.ReadLine().Split(','), float.Parse)[0];
        wavesLeft--;
        batchesLeft = System.Array.ConvertAll<string, float>(csvReader.ReadLine().Split(','), float.Parse)[0];;
        while(!csvReader.EndOfStream){
            float[] Line = System.Array.ConvertAll<string, float>(csvReader.ReadLine().Split(','), float.Parse);
            wavesList.Enqueue(Line);
        }
    }
	
	// Use this for initialization
	void Start () {
        loadWaves();
        roundStarted = false;
        spawnEnemies = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(roundStarted){
            ReadWaves();
        }
        if(roundStarted){
            Batches();
            Enemies();
        }
	}

	void ReadWaves()
    {
        if(!spawnEnemies && Time.time > nextBatchStart){
            if(batchesLeft == 0){
                Debug.Log("the wave ended");
                if(wavesLeft == 0){
                    Debug.Log("dude it all ended");
                    roundStarted = false;
                    return;
                }
                batchesLeft = wavesList.Dequeue()[0];
                wavesLeft--;
            }
            Debug.Log("The batch started");
            float[] batchInfo = wavesList.Dequeue();
            batchLength = batchInfo[0];
            batchRate = batchInfo[1];
            spawnRate = batchLength / batchInfo[2];
            enemySpeed = batchInfo[3];
            enemyHealth = batchInfo[4];
            batchesLeft--;
        }        
    }

    void Batches()
    {
        spawnEnemies = false;
        if (Time.time > nextBatchStart)
        {
            if(Time.time < nextBatchStart + batchLength)
            {
                spawnEnemies = true;
            }
            else
            {
                nextBatchStart = Time.time + batchRate;
            }
        }
    }

    void Enemies()
    {
        if(spawnEnemies && Time.time > nextSpawn)
        {
            SpawnEnemy();
            nextSpawn = Time.time + spawnRate;
        }
    }

	void SpawnEnemy(){
		Enemy EnemyInstance = Instantiate (Enemy, transform.position, Quaternion.identity) as Enemy;
		EnemyInstance.Speed = enemySpeed;
        EnemyInstance.Health = enemyHealth;
	}
}
