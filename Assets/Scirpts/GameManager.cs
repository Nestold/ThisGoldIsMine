using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<string> OnTimerChange = delegate { };
    public event Action<int> OnLifesChange = delegate { };
    public event Action<int> OnCoinsChange = delegate { };
    public event Action<float> OnFirePowerChange = delegate { };

    public UIManager UIManager => uIManager;

    public static GameManager Instance;

    public bool GameStarted { get; private set; } = false;

    [SerializeField]
    private UIManager uIManager = null;

    [SerializeField]
    private Player player = null;

    [SerializeField]
    private int maxLifes = 3;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }

    private float timer = 0;
    private int lifes = 0;
    private int coins = 0;

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            OnTimerChange($"{Mathf.FloorToInt(timer / 60).ToString("00")} : {Mathf.FloorToInt(timer % 60).ToString("00")}");
        }
        else if(GameStarted)
        {
            timer = 0;
            EndGame();
        }
    }

    public void StartNewGame()
    {
        lifes = maxLifes;
        timer = 60;
        OnLifesChange(lifes);
        OnCoinsChange(coins);
        player.CanMove = true;
        GameStarted = true;
        uIManager.ShowOnMoreMinute();
    }

    public void EndGame()
    {
        player.CanMove = false;
        GameStarted = false;
        UIManager.ShowEndPanel();
    }

    public void RemoveLife()
    {
        if(lifes > 0)
        {
            lifes--;
            OnLifesChange(lifes);
        }
    }

    public void AddLife()
    {
        if(lifes < maxLifes)
        {
            lifes++;
            OnLifesChange(lifes);
        }
    }

    public void AddCoin()
    {
        coins++;
        OnCoinsChange(coins);
    }

    public void AddTime()
    {
        timer += 60f;
    }

    public void SetFireDisplay(float firePower)
    {
        OnFirePowerChange(firePower);
    }
}
