using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine;

public class Gun1 : MonoBehaviour {

	public int damage = 10;
	int originalDmage;
	bool nuke;
	public GameObject Nuke;
	public float range = 100.0f;
	public float fireRate = 15f;
	public float impactForce = 5.0f;
	public int removeAmmo = 1;
	bool automaticShoot;
	int language;
	public AudioSource gunShoot;
	private AudioClip clip;

	Ammo ammo;

	public ParticleSystem muzzleFlash;
	//public GameObject impactEffect;

	private float nextTimeToFire = 0f;

	public Camera cam;

	private Dictionary <string, Action> keywordsActions = new Dictionary<string, Action> ();
	private KeywordRecognizer keywordReconizer;
	void Awake(){

		ammo = FindObjectOfType<Ammo> ();
		originalDmage = damage;
		language = PlayerPrefs.GetInt("language");
		//cam = FindObjectOfType<Camera> ();
		//gunShoot = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {

		automaticShoot = false;

		if(language == 0)
		keywordsActions.Add ("atirar", Shoot);

		if (language == 1) {
			keywordsActions.Add ("fire", Shoot);
			keywordsActions.Add ("shoot", Shoot);
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

			Instantiate (Nuke, this.gameObject.transform.position, this.gameObject.transform.rotation);
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

			if (hit.rigidbody != null) {

				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}

			shootSound ();
			/*GameObject impact = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impact, 1f);*/
		}
	}

	void shootSound(){
		//gunShoot = GetComponent<AudioSource> ();
		clip = gunShoot.clip;
		gunShoot.PlayOneShot (clip);
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
