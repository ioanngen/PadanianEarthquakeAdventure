using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnterer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    bool collisionOccurred = false;

    void Update()
    {
        CheckUserInput();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionOccurred = true;
        textComponent.text = "Press E \r\nto enter.";
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionOccurred = false;
        textComponent.text = "";
    }

    void CheckUserInput()
    {
        if (collisionOccurred)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collisionOccurred = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
