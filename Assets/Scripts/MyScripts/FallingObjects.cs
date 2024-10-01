using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PEA
{
    public class FallingObjects : MonoBehaviour
    {
        public bool earthquakeActive = false;
        [SerializeField] GameObject waypoint;
        [SerializeField] float speed = 2f;
        public float delay = 0.5f;
        void Update()
        {
            if (earthquakeActive)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);

            }
            if (Vector2.Distance(waypoint.transform.position, transform.position) < .1f) 
            {
                Animator animdad = this.gameObject.GetComponent<Animator>();
                animdad.SetTrigger("Destroy");
                if (transform.childCount>0) {
                    foreach (Transform child in transform)
                    {
                        Animator anim = child.gameObject.GetComponent<Animator>();
                        anim.SetTrigger("Destroy");
                        Invoke("destroy", 1f);
                    }
                }
                else
                {
                    Invoke("destroy", 1f);
                }
            }
        }
        void destroy()
        {
            Destroy(this.gameObject);
        } 

    }
}