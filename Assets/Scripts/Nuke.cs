using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour {

	int damage = 1000;
	public DamageToTake[] damageToTake;
	private float temp = 1;
	public float speed = 1;
	// Use this for initialization
	void Start () {
		//print ("KABUM");
	}
	
	// Update is called once per frame
	void Update () {

		damageToTake = FindObjectsOfType<DamageToTake> ();
		temp += Time.deltaTime * speed;
		//transform.localScale = Vector3.Lerp (transform.localScale, Vector3.one * 500, speed * Time.deltaTime);
		transform.localScale = Vector3.one * temp;

		if(transform.localScale.x >= 500)
			Destroy (this.gameObject);
	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Enemy") {

			foreach (DamageToTake i in damageToTake)
				i.takeDamage (damage);
		}
	}
}
