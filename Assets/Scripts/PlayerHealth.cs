using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private bool immortal;

    public Slider healthBar;
    public int nighHighscore;
    public int money;
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject GameOverScreen;
    MoneyManager moneyMan;
    Gun gun;
    CameraController[] cameracontroller;
    GameManager game;
    InventoryManager inve;

    void Awake()
    {

#if (!UNITY_EDITOR)
        if (immortal)
            immortal = false;
#endif
        healthBar = GetComponent<Slider>();
        gun = FindObjectOfType<Gun>();
        cameracontroller = FindObjectsOfType<CameraController>();
        GameOverScreen.SetActive(false);
        game = FindObjectOfType<GameManager>();
        inve = FindObjectOfType<InventoryManager>();
        moneyMan = FindObjectOfType<MoneyManager>();
        Time.timeScale = 1;
        nighHighscore = PlayerPrefs.GetInt("highscore");
        money = PlayerPrefs.GetInt("money");


    }

    void Start()
    {

        healthBar.maxValue = maxHealth;
        healthBar.value = healthBar.maxValue;

        currentHealth = maxHealth;
    }

    void Update()
    {

        /*if (currentHealth <= 0)
        {
            currentHealth = 0;
            gun.enabled = false;
            game.enabled = false;
            inve.enabled = false;

            foreach (CameraController i in cameracontroller)
            {
                i.enabled = false;
            }

            if (game.waveNumber > nighHighscore)
                PlayerPrefs.SetInt("highscore", game.waveNumber);

            PlayerPrefs.SetInt("money", moneyMan.moneyAmount);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);

        }*/
    }

    public void takeDamage(int damageToTake)
    {
        if (immortal)
            return;

        currentHealth -= damageToTake;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            GameOver();
        }
    }

    public void resetHealth()
    {

        healthBar.value = healthBar.maxValue;
    }

    void GameOver()
    {
        gun.enabled = false;
        game.enabled = false;
        inve.enabled = false;

        foreach (CameraController i in cameracontroller)
        {
            i.enabled = false;
        }

        if (game.waveNumber > nighHighscore)
            PlayerPrefs.SetInt("highscore", game.waveNumber);

        PlayerPrefs.SetInt("money", moneyMan.moneyAmount);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }
}
