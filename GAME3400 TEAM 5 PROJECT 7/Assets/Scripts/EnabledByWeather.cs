using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledByWeather : MonoBehaviour
{
    [SerializeField]
    private bool enableWhenMatching = true;
    [SerializeField]
    private List<WorldStateManager.WeatherState> weatherConditions;

    void Start()
    {
        this.Refresh();
    }

    void Update()
    {
        this.Refresh();
    }

    private void Refresh()
    {
        foreach(WorldStateManager.WeatherState ws in this.weatherConditions)
        {
            if (WorldStateManager.weather == ws)
            {
                this.gameObject.SetActive(this.enableWhenMatching);
            }
        }
        this.gameObject.SetActive(!this.enableWhenMatching);
    }
}
