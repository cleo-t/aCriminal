using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateManager : MonoBehaviour
{
    private static WorldStateManager instance;

    private static int weatherStateCount = 3;
    public enum WeatherState
    {
        Clear = 0,
        Rainy,
        Cloudy
    }
    private WeatherState currentWeather;

    private static int maxTownHappiness = 10;
    private int currentTownHappiness;

    public static WeatherState weather
    {
        get
        {
            return instance == null ? WeatherState.Clear : instance.currentWeather;
        }
    }
    public static float happiness
    {
        get
        {
            return instance == null ? 0 : (float)instance.currentTownHappiness / (float)maxTownHappiness;
        }
        private set { }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        this.currentWeather = WeatherState.Clear;
        this.currentTownHappiness = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.IncrementWeather();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.IncrementHappiness();
        }
    }

    private void IncrementWeather()
    {
        this.currentWeather++;
        if ((int)this.currentWeather >= weatherStateCount)
        {
            this.currentWeather = 0;
        }
    }
    
    private void IncrementHappiness()
    {
        this.currentTownHappiness++;
        this.currentTownHappiness %= maxTownHappiness + 1;
    }
}
