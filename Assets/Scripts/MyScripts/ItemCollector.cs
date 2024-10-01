using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PLF;

public class ItemCollector : MonoBehaviour
{
    int supplyCount = 0;
    [SerializeField] AudioSource checkpointSoundEffect;
    [SerializeField] Text suppliesText;
    bool notReached = true;
    Animator CheckpointAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animator animator= collision.gameObject.GetComponent<Animator>();
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            CheckpointAnimator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Reached");
            if (notReached)
            {
                checkpointSoundEffect.Play();
                notReached = false;
            }
            Invoke("SetIdleReached",0.5f);
            Invoke("LevelCompleted",2.5f);
            
        }

        if (collision.gameObject.CompareTag("Collectable"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Collected");
            supplyCount++;
            suppliesText.text = "Supplies: " + supplyCount;
            
            if (collision.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                Destroy(collision.gameObject, 0.1f);
            }
            
            
        }
    }
    void SetIdleReached()
    {
        CheckpointAnimator.SetTrigger("IdleReached");
    }
    void LevelCompleted()
    {
        if (SceneManager.GetActiveScene().name== "FinalLevel")
        {
            SceneManager.LoadScene(0);
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerLife.restarted = false;

        }
    }
}
