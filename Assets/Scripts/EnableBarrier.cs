using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnableBarrier : MonoBehaviour
{

    [SerializeField] GameObject barrier;
    private BoxCollider2D bc;
    public float delay = 3f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(bc.isTrigger == false)
        {
            timer += Time.deltaTime;
        }
        if (timer > delay)
        {
            bc.isTrigger = true;
            barrier.GetComponent<BoxCollider2D>().isTrigger = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bc.isTrigger = false;
        barrier.GetComponent<BoxCollider2D>().isTrigger = false;
    }

}
