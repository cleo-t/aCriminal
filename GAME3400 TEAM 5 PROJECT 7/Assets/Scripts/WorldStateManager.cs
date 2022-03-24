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
    public GameObject[] villagers;

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
        i = (i + 1) % weathers.Count;
        currentWeather = weathers[i];
        currentWeather.SetActive(true);

    }
    
    private void IncrementHappiness()
    {
        this.currentTownHappiness++;
        this.currentTownHappiness %= maxTownHappiness + 1;
        IncrementVillagerHappiness();
    }

    private void IncrementVillagerHappiness()
    {
        switch(currentTownHappiness)
        {
            case 0:
                for (int i = 0; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Fear;
                break;
            case 1:
                for (int i = 0; i < villagers.Length / 4; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                for (int i = villagers.Length / 4 + 1; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Fear;
                break;
            case 2:
                for (int i = 0; i < villagers.Length / 3; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                for (int i = villagers.Length / 3 + 1; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Fear;
                break;
            case 3:
                for (int i = 0; i < villagers.Length / 2; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Fear;
                for (int i = villagers.Length / 2 + 1; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                break;
            case 4:
                for (int i = 0; i < villagers.Length / 3; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Fear;
                for (int i = villagers.Length / 3 + 1; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                break;
            case 5:
                for (int i = 0; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                break;
            case 6:
                for (int i = 0; i < villagers.Length / 4; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Happy;
                for (int i = villagers.Length / 4 + 1; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                break;
            case 7:
                for (int i = 0; i < villagers.Length / 3; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Happy;
                for (int i = villagers.Length / 3 + 1; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                break;
            case 8:
                for (int i = 0; i < villagers.Length / 2; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Happy;
                for (int i = villagers.Length / 2 + 1; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                break;
            case 9:
                for (int i = 0; i < villagers.Length / 3; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Neutral;
                for (int i = villagers.Length / 3 + 1; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Happy;
                break;
            case 10:
                for (int i = 0; i < villagers.Length; i++)
                    villagers[i].GetComponent<NPCBehavior>().state = NPCBehavior.NPCState.Happy;
                break;
        }
    }
}
