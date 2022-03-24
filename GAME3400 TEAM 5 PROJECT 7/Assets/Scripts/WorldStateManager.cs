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
    //private WeatherState currentWeather;

    private static int maxTownHappiness = 10;
    private int currentTownHappiness;

    /*
    public static WeatherState weather
    {
        get
        {
            return instance == null ? WeatherState.Clear : instance.currentWeather;
        }
    }
    */
    public static float happiness
    {
        get
        {
            return instance == null ? 0 : (float)instance.currentTownHappiness / (float)maxTownHappiness;
        }
        private set { }
    }

    [SerializeField]
    public List<GameObject> weathers;

    public int i = 0;

    private GameObject currentWeather;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        this.currentWeather = weathers[i];
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
        currentWeather.SetActive(false);
        i = (i + 1) % (weathers.Count);
        
        currentWeather = weathers[i];

        currentWeather.SetActive(true);

    }
    
    private void IncrementHappiness()
    {
        this.currentTownHappiness++;
        this.currentTownHappiness %= maxTownHappiness + 1;
    }
}
