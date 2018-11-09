using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public GameObject LevelFailedUI;
	public Text HealthText;
	public static int Health;

	void Start(){
		Health = 5;
		LevelFailedUI.SetActive(false);
	}

	void Update(){
		HealthText.text = Health + " ♥";
		if(Health <= 0){
			LevelFailedUI.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	public void OkButton(){
		SceneManager.LoadScene("LevelsMenu");
	}

	public void RetryButton(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}