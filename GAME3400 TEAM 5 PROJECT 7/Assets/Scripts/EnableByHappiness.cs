using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableByHappiness : MonoBehaviour
{
    [SerializeField]
    private bool enableWhenMatching = true;
    [SerializeField]
    private float minHappiness = 0;
    [SerializeField]
    private float maxHappiness = 1;

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
        this.gameObject.SetActive(this.enableWhenMatching ==
            (WorldStateManager.happiness >= this.minHappiness
            && WorldStateManager.happiness <= this.maxHappiness));
    }
}
