using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using PLM;
using PEA;

public class DialogueGenerator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] float textSpeed;
    [SerializeField] int sceneIndex;
    static int LineToPlay = 0;
    [SerializeField] Canvas canvas;
    PlayerMovement playerMovement;
    static bool AllLinesPlayed = false;
    ControlInformer informer;
    string[] lines = new string[] { "", "", "", "", "","","","","",""};
    bool flag=true;

    void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        textComponent.text = string.Empty;
        lines[0] = "Player1:\nWhat a nice day to take Chicken MacChicken for a walk... Wait what on earth is that??";
        lines[1] = "EarthyQuaky:\nHaving fun ??? Not for long, your pet is now MINE.....";
        lines[2] = "Wise Man:\nI saw what happened there, sadly you are not the first one to have their pet stolen by EarthyQuaky," +
            "However, i know of a way to get your pet back. It involves learning what to do in case of an earthquake, enter the door"+
            " next to me to get started.";
        lines[3] = "Wise Man:\nWelcome Player1, now you will learn how to practice the Drop-Cover-Hold on method to stay safe in an" +
            " earthquake. Drop to the floor, take Cover under a table and Hold on to it until the earthquake is over. Go through the" +
            " door next to me to start the challenge!";
        lines[4] = "Wise Man:\nCongratulations on completing the first challenge, in the door next to me awaits the Stay-Where-You-Are challenge." +
            " If you are indoors you should stay indoors and if you are outdoors you should stay outdoors. Good Luck!";
        lines[5] = "Wise Man:\nCongratulations, few have come as far as you, im starting to believe that you can actually make it." +
            " Your next challenge is Dont-Get-Hit. In general you should avoid objects that might fall when an earthquake intensifies" +
            " like bookshelves, lapms and glass windows. You can always Drop-Cover-And-Hold-On. Good luck!";
        lines[6] = "Wise Man:\nWell done Player1, you are almost there. In the next challenge you will see a myth being disproven." +
            "For years standing under a doorway was considered safe, however modern doorways are not safe to" +
            " stand under when an earthquake occurs. You should avoid them. Good luck!";
        lines[7] = "Wise Man:\nCongratulations, in the next door awaits your final challenge, after that you will be able to reclaim" +
            " your pet. The challenge ? Always be prepared, you will need to gather supplies before an earthquake occurs. There might be a twist." +
            " Good Luck";
        lines[8]= "EarthyQuaky:\nOh....Well...Im sorry for stealing your pet, you know, im quite lonley and I" +
            " needed a friend, will you be my friend?                            ";
        lines[9] = "Player1:\nSure.... but i neet to get going though... Talk to you soon i guess...";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag) 
        {
            if (collision.CompareTag("Player"))
            {
                canvas.enabled = true;
                SceneManager(true);
                flag = false;
                playerMovement.canMove = false;
            }else if (collision.CompareTag("BBEG"))
            {
                SceneManager(false);
            }

        }
    }


    void SceneManager(bool IsPlayer)
    {
        switch (sceneIndex)
        {
            case 0:
                if (AllLinesPlayed) 
                {
                    LineToPlay = 0;
                    AllLinesPlayed = false;
                }
                if (IsPlayer && LineToPlay == 0)
                {
                    StartCoroutine(TypeLine(LineToPlay,false));
                    LineToPlay++;
                }else if (!IsPlayer)
                {
                    textComponent.text = string.Empty;
                    StartCoroutine(TypeLine(LineToPlay, true));
                    LineToPlay++;
                }else if (IsPlayer&& LineToPlay!=0)
                {
                    textComponent.text = string.Empty;
                    StartCoroutine(TypeLine(LineToPlay, true));
                    LineToPlay++;
                }
                break;

           case 1:
                LineToPlay=3;
                StartCoroutine(TypeLine(LineToPlay, true));
                LineToPlay++;
                break;

            case 2:
                LineToPlay = 4;
                StartCoroutine(TypeLine(LineToPlay, true));
                LineToPlay++;
                break;

            case 3:
                LineToPlay = 5;
                StartCoroutine(TypeLine(LineToPlay, true));
                LineToPlay++;
                break;

            case 4:
                LineToPlay = 6;
                StartCoroutine(TypeLine(LineToPlay, true));
                LineToPlay++;
                break;

            case 5:
                LineToPlay = 7;
                StartCoroutine(TypeLine(LineToPlay, true));
                LineToPlay++;
                break;

            case 6:
                LineToPlay = 8;
                AllLinesPlayed = true;
                StartCoroutine(TypeLine(LineToPlay, false));
                break;

        }
    }

    IEnumerator TypeLine(int LineToPlay,bool disable)
    {
        foreach (char c in lines[LineToPlay].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        if (disable) 
        {
            if (LineToPlay==1)
            {
                informer = GameObject.Find("DialogueTriggerBBEG").GetComponent<ControlInformer>();
                informer.inform = true;
            }
            playerMovement.canMove = true;
        }
        if (LineToPlay==8)
        {
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(9, true));
        }
        
    }
}
