using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelCompletedMenu : MonoBehaviour {

	public GameObject LevelCompletedUI;

	void Start(){
		LevelCompletedUI.SetActive(false);
	}

	void Update () {
		if (Spawner.IsLevelCompleted && GameObject.FindWithTag("Enemy") == null){
			// switch for how many stars he'll get, display them and write it to file, can't do it any better

			LevelCompletedUI.SetActive(true);
			/*
			string[] savedValues = File.ReadAllText(Application.dataPath + "/save.txt").Split(',');
			savedSceneValue = savedValues[SceneManager.GetActiveScene().buildIndex];
			if(savedSceneValue < currentSceneValue){
				savedValues[SceneManager.GetActiveScene().buildIndex] = currentSceneValue;
				File.WriteAllText(Application.dataPath + "/save.txt", string.Join(",", savedValues));
			} */
		}
	}

	public void OkButton(){
		SceneManager.LoadScene("LevelsMenu");
	}
}
