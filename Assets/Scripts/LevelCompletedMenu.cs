using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class LevelCompletedMenu : MonoBehaviour {

	public GameObject LevelCompletedUI;

	void Start(){
		LevelCompletedUI.SetActive(false);
	}

	void Update () {
		if (Spawner.IsLevelCompleted && GameObject.FindWithTag("Enemy") == null){
			// switch for how many stars he'll get, display them and write it to file, can't do it any better
			int levelIndex = SceneManager.GetActiveScene().buildIndex;
			int stars = 3;

			if(HealthManager.Health  < 3){
				stars = 1;
			}
			else if(HealthManager.Health < 5){
				stars = 2;
			}

			LevelCompletedUI.SetActive(true);

			string[] savedValues = File.ReadAllText(Application.dataPath + "/save.txt").Split(',');
			int savedSceneValue = Int32.Parse(savedValues[levelIndex]);
			int nextSceneValue = Int32.Parse(savedValues[levelIndex + 1]);
			if(savedSceneValue < stars){
				savedValues[levelIndex] = stars.ToString();
			}
			if(levelIndex + 1 < 4 && nextSceneValue == -1){
				savedValues[levelIndex + 1] = "0";
			}
			File.WriteAllText(Application.dataPath + "/save.txt", string.Join(",", savedValues));
		}
	}

	public void OkButton(){
		SceneManager.LoadScene("LevelsMenu");
	}
}
