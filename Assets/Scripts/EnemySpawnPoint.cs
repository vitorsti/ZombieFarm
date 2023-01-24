using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {

	public GameObject enemy;
	public GameObject[] enemys;
	public Transform spawn;
	public float spawnStart = 10;
	public float spawnDelay = 1;
	public int[] money;
	public int[] resetMoney;
	public static float enemyQuantity;
	public static float enemyQuantityReset = 10;

	void Awake (){

		money = new int[3];
		money [0] = 10;
		money [1] = 20;
		money [2] = 100;

		resetMoney = new int[3];
		resetMoney [0] = money [0];
		resetMoney [1] = money [1];
		resetMoney [2] = money [2];

		if (ItensShop.doubleCoins == true) {
			
			for (int i = 0; i < money.Length; i++) {
				money [i] *= 2;
			}
		}

	}
	// Use this for initialization
	void Start () {
		enemyQuantity = enemyQuantityReset;
		InvokeRepeating ("SpawnEnemies", spawnStart, spawnDelay);
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void SpawnEnemies (){

		if (enemyQuantity <= 0) {
			enemyQuantity = 0;
			return;

		}

		Instantiate (/*enemy*/enemys[Random.Range(0, enemys.Length)], spawn.position, Quaternion.identity);
		enemyQuantity--;
	}

	public static void ResetEnemyQuantity(){

		enemyQuantityReset++;
		enemyQuantity = enemyQuantityReset;
	}

	public void ResetMoney(){

		money[0] = resetMoney[0];
		money[1] = resetMoney[1];
		money[2] = resetMoney[2];
	}
}
