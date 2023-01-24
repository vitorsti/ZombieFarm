using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public Text text;
	public int moneyAmount;


	void Awake(){

		moneyAmount = PlayerPrefs.GetInt ("money");
	}

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		text.text = " : " + moneyAmount;

		if (moneyAmount <= 0)
			moneyAmount = 0;

	}

	public void AddMoney (int amountToAdd){

		moneyAmount += amountToAdd;
	}

	public void RemoveMoney (int amountToRemove){

		moneyAmount -= amountToRemove;
	}
}
