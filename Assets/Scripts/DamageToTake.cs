using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageToTake : MonoBehaviour {

	public Slider slider;
	public Canvas canvas;
	public int maxHealth = 100;
	public int currentHealth;
	public int[] moneyToAdd = new int[3];

	MoneyManager moneyManager;
	EnemySpawnPoint enemySpawn;

	void Awake (){
		
		moneyManager = FindObjectOfType <MoneyManager> ();
		canvas.enabled = false;
	}

	void Start(){

		slider.maxValue = maxHealth;
		slider.value = slider.maxValue;

		currentHealth = maxHealth;
	}

	void Update(){
		
		enemySpawn = FindObjectOfType<EnemySpawnPoint> ();
		moneyToAdd = enemySpawn.money;

	}

	public void takeDamage (int damageToTake){

		currentHealth -= damageToTake;
		canvas.enabled = true;
		slider.value = currentHealth;
		if (currentHealth <= 0) {

			if (this.gameObject.name == "Boss(Clone)")
				moneyManager.AddMoney (moneyToAdd [2]);
			else if (this.gameObject.name == "ZumbiRed(Clone)")
				moneyManager.AddMoney (moneyToAdd [1]);
			else if (this.gameObject.name == "Zumbi(Clone)")
				moneyManager.AddMoney (moneyToAdd [0]);
			
			Destroy (this.gameObject);
		}
	}

	public void DoubleCoins (){
		
		foreach(int i in moneyToAdd)
			moneyToAdd[i] *= 2;
	}
}
