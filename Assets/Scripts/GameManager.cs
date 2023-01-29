using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int language;
    public Text subtilteText;
    public int subtitle;
    public Text hordaText;
    public GameObject sun;
    public GameObject pauseScreen;
    public GameObject Bos;
    public bool pause;
    public int waveNumber = 0;
    public int everyFiveWaves;
    public float nextWaveDelay;
    public float timer;
    public GameObject[] enemys;
    public List<GameObject> spawns = new List<GameObject>();
    public List<GameObject> spawnsAtivados = new List<GameObject>();
    AudioSource nextWaveAudio;
    CameraController[] cam;
    Gun gun;

    // Use this for initialization
    void Awake()
    {

        language = PlayerPrefs.GetInt("language");

        timer = nextWaveDelay;
        nextWaveAudio = GetComponent<AudioSource>();
        sun.SetActive(false);

        pauseScreen.SetActive(false);
        gun = FindObjectOfType<Gun>();
        cam = FindObjectsOfType<CameraController>();

        everyFiveWaves = waveNumber;
        gun.enabled = true;
        subtitle = PlayerPrefs.GetInt("Subtitle");

        if (subtitle == 1)
            subtilteText.enabled = true;
        else
            subtilteText.enabled = false;

        foreach (CameraController i in cam)
        {

            i.enabled = true;
        }
    }

    void Start()
    {

        if (language == 1)
            hordaText.text = "Noite: " + waveNumber;
        else
            hordaText.text = "Night: " + waveNumber;

        spawns[Random.Range(0, spawns.Count)].SetActive(true);
        //timer = nextWaveDelay;
    }

    // Update is called once per frame
    void Update()
    {

        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 10)
                sun.SetActive(true);
            if (timer <= 0)
            {
                timer = 0;
                ChangeHorde();
                timer = nextWaveDelay;
            }
        }
        else
        {
            sun.SetActive(false);
            timer = nextWaveDelay;
        }

        foreach (GameObject i in spawns)
        {

            if (i.activeSelf == true)
            {
                spawns.Remove(i);
                spawnsAtivados.Add(i);
            }
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            Pause();
        }


    }

    void ChangeHorde()
    {
        waveNumber++;
        everyFiveWaves++;
        if (everyFiveWaves == 5)
        {
            everyFiveWaves = 0;
            ativarSpawnAleatorio();
            Boss();
        }
        if (language == 1)
            hordaText.text = "Noite: " + waveNumber;
        else
            hordaText.text = "Night: " + waveNumber;

        EnemySpawnPoint.ResetEnemyQuantity();

        nextWaveAudio.Play();

        if (language == 1)
            subtilteText.text = "[Lobo uivando]";
        else
            subtilteText.text = "[Wolf howling]";
    }

    void ativarSpawnAleatorio()
    {

        if (spawns.Count > 0)
            spawns[Random.Range(0, spawns.Count)].SetActive(true);
        else
            return;
    }

    void Boss()
    {

        Instantiate(Bos, spawnsAtivados[Random.Range(0, spawnsAtivados.Count)].transform.position, Quaternion.identity);
    }

    void Pause()
    {
        if (pause == true)
        {
            Time.timeScale = 0;
            //image.SetActive (true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gun.enabled = false;
            pauseScreen.SetActive(true);

            foreach (CameraController i in cam)
            {

                i.enabled = false;
            }
        }
        if (pause == false)
        {
            Time.timeScale = 1;
            //image.SetActive (false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pauseScreen.SetActive(false);
            gun.enabled = true;

            foreach (CameraController i in cam)
            {

                i.enabled = true;
            }
        }
    }

}
