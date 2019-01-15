using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class LevelCompletedMenu : MonoBehaviour {

	public GameObject LevelCompletedUI;
	private bool update = true;

	void Start(){
		LevelCompletedUI.SetActive(false);
	}

	void Update () {
		if (Spawner.IsLevelCompleted && GameObject.FindWithTag("Enemy") == null && update){
			update = false;
			int levelIndex = SceneManager.GetActiveScene().buildIndex - 1;
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
			int nextSceneValue = 1;
			if(levelIndex < 3)
			{
				nextSceneValue = Int32.Parse(savedValues[levelIndex + 1]);
			}
			if(savedSceneValue < stars){
				savedValues[levelIndex] = stars.ToString();
			}
			if(levelIndex + 1 < 4 && nextSceneValue == -1){
				savedValues[levelIndex + 1] = "0";
			}
			Debug.Log(savedValues);
			File.WriteAllText(Application.dataPath + "/save.txt", string.Join(",", savedValues));
		}
	}

	public void OkButton(){
		SceneManager.LoadScene("LevelsMenu");
	}
}
