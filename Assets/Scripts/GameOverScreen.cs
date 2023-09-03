using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {
	
	public int nighHighscore;
	public int money;
	public Slider slider;
	public Text sliderValue;
	GameManager game;
	MoneyManager moneyMan;

	void Awake(){

		moneyMan = FindObjectOfType<MoneyManager> ();
		game = FindObjectOfType<GameManager> ();
		slider.value = PlayerPrefs.GetFloat("Sensitivity", 15f);
		sliderValue.text = slider.value.ToString("");
		nighHighscore = PlayerPrefs.GetInt ("highscore");
		money = PlayerPrefs.GetInt ("money");
		PlayerPrefs.SetFloat ("Sensitivity", slider.value);
		sliderValue.text = slider.value.ToString("");
	}

	void Update(){
		
		sliderValue.text = slider.value.ToString("");
	}
		
	public void Menu (){

		if (GameManager.language == 1)
			SceneManager.LoadScene ("Menu");
		else
			SceneManager.LoadScene ("EnglishMenu");

		if (game.waveNumber > nighHighscore)
			PlayerPrefs.SetInt ("highscore", game.waveNumber);

		PlayerPrefs.SetInt ("money", moneyMan.moneyAmount);


	}

	public void Reset (){

		if (GameManager.language == 1)
			SceneManager.LoadScene ("Game");
		else
			SceneManager.LoadScene ("EnglishGame");
	}

	public void SetMouseSentivity(float sensitivity){
		
		PlayerPrefs.SetFloat("Sensitivity", sensitivity);
		PlayerPrefs.Save();

		CameraController.instance.SetSensitivity();
	}

	public void Quit (){

		if (game.waveNumber > nighHighscore)
			PlayerPrefs.SetInt ("highscore", game.waveNumber);

		PlayerPrefs.SetInt ("money", moneyMan.moneyAmount);

		Application.Quit ();
	}
}
