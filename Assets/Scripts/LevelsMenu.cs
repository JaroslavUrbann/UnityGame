﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System;

public class LevelsMenu : MonoBehaviour {

	public Image[] Levels;
	public Sprite[] LevelSprites;
	public Sprite[] StarSprites;

	void Start(){
        // works but sprite != image
        string[] savedValues = File.ReadAllText(Application.dataPath + "/save.txt").Split(',');
        for (int i = 0; i < 4; i++)
        {
            int savedValue = Int32.Parse(savedValues[i]);
            if (savedValue == 0)
            {
                Levels[i].GetComponent<Image>().sprite = LevelSprites[i];
            }
            else
            {
                Debug.Log(savedValue + 1);
                Levels[i].GetComponent<Image>().sprite = StarSprites[savedValue + 1];
            }
        }
    }

	public void LoadScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}

}
