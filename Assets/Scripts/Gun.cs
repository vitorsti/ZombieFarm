using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Recoil recoil;
    public Text subtitle;
    public int damage = 10;
    public float range = 100.0f;
    public float fireRate = 15f;
    public Vector3 hipGunPosition, adsGunPosition; 
    public Quaternion hipGunRotation,  adsGunRotation; 
    public bool aiming;
    public GameObject barrelEnd;
    public float adsTime;
    //public float recoil = 5f;
    int originalDmage;
    bool nuke;
    public GameObject Nuke;

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

    void Awake()
    {

        ammo = FindObjectOfType<Ammo>();
        originalDmage = damage;
        aiming = false;
        //cam = FindObjectOfType<Camera> ();
        //gunShoot = GetComponent<AudioSource> ();
    }

    // Use this for initialization
    void Start()
    {

        automaticShoot = false;
    }

    // Update is called once per frame
    void Update()
    {


        if ((Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) && ammo.clip > 0 && automaticShoot == false)
        {

            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            shootSound();
            ammo.RemoveAmmo(removeAmmo);
        }

        if ((Input.GetButton("Fire1") && Time.time >= nextTimeToFire) && ammo.clip > 0 && automaticShoot)
        {

            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            shootSound();
            ammo.RemoveAmmo(removeAmmo);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            aiming = true;
            Aiming();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            aiming = false;
            Aiming();
        }


        if ((Input.GetKeyDown(KeyCode.N) && nuke == true))
        {

            Instantiate(Nuke, new Vector3(0, 1, 0), Quaternion.identity);
        }


    }
    void Aiming()
    {
        //Vector3 currtentGunPosition = this.gameObject.transform.localPosition;
        //Debug.Log(currtentGunPosition);
        if (aiming)
        {

            transform.localPosition = Vector3.Lerp(adsGunPosition, hipGunPosition, adsTime * Time.deltaTime);
            transform.localRotation = adsGunRotation;
            cam.fieldOfView = 30;

        }
        else
        {

            transform.localPosition = Vector3.Lerp(hipGunPosition, adsGunPosition, adsTime * Time.deltaTime);
            transform.localRotation = hipGunRotation;
            cam.fieldOfView = 60;
            //this.gameObject.transform.localPosition = hipGunPosition;
        }
    }
    void Shoot()
    {

        muzzleFlash.Play();
        //Vector3 startPosi = new Vector3(cam.transform.position.x, cam.transform.position.y, barrelEnd.transform.position.z);
        RaycastHit hit;
        Debug.DrawRay(barrelEnd.transform.position, barrelEnd.transform.forward * range, Color.red, 0.1f, false);
        if (Physics.Raycast(barrelEnd.transform.position, barrelEnd.transform.forward, out hit, range))
        {

            print(hit.transform.name);


            DamageToTake damageToTake = hit.transform.GetComponent<DamageToTake>();

            if (damageToTake != null)
            {

                damageToTake.takeDamage(damage);
                //print (damageToTake.currentHealth);
            }

            /*if (hit.rigidbody != null) {

				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}*/

            /*GameObject impact = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impact, 1f);*/
        }

        recoil.RecoilFire();
    }

    void shootSound()
    {
        //gunShoot = GetComponent<AudioSource> ();
        clip = gunShoot.clip;
        gunShoot.PlayOneShot(clip);

        if (GameManager.language == 1 && subtitle != null)
            subtitle.text = "[Som de tiro]";
        else
        {
            if (subtitle != null)
                subtitle.text = "[Shoot Sounds]";
        }
    }

    public void ResetDamage()
    {

        damage = originalDmage;
    }

    public void AutomaticShootOff()
    {
        automaticShoot = false;
    }

    public void AutomaticShootOn()
    {
        automaticShoot = true;
    }

    public void NukeOn()
    {
        nuke = true;
    }

    public void NukeOff()
    {
        nuke = false;
    }
}
