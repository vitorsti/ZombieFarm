using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{

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
    void Start()
    {
        if (ammoText != null)
            ammoText.text = " : " + clip;
        if (image != null)
            image.sprite = normal;
        clipReset = clip;
        infiniteAmmo = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if ((Input.GetButtonDown("Fire1")) && clip <= 0)
        {
            if (ammoText != null)
                ammoText.color = Color.red;
            EmptySound();
        }

        if (clip != 0)
        {
            if (ammoText != null)
                ammoText.color = color;
        }


    }

    public void RemoveAmmo(int amountToRemove)
    {

        clip -= amountToRemove;

        if (clip <= 0)
        {
            clip = 0;
        }
        UpdateText();
    }

    void Reload()
    {

        if (clip > 0)
            return;

        clip = clipReset;
        UpdateText();
        //ammoText.color = Color.white;
    }
    void UpdateText()
    {
        if (infiniteAmmo == false)
        {
            if (image != null)
                image.sprite = normal;
            if (ammoText != null)
                ammoText.text = " : " + clip;
        }
        else
        {
            if (image != null)
                image.sprite = infinito;
            if (ammoText != null)
                ammoText.text = " ";
        }
    }
    void EmptySound()
    {

        clipSound = emptySound.clip;
        emptySound.PlayOneShot(clipSound);

        
        /*if (GameManager.language == 0)
            subtitle.text = "[Arma vazia]";
        else
            subtitle.text = "[Gun is empty]";*/
    }

    public void InfiniteOn()
    {

        infiniteAmmo = true;
        clip = clipReset;
        image.sprite = infinito;
        if (ammoText != null)
            ammoText.text = " ";
    }

    public void InfiniteOff()
    {

        infiniteAmmo = false;
        clip = clipReset;
        image.sprite = normal;
        if (ammoText != null)
            ammoText.text = " : " + clip;
    }
}
