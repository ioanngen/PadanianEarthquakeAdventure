using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLM;
using TMPro;
using UnityEngine.SceneManagement;

public class DCH_Handler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    PlayerMovement playerMovement;
    bool earthquakeHappened=false;
    bool Oncollision = false;
    bool DCHAvailable = true;
    bool earthquakeActive = false;
    Animator anim;
    void Start()
    {
        textComponent.text=string.Empty;;
    }

    private void Update()
    {
        CheckUserInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!earthquakeHappened)
        {
            textComponent.text = "Press E to\n\r Drop Cover and Hold on";
            playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            anim= collision.gameObject.GetComponent<Animator>();
            Oncollision = true;
            earthquakeHappened= true;
            earthquakeActive= true;
        }else if (collision.CompareTag("Player")&&earthquakeActive)
        {
            playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            anim = collision.gameObject.GetComponent<Animator>();
            Oncollision = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DCHAvailable= true;
        Oncollision= false;
    }

    void ReleasePlayer()
    {
        anim.SetTrigger("DCH_OFF");
        playerMovement.canMove = true;

    }

    void CheckUserInput()
    {
        if (Oncollision && DCHAvailable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("DCH_ON");
                playerMovement.canMove = false;
                Invoke("ReleasePlayer", 4f);
                DCHAvailable = false;
                textComponent.text = string.Empty;
                earthquakeActive = false;
            }
        }
    }

}
