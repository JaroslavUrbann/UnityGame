using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

	public Button Continue;

	void Start(){
		if(!File.Exists(Application.dataPath + "/save.txt")){
			Continue.interactable = false;
		}
	}

	public void NewGame(){
		string newGameState = "0,-1,-1,-1";
		File.WriteAllText(Application.dataPath + "/save.txt", newGameState);
		SceneManager.LoadScene("LevelsMenu");
	}

	public void LoadGame(){
		SceneManager.LoadScene("LevelsMenu");
	}
}
