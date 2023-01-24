using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour {

	public int loadScene;
	public float time;

	void Awake(){

		time = 2f;

		loadScene = PlayerPrefs.GetInt ("language");

	}

	void Update(){

		time -= Time.deltaTime;

		if (time <= 0) {

			if (loadScene == 1)
				SceneManager.LoadScene ("Menu");
			else
				SceneManager.LoadScene ("EnglishMenu");
		}
	}

}
