using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text coinsValue = null;

    [SerializeField]
    private Text timerValue = null;

    [SerializeField]
    private List<GameObject> lifes = null;

    [SerializeField]
    private Slider fireSlider = null;

    [SerializeField]
    private GameObject oneMoreMinute = null;

    [SerializeField]
    private Button startButton = null;

    [SerializeField]
    private GameObject startPanel = null;

    [SerializeField]
    private Button restartButton = null;
    [SerializeField]
    private GameObject endPanel = null;

    private void Start()
    {
        var gMan = GameManager.Instance;

        gMan.OnTimerChange -= UpdateTimer;
        gMan.OnTimerChange += UpdateTimer;

        gMan.OnCoinsChange -= UpdateCoins;
        gMan.OnCoinsChange += UpdateCoins;

        gMan.OnLifesChange -= UpdateLifes;
        gMan.OnLifesChange += UpdateLifes;

        gMan.OnFirePowerChange -= UpdateFireRate;
        gMan.OnFirePowerChange += UpdateFireRate;

        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void StartGame()
    {
        startPanel.SetActive(false);
        GameManager.Instance.StartNewGame();
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
    }

    public void UpdateLifes(int lifes)
    {
        for(int i = 0; i < this.lifes.Count; i++)
        {
            this.lifes[i].SetActive(i < lifes);
        }
    }

    public void UpdateTimer(string timer)
    {
        timerValue.text = timer;
    }

    public void UpdateCoins(int coins)
    {
        coinsValue.text = coins.ToString("000000000");
    }

    public void UpdateFireRate(float value)
    {
        if(value <= -1)
        {
            fireSlider.gameObject.SetActive(false);
            return;
        }
        if(!fireSlider.gameObject.activeSelf)
        {
            fireSlider.gameObject.SetActive(true);
        }
        fireSlider.value = value;
    }

    public void ShowOnMoreMinute()
    {
        oneMoreMinute.SetActive(true);
    }
}
