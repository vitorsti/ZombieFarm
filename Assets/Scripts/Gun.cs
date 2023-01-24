using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

	public Text subtitle;
	public int damage = 10;
	int originalDmage;
	bool nuke;
	public GameObject Nuke;
	public float range = 100.0f;
	public float fireRate = 15f;
	//public float impactForce = 5.0f;
	public int removeAmmo = 1;
	bool automaticShoot;
	public AudioSource gunShoot;
	private AudioClip clip;

	Ammo ammo;

	public ParticleSystem muzzleFlash;
	//public GameObject impactEffect;

	private float nextTimeToFire = 0f;

	public Camera cam;

	void Awake(){

		ammo = FindObjectOfType<Ammo> ();
		originalDmage = damage;

		//cam = FindObjectOfType<Camera> ();
		//gunShoot = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {

		automaticShoot = false;
	}
	
	// Update is called once per frame
	void Update () {

			
		if ((Input.GetButtonDown ("Fire1") && Time.time >= nextTimeToFire ) && ammo.clip > 0 && automaticShoot == false) {

				nextTimeToFire = Time.time + 1f / fireRate;
				Shoot ();
				shootSound ();
				ammo.RemoveAmmo (removeAmmo);
			}

		if ((Input.GetButton ("Fire1") && Time.time >= nextTimeToFire ) && ammo.clip > 0 && automaticShoot) {

			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot ();
			shootSound ();
			ammo.RemoveAmmo (removeAmmo);
		}

		if ((Input.GetButtonDown ("Fire2") && nuke == true)){

			Instantiate (Nuke, new Vector3 (0, 1, 0), Quaternion.identity);
		}
	}

	void Shoot(){

		muzzleFlash.Play ();

		RaycastHit hit;

		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {

			//print (hit.transform.name);

			DamageToTake damageToTake = hit.transform.GetComponent<DamageToTake> ();

			if (damageToTake != null) {

				damageToTake.takeDamage (damage);
				//print (damageToTake.currentHealth);
			}

			/*if (hit.rigidbody != null) {

				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}*/

			/*GameObject impact = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impact, 1f);*/
		}
	}

	void shootSound(){
		//gunShoot = GetComponent<AudioSource> ();
		clip = gunShoot.clip;
		gunShoot.PlayOneShot (clip);

		if(GameManager.language == 1)
			subtitle.text = "[Som de tiro]";
		else
			subtitle.text = "[Shoot Sounds]";
	}

	public void ResetDamage(){

		damage = originalDmage;
	}

	public void AutomaticShootOff(){
		automaticShoot = false;
	}

	public void AutomaticShootOn(){
		automaticShoot = true;
	}

	public void NukeOn(){
		nuke = true;
	}

	public void NukeOff(){
		nuke = false;
	}
}
