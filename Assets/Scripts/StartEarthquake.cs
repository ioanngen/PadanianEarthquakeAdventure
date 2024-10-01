using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using PEA;
using waypoints;
using UnityEditor.Rendering;

public class StartEarthquake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] GameObject[] spikes;
    int CurrentSpikesIndex = 0;
    [SerializeField] AudioSource earthquakeSound;
    private bool earthquakeNotHappend = true;

    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (earthquakeNotHappend)
        {
            if (spikes != null)
            {
                while (CurrentSpikesIndex < spikes.Length)
                {
                    FallingObjects fallingObjects = spikes[CurrentSpikesIndex].gameObject.GetComponent<FallingObjects>();
                    fallingObjects.earthquakeActive = true;
                    CurrentSpikesIndex++;
                }
            }
            earthquakeSound.Play();
            earthquakeNotHappend = false;
            impulseSource.GenerateImpulseWithForce(1f);
        }
    }
}