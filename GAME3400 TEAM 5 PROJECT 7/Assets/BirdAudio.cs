using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAudio : MonoBehaviour
{
    public float radius = 10f;

    public GameObject player;

    private float disToPlay;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        disToPlay = Vector2.Distance(transform.position, player.transform.position);

        if (disToPlay < radius)
        {
            PlaySound();
        }
        source.volume = 1 - (disToPlay/radius);
    }

    private void PlaySound()
    {
        source.Play();
    }
}
