using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {

	public float speed;
	public Transform target;
	public GameObject gb;

	public int dealDamage = 10;

	public AudioSource audioSource;
	private AudioClip clip;
	public NavMeshAgent agent;
	public PlayerHealth playerHealth;
	public bool zombieType;

	Rigidbody rb;

	void Awake(){

		agent = GetComponent<NavMeshAgent> ();
		rb = GetComponent<Rigidbody> ();
		gb = GameObject.FindGameObjectWithTag ("Player");
		audioSource = GetComponent<AudioSource> ();
		target = gb.transform;
		playerHealth = FindObjectOfType<PlayerHealth> ();

		if (this.gameObject.name == "ZumbiRed" || this.gameObject.name == "ZumbiRed(Clone)" || this.gameObject.name == "Boss" || this.gameObject.name == "Boss(Clone)") {
			zombieType = true;
			agent.enabled = true;
		} else {
			agent.enabled = false;
			zombieType = false;
		}
	} 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		if (zombieType)
			agent.SetDestination (target.position);
		else {
			transform.LookAt (target);
			transform.position += transform.forward * speed * Time.deltaTime;
		}

	}

	void OnCollisionEnter (Collision other){

		if (other.gameObject.tag == "Player") {

			playerHealth.takeDamage (dealDamage);
		}
	}
		
}
