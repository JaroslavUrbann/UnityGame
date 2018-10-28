using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	bool isPaused = false;
	public GameObject PauseUI;

	void Start(){
		Resume();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (isPaused){
				Resume();
			}
			else{
				Pause();
			}
		}
	}

	public void LevelsMenu(){
		SceneManager.LoadScene("LevelsMenu");
	}

	public void Resume(){
		PauseUI.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	void Pause(){
		PauseUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}
}
