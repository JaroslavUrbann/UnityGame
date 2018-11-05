using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System;

public class LevelsMenu : MonoBehaviour {

	public Button[] Levels;
	public Image[] LevelSprites;
	public Image[] StarSprites;

	void Start(){
		// works but sprite != image
/* 		string[] savedValues = File.ReadAllText(Application.dataPath + "/save.txt").Split(',');
		for(int i = 0; i< 4; i++){
			int savedValue = Int32.Parse(savedValues[i]);
			if(savedValue == 0){
				Levels[i].image = LevelSprites[i];
			}
			else{
				Levels[i].image = StarSprites[savedValue + 1];
			}
		} */
	}

	public void LoadScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}

}
