using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public enum NPCType {
        Adult = 0,
        Child = 1
    }
    public enum NPCState
    {
        Fear = 0,
        Neutral = 1,
        Happy = 2
    }

    public NPCType type;
    public GameObject player;
    public GameObject[] wanderPoints;
    public float reactionDistance = 10;

    NPCState state;
    float deviation = 2;


    void Start()
    {
        state = NPCState.Fear;
        transform.position = new Vector3(deviateValue(wanderPoints[0].transform.position.x), wanderPoints[0].transform.position.y, deviateValue(wanderPoints[0].transform.position.z));
    }

    
    void Update()
    {
        // Walk between wanderpoints



        // Adults
        if (type == NPCType.Adult)
        {
            

        }
        // Children
        else
        {

        }

        
        // If it can see the player and is fearful, stare
            // If the player is within the reaction distance, back away
        // If it can see the player and is neautral keep walking
        // If it can see the player and is happy, jump once
            // If the player is within the reaction distance, jump multiple times and spin in a circle

        
        // If it can see the player and is fearful, stare
            // If the player is within the reaction distance, run away
        // If it can see the playre and is neautral keep walking
        // If it can see the player and is happy, run to them
            // If the player is within the reaction distance, stop moving and jump multiple times
    }


    float deviateValue(float value)
    {
        return (float)Random.Range(value - deviation, value + deviation);
    }

    
}
