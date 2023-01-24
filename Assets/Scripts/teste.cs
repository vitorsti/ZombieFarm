using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teste : MonoBehaviour {

	public Rigidbody cannonBall;
	public Transform firepoint;
	int language;
	public float speed;
	public bool andar;
	public bool esquerda;
	public bool direita;

	private Dictionary <string, Action> keywordsActions = new Dictionary<string, Action> ();
	private KeywordRecognizer keywordReconizer;

	// Use this for initialization
	void Start () {
		
		language = PlayerPrefs.GetInt ("language");
		speed = 2.2f;

		if (language == 1) {
			
			keywordsActions.Add ("esquerda", Left);
			keywordsActions.Add ("direita", Right);
			keywordsActions.Add ("menu", Menu);
			keywordsActions.Add ("sair", Quit);
		}

		if (language == 0) {
			
			keywordsActions.Add ("left", Left);
			keywordsActions.Add ("right", Right);
			keywordsActions.Add ("menu", Menu);
			keywordsActions.Add ("quit", Quit);
			keywordsActions.Add ("exit", Quit);
		}
			
		keywordReconizer = new KeywordRecognizer (keywordsActions.Keys.ToArray ());
		keywordReconizer.OnPhraseRecognized += KeywordReconizer_OnPhraseRecognized;
		keywordReconizer.Start ();
		
	}

	void KeywordReconizer_OnPhraseRecognized (PhraseRecognizedEventArgs args){

		Debug.Log ("Keyword: " + args.text);
		keywordsActions [args.text].Invoke ();
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void Left(){

		transform.Translate (Vector3.left * speed, Space.Self);  
		print ("Turning Left");
	}

	void Right(){

		transform.Translate (Vector3.right * speed, Space.Self);  
		print ("Turning Right");
	}
		

	void Andar(){

		andar = true;
	}

	void Parar (){

		andar = false;
		esquerda = false;
	}

	void Menu(){

		if(language == 1)
			SceneManager.LoadScene ("Menu");
		else
			SceneManager.LoadScene ("EnglishMenu");
	}

	void Quit(){

		Application.Quit ();
	}
}
