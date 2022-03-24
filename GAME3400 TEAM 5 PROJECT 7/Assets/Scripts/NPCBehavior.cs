using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public enum NPCState
    {
        Fear = 0,
        Neutral = 1,
        Happy = 2
    }

    public GameObject player;
    public GameObject[] wanderPoints;
    public GameObject[] townSquare;
    public float reactionDistance = 2;

    public NPCState state;
    float deviation = 2;
    int currentWanderPoint = 0;
    int currentTownSquarePoint = 0;
    int speed = 2;

    void Start()
    {
        state = NPCState.Fear;
        transform.position = new Vector3(deviateValue(wanderPoints[0].transform.position.x), wanderPoints[0].transform.position.y, deviateValue(wanderPoints[0].transform.position.z));
    }

    
    void Update()
    {
        if (state == NPCState.Happy)
        {
            // Walk between wanderpoints
            if (Vector3.Distance(transform.position, townSquare[currentTownSquarePoint].transform.position) <= deviateValue(deviation))
            {
                currentTownSquarePoint++;
                currentTownSquarePoint %= townSquare.Length;
            }
            else
            {
                Vector3 temp = townSquare[currentTownSquarePoint].transform.position;
                temp.y = transform.position.y;
                transform.position = Vector3.MoveTowards(transform.position, temp, speed * Time.deltaTime);
            }
            return;
        }

        // Check for if the player is in line of sight
        RaycastHit hit;
        if (state != NPCState.Neutral && Physics.Raycast(transform.position, transform.position - player.transform.position, out hit, reactionDistance))
        {
            // If they are afraid. Stare at the player and back away
            Vector3 temp = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(temp);
            transform.position = Vector3.MoveTowards(transform.position, temp, -0.02f);
        }
        else
        {
            // Walk between wanderpoints
            if (Vector3.Distance(transform.position, wanderPoints[currentWanderPoint].transform.position) <= deviateValue(deviation))
            {
                currentWanderPoint++;
                currentWanderPoint %= wanderPoints.Length;
            }
            else
            {
                Vector3 temp = wanderPoints[currentWanderPoint].transform.position;
                temp.y = transform.position.y;
                transform.position = Vector3.MoveTowards(transform.position, temp, speed * Time.deltaTime);
            }
        }
    }

    float deviateValue(float value)
    {
        return (float)Random.Range(value - deviation, value + deviation);
    }
}
