using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	public Text subtilte;
	private float speed = 10.0f;
	private float defaultSpeed;
	public float jump = 50.0f;
	public float defaultJump;
	public float resetJump;
	private float run;

	 private bool jumpDisable;

	public AudioClip[] m_FootstepSounds;
	private AudioSource m_AudioSource;

	public float contador;

	Rigidbody rb;

	void Awake (){

		rb = GetComponent<Rigidbody> ();
		m_AudioSource = GetComponent<AudioSource> ();
	}

	void Start() {

		//rb = GetComponent<Rigidbody> ();
		//m_AudioSource = GetComponent<AudioSource> ();
		Cursor.lockState = CursorLockMode.Locked;
		defaultSpeed = speed;
		defaultJump = jump;
		resetJump = jump;
		run =speed * 1.5f;
	}
		
	void FixedUpdate () {

		//Andar
		float moveVert = Input.GetAxis("Vertical") * speed;
		float moveHor = Input.GetAxis("Horizontal") * speed;
		moveVert *= Time.deltaTime;
		moveHor *= Time.deltaTime;
		transform.Translate(moveHor, 0, moveVert);
		//

		//Pular
		if (Input.GetButtonDown ("Jump")) {
			
			rb.AddForce (Vector3.up * jump, ForceMode.Impulse);
			jumpDisable = true;
		}

		if (jumpDisable == true) {
			jump = 0;
		} else {
			jump = defaultJump;
		}
		//

		//Correr
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = run;
		} else {
			speed = defaultSpeed;
		}
		//

		//habilitar o cursor
		if (Input.GetKeyDown (KeyCode.Escape))
			Cursor.lockState = CursorLockMode.None;
		//

		contador += Time.deltaTime;

		if ((moveHor != 0 || moveVert != 0) && contador > 0.5f && jumpDisable == false) {
			contador = 0;
			SomDePassos ();
		}
	}

	void OnCollisionEnter (Collision other){

		if (other.gameObject.tag == "floor")
			jumpDisable = false;

	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.name == "void")
			transform.position = new Vector3 (0,1,0);
	}

	void SomDePassos (){

		int n = Random.Range(1, m_FootstepSounds.Length);
		m_AudioSource.clip = m_FootstepSounds[n];
		m_AudioSource.PlayOneShot(m_AudioSource.clip);
		m_FootstepSounds[n] = m_FootstepSounds[0];
		m_FootstepSounds[0] = m_AudioSource.clip;

		if(GameManager.language == 1)
			subtilte.text = "[Som de passos]";
		else
			subtilte.text = "[Footsteps sounds]";
		//print ("passos");
	}

	public void ResetJump(){

		jump = resetJump;
		defaultJump = resetJump;
	}
}
