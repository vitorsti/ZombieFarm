using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour {

	public Text subtitle;
	public Text ammoText;
	public int clip;
	int clipReset;
	bool infiniteAmmo;
	public Image image;
	public Sprite normal, infinito;
	public Color color;
	public AudioSource emptySound;
	private AudioClip clipSound;

	// Use this for initialization
	void Start () {

		ammoText.text = " : " + clip;
		image.sprite = normal;
		clipReset = clip;
		infiniteAmmo = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (infiniteAmmo == false) {
			image.sprite = normal;
			ammoText.text = " : " + clip;
		} else {
			image.sprite = infinito;
			ammoText.text = " ";
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Reload ();
		}

		if ((Input.GetButtonDown ("Fire1")) && clip <= 0) {

			ammoText.color = Color.red;
			EmptySound ();
		}

		if (clip != 0)
			ammoText.color = color;

			
	}

	public void RemoveAmmo (int amountToRemove){
		
		clip -= amountToRemove;

		if (clip <= 0) {
			clip = 0;
		}
		
	}

	void Reload (){

		if (clip > 0)
			return;

		clip = clipReset;
		//ammoText.color = Color.white;
	}

	void EmptySound(){
		
		clipSound = emptySound.clip;
		emptySound.PlayOneShot (clipSound);

		if (GameManager.language == 0)
			subtitle.text = "[Arma vazia]";
		else
			subtitle.text = "[Gun is empty]";
	}

	public void InfiniteOn(){

		infiniteAmmo = true;
		clip = clipReset;
		image.sprite = infinito;
		ammoText.text = " ";
	}

	public void InfiniteOff(){

		infiniteAmmo = false;
		clip = clipReset;
		image.sprite = normal;
		ammoText.text = " : " + clip;
	}
}
