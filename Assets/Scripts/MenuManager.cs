using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Text highscoreMoneyText;
	public int highsocre, money;
	public Canvas canvasMenu, canvasTutorial, canvasOptions, canvasCredits;
	public int language;
	public Toggle subtitleToggle;
	public int subtitle;
	public AudioMixer audioMixer;
	private KeyCode[] cheatcode;
	private int index;
	private bool i;
	private string field;
	public GameObject inputField;

	void Awake(){

		inputField.SetActive (false);
		Time.timeScale = 1;
		i = false;
		language = PlayerPrefs.GetInt ("language");
		canvasMenu.enabled = true;
		canvasTutorial.enabled = false;
		canvasOptions.enabled = false;
		canvasCredits.enabled = false;
		subtitle = PlayerPrefs.GetInt ("Subtitle");
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		if (subtitle == 1)
			subtitleToggle.isOn = true;

		if(subtitle == 0)
			subtitleToggle.isOn = false;

		highsocre = PlayerPrefs.GetInt ("highscore");
		money = PlayerPrefs.GetInt ("money");

		if(language == 1)
			highscoreMoneyText.text = "Noites sobrevividas:  " +"<color=red>"+ highsocre +"</color>"+ "  Dinheiro:  " +"<color=red>"+ money +"</color>";
		else
			highscoreMoneyText.text = "Nights survived:  " +"<color=red>"+ highsocre +"</color>"+ "  Money:  " +"<color=red>"+ money +"</color>";

		cheatcode = new KeyCode[] { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, 
			KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A};
		index = 0;

	}

	void Update(){

		subtitle = PlayerPrefs.GetInt ("Subtitle");

		highsocre = PlayerPrefs.GetInt ("highscore");
		money = PlayerPrefs.GetInt ("money");

		if(language == 1)
			highscoreMoneyText.text = "Noites sobrevividas:  " +"<color=red>"+ highsocre +"</color>"+ "  Dinheiro:  " +"<color=red>"+ money +"</color>";
		else
			highscoreMoneyText.text = "Nights survived:  " +"<color=red>"+ highsocre +"</color>"+ "  Money:  " +"<color=red>"+ money +"</color>";

		if (Input.anyKeyDown) {

			if (Input.GetKeyDown (cheatcode[index])) {
				index++;
			} else {
				index = 0;
			}
		}

		if (index == cheatcode.Length) {

			i = true;
			index = 0;
		}

		if (i)
			inputField.SetActive (true);

	}
		

	public void StartGame (){

		if (language == 1)
			SceneManager.LoadScene ("Game");
		else
			SceneManager.LoadScene ("EnglishGame");
	}
		
	public void Teste (){

		if (language == 1)
			SceneManager.LoadScene ("Teste");
		else
			SceneManager.LoadScene ("EnglishTeste");
	}

	public void ResetMoney(){
		
		PlayerPrefs.SetInt ("money", 0);
	}

	public void ResetHighscore(){
		
		PlayerPrefs.SetInt ("highscore", 0);
	}
		
	public void SetVolume (float volume){

		audioMixer.SetFloat ("volume", volume);
		//print (volume);
	}

	public void Subtitle (bool subtitle){

		if (subtitle)
			PlayerPrefs.SetInt ("Subtitle", 1);
		
		if(!subtitle)
			PlayerPrefs.SetInt ("Subtitle", 0);
	}

	public void Portugues(){
		
		PlayerPrefs.SetInt ("language", 1);
		SceneManager.LoadScene ("Menu");
		//print (PlayerPrefs.GetInt ("language"));
	}

	public void English(){

		PlayerPrefs.SetInt ("language", 0);
		SceneManager.LoadScene ("EnglishMenu");
		//print (PlayerPrefs.GetInt ("language"));

	}

	public void InputField(string field){

		this.field = field;
	}

	public void buttonField(){

		int actualMoney = PlayerPrefs.GetInt ("money");
		int moneyToAdd = int.Parse (field);
		int updateMoney = actualMoney + moneyToAdd;
		PlayerPrefs.SetInt ("money", updateMoney);

	}
		
	public void Quit (){
		
		Application.Quit ();
	}
}
