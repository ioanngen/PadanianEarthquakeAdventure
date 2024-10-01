using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PEA;

public class BBEGMovement : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject waypoint;
    [SerializeField] GameObject pet;
    [SerializeField] GameObject DialogueTrigger;
    [SerializeField] GameObject EarthquakeBarrier;
    [SerializeField] GameObject DialogueTriggerPlayer;
    bool flag = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("IsRunning");
    }

    private void Update()
    {
        if (Vector2.Distance(waypoint.transform.position, transform.position) > 0.7f)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * 1.5f);
        }
        else if(flag)
        {
            animator.SetTrigger("IsNotRunning");
            flag = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DialogueTrigger"))
        {
            Invoke("Delay",5.5f);
            Invoke("Disappear",6f);
            Invoke("Destroy", 6.5f);
        }
    }

    void Disappear()
    {
        animator.SetTrigger("Disappear");
    }
    void Delay()
    {
        pet.GetComponent<Animator>().SetTrigger("Vanish");
    }

    void Destroy()
    {
        Destroy(this.gameObject);
        DialogueTrigger.SetActive(false);
        Destroy(EarthquakeBarrier);
        DialogueTriggerPlayer.SetActive(true);
    }

}
