using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogBehavior : MonoBehaviour {

	public Transform target;
	public GameObject targetOb;
	public bool enemy;
	public int dogBiteForce = 10;
	public float Deafaultspeed;
	public GameManager game;
	NavMeshAgent agent;

	void Awake(){

		agent = GetComponent<NavMeshAgent> ();
		targetOb = GameObject.FindGameObjectWithTag ("Player");
		game = FindObjectOfType<GameManager> ();
		target = targetOb.transform;
	}

	// Use this for initialization
	void Start () {

		Deafaultspeed = agent.speed;
	}
	
	// Update is called once per frame
	void Update () {

		if (game.enemys.Length == 0) {
			enemy = false;
		}
		
		if (enemy == true) {
			targetOb = GameObject.FindGameObjectWithTag ("Enemy");
			target = targetOb.transform;
			agent.SetDestination (target.position);
		}

		if(enemy == false) {
			targetOb = GameObject.FindGameObjectWithTag ("Player");
			target = targetOb.transform;
			agent.SetDestination (target.position);
		}
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Enemy") {
			enemy = true;
			agent.speed = Deafaultspeed;
		}

		if (enemy == false) {
			if (other.gameObject.tag == "Player")
				agent.speed = 0;
		} else
			return;
			

	}

	void OnTriggerExit(Collider other){

		if (other.gameObject.tag == "Player")
			agent.speed = Deafaultspeed;
	}

	void OnCollisionEnter (Collision other){

		if (other.gameObject.tag == "Enemy") {
			DamageToTake damage = other.gameObject.GetComponent<DamageToTake> ();
			damage.takeDamage (dogBiteForce);
		}
	}

	void OnCollisionStay (Collision other){

		if (other.gameObject.tag == "Enemy") {
			DamageToTake damage = other.gameObject.GetComponent<DamageToTake> ();
			damage.takeDamage (dogBiteForce);
		}
	}
}
