using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItensShop : MonoBehaviour {

	public bool nearTree;
	public Transform dogPositon;
	public GameObject dog;
	public Text text;
	public int moneyToRemove = 20;
	public Button icon;
	public bool haveTten;
	public static bool doubleCoins;

	public enum ItenType {

		DoubleDamage,
		HigherJump,
		HealthUpgrade,
		Nuke,
		AutomaticShoot,
		NPC,
		DoubleCoins,
		InfiniteAmmo,


	}

	public ItenType itenType;

	InventoryManager inventory;
	MoneyManager moneyMan;
	PlayerController playerCon;
	PlayerHealth playerHeal;
	Ammo ammo;

	public EnemySpawnPoint enemySpawn;
	public DamageToTake[] damageToTake;
	Gun gun;

	void Awake (){

		moneyMan = FindObjectOfType<MoneyManager> ();
		playerCon = FindObjectOfType<PlayerController> ();
		gun = FindObjectOfType<Gun> ();
		inventory = FindObjectOfType<InventoryManager> ();
		playerHeal = FindObjectOfType<PlayerHealth> ();
		ammo = FindObjectOfType<Ammo> ();
		//damageToTake = FindObjectOfType<DamageToTake> ();
	}

	// Use this for initialization
	void Start () {
		//enemySpawn = FindObjectOfType<EnemySpawnPoint> ();
		doubleCoins = false;
		text.text = " ";
	}
	
	// Update is called once per frame
	void Update () {
		enemySpawn = FindObjectOfType<EnemySpawnPoint> ();

		if (Input.GetKeyDown (KeyCode.E ) && nearTree) {

			switch (itenType) {
			case ItenType.DoubleDamage:
				DoubleDamage ();
				break;
			case ItenType.HigherJump:
				HigherJump ();
				break;
			case ItenType.HealthUpgrade:
				ResetHealth ();
				break;
			case ItenType.Nuke:
				Nuke ();
				break;
			case ItenType.AutomaticShoot:
				AutomaticShoot ();
				break;
			case ItenType.NPC:
				NPC ();
				break;
			case ItenType.DoubleCoins:
				DoubleCoins ();
				break;
			case ItenType.InfiniteAmmo:
				InfiniteAmmo ();
				break;
			}
		}
			
	}

	//Buy
	public void DoubleDamage () {

		if (moneyMan.moneyAmount < moneyToRemove){
			if(GameManager.language == 1)
				text.text = ("Dinheiro insuficiente!! Forasteiro...");
			else
				text.text = ("Not Enougth Cash!! Stranger...");
			return;
		}

		if (inventory.buttonList.Count == 3) {
			if(GameManager.language == 1)
				text.text = ("Inventário cheio");
			else
				text.text = ("Inventory Full");
			return;
		}

		if (haveTten == true) {
			if(GameManager.language == 1)
				text.text = ("Você já tem esse item");
			else
				text.text = ("You already have this item");
			return;
		}
			
		moneyMan.RemoveMoney (moneyToRemove);
		inventory.buttonList.Add (icon);
		haveTten = true;
		gun.damage *= 2;
		//print ("Dano em dobro");
	}

	public void HigherJump () {

		if (moneyMan.moneyAmount < moneyToRemove){
			if(GameManager.language == 1)
				text.text = ("Dinheiro insuficiente!! Forasteiro...");
			else
				text.text = ("Not Enougth Cash!! Stranger...");
			return;
		}

		if (inventory.buttonList.Count == 3) {
			if(GameManager.language == 1)
				text.text = ("Inventário cheio");
			else
				text.text = ("Inventory Full");
			return;
		}

		if (haveTten == true) {
			if(GameManager.language == 1)
				text.text = ("Você já tem esse item");
			else
				text.text = ("You already have this iten");
			return;
		}

		moneyMan.RemoveMoney (moneyToRemove);
		inventory.buttonList.Add (icon);
		haveTten = true;
		playerCon.defaultJump *= 2;
		//print ("Pulo alto");
	}

	public void ResetHealth () {

		if (moneyMan.moneyAmount < moneyToRemove){
			if(GameManager.language == 1)
				text.text = ("Dinheiro insuficiente!! Forasteiro...");
			else
				text.text = ("Not Enougth Cash!! Stranger...");
			return;
		}

		if (playerHeal.healthBar.value >= playerHeal.healthBar.maxValue) {
			if(GameManager.language == 1)
				text.text = ("Vida cheia");
			else
				text.text = ("Health full");
			return;
		}
			
		moneyMan.RemoveMoney (moneyToRemove);
		playerHeal.resetHealth ();

	}

	public void Nuke () {

		if (moneyMan.moneyAmount < moneyToRemove){
			if(GameManager.language == 1)
				text.text = ("Dinheiro insuficiente!! Forasteiro...");
			else
				text.text = ("Not Enougth Cash!! Stranger...");
			return;
		}

		if (inventory.buttonList.Count == 3) {
			if(GameManager.language == 1)
				text.text = ("Inventário cheio");
			else
				text.text = ("Inventory Full");
			return;
		}

		if (haveTten == true) {
			if(GameManager.language == 1)
				text.text = ("Você já tem esse item");
			else
				text.text = ("You already have this iten");
			return;
		}

		moneyMan.RemoveMoney (moneyToRemove);
		inventory.buttonList.Add (icon);
		haveTten = true;
		gun.NukeOn ();
		//print ("Nuke");
	}

	public void AutomaticShoot () {

		if (moneyMan.moneyAmount < moneyToRemove){
			if(GameManager.language == 1)
				text.text = ("Dinheiro insuficiente!! Forasteiro...");
			else
				text.text = ("Not Enougth Cash!! Stranger...");
			return;
		}

		if (inventory.buttonList.Count == 3) {
			if(GameManager.language == 1)
				text.text = ("Inventário cheio");
			else
				text.text = ("Inventory Full");
			return;
		}

		if (haveTten == true) {
			if(GameManager.language == 1)
				text.text = ("Você já tem esse item");
			else
				text.text = ("You already have this iten");
			return;
		}

		moneyMan.RemoveMoney (moneyToRemove);
		inventory.buttonList.Add (icon);
		haveTten = true;
		gun.AutomaticShootOn ();
		//print ("Tiro Automatico");
	}

	public void NPC () {

		if (moneyMan.moneyAmount < moneyToRemove){
			if(GameManager.language == 1)
				text.text = ("Dinheiro insuficiente!! Forasteiro...");
			else
				text.text = ("Not Enougth Cash!! Stranger...");
			return;
		}

		if (inventory.buttonList.Count == 3) {
			if(GameManager.language == 1)
				text.text = ("Inventário cheio");
			else
				text.text = ("Inventory Full");
			return;
		}

		if (haveTten == true) {
			if(GameManager.language == 1)
				text.text = ("Você já tem esse item");
			else
				text.text = ("You already have this iten");
			return;
		}

		moneyMan.RemoveMoney (moneyToRemove);
		inventory.buttonList.Add (icon);
		haveTten = true;
		Instantiate (dog, dogPositon.transform, dogPositon.transform);
		//print ("NPC");
	}

	public void DoubleCoins () {

		if (moneyMan.moneyAmount < moneyToRemove){
			if(GameManager.language == 1)
				text.text = ("Dinheiro insuficiente!! Forasteiro...");
			else
				text.text = ("Not Enougth Cash!! Stranger...");
			return;
		}

		if (inventory.buttonList.Count == 3) {
			if(GameManager.language == 1)
				text.text = ("Inventário cheio");
			else
				text.text = ("Inventory Full");
			return;
		}

		if (haveTten == true) {
			if(GameManager.language == 1)
				text.text = ("Você já tem esse item");
			else
				text.text = ("You already have this iten");
			return;
		}

		moneyMan.RemoveMoney (moneyToRemove);
		inventory.buttonList.Add (icon);
		haveTten = true;
		doubleCoins = true;
		for (int i = 0; i < enemySpawn.money.Length; i++) {
			enemySpawn.money [i] *= 2;
		}
		
		//print ("Dinheiro em dobro");
	}

	public void InfiniteAmmo () {

		if (moneyMan.moneyAmount < moneyToRemove){
			if(GameManager.language == 1)
				text.text = ("Dinheiro insuficiente!! Forasteiro...");
			else
				text.text = ("Not Enougth Cash!! Stranger...");
			return;
		}

		if (inventory.buttonList.Count == 3) {
			if(GameManager.language == 1)
				text.text = ("Inventário cheio");
			else
				text.text = ("Inventory Full");
			return;
		}

		if (haveTten == true) {
			if(GameManager.language == 1)
				text.text = ("Você já tem esse item");
			else
				text.text = ("You already have this iten");
			return;
		}

		moneyMan.RemoveMoney (moneyToRemove);
		inventory.buttonList.Add (icon);
		haveTten = true;
		gun.removeAmmo = 0;
		ammo.InfiniteOn ();
		//print ("Munição infinita");
	}
		
	//Sell
	public void SellDoubleDamage(){
		
		haveTten = false;
		moneyMan.AddMoney (moneyToRemove);

		for (int i = 0; i < inventory.buttonList.Count; i++) {

			if (inventory.buttonList [i].name == icon.name)
				inventory.buttonList.RemoveAt (i);
		}

		inventory.OriginalPosition (icon);
		gun.ResetDamage ();
	}

	public void SellHigherJump(){

		haveTten = false;
		moneyMan.AddMoney (moneyToRemove);

		for (int i = 0; i < inventory.buttonList.Count; i++) {

			if (inventory.buttonList [i].name == icon.name)
				inventory.buttonList.RemoveAt (i);
		}

		inventory.OriginalPosition (icon);
		playerCon.ResetJump ();
	}

	public void SellNuke(){

		haveTten = false;
		moneyMan.AddMoney (moneyToRemove);

		for (int i = 0; i < inventory.buttonList.Count; i++) {

			if (inventory.buttonList [i].name == icon.name)
				inventory.buttonList.RemoveAt (i);
		}

		inventory.OriginalPosition (icon);
		gun.NukeOff ();
	}

	public void SellAutomaticShoot (){

		haveTten = false;
		moneyMan.AddMoney (moneyToRemove);

		for (int i = 0; i < inventory.buttonList.Count; i++) {

			if (inventory.buttonList [i].name == icon.name)
				inventory.buttonList.RemoveAt (i);
		}

		inventory.OriginalPosition (icon);
		gun.AutomaticShootOff();
	}

	public void SellNpc(){

		haveTten = false;
		moneyMan.AddMoney (moneyToRemove);

		for (int i = 0; i < inventory.buttonList.Count; i++) {

			if (inventory.buttonList [i].name == icon.name)
				inventory.buttonList.RemoveAt (i);
		}

		inventory.OriginalPosition (icon);
		Destroy(GameObject.FindGameObjectWithTag("Dog"));
	}

	public void SellDoubleCoins(){

		haveTten = false;
		doubleCoins = false;
		moneyMan.AddMoney (moneyToRemove);

		for (int i = 0; i < inventory.buttonList.Count; i++) {

			if (inventory.buttonList [i].name == icon.name)
				inventory.buttonList.RemoveAt (i);
		}

		inventory.OriginalPosition (icon);
		enemySpawn.ResetMoney ();
	}

	public void SellInfiniteAmmo(){

		haveTten = false;
		moneyMan.AddMoney (moneyToRemove);

		for (int i = 0; i < inventory.buttonList.Count; i++) {

			if (inventory.buttonList [i].name == icon.name)
				inventory.buttonList.RemoveAt (i);
		}

		inventory.OriginalPosition (icon);
		ammo.InfiniteOff ();
		gun.removeAmmo = 1;
	}

	void OnTriggerEnter (Collider other){

		//print (this.gameObject.name);

		if (other.gameObject.tag == "Player") {

			nearTree = true;

			if(GameManager.language == 1)
				text.text = " Pressione a tecla <color=white> E </color> para comprar " + "<color=red> " + this.gameObject.name + "</color>" + "\n Custa: " + "<color=green>" +  moneyToRemove + "</color> ";
			else
				text.text = " Press the key <color=white> E </color> to buy " + "<color=red> " + this.gameObject.name + "</color>" + "\n Price: " + "<color=green>" +  moneyToRemove + "</color> ";
		}
	}

	void OnTriggerExit (Collider other){

		if (other.gameObject.tag == "Player") {

			nearTree = false;
			text.text = " ";
		}
	}
}
