using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StatHandle;

namespace PLF
{
    public class PlayerLife : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D body;
        static int[] DeathsPerLevel = new int[] { 0, 0, 0, 0, 0};
        static int CurrentLevelDeaths;
        [SerializeField] AudioSource deathSoundEffect;
        [SerializeField] Text DeathsText;
        int CurrentScene;
        public static bool restarted = false;
        void Start()
        {
            if (!restarted)
            {
                CurrentLevelDeaths = 0;
            }
            CurrentScene = SceneManager.GetActiveScene().buildIndex;
            if (CurrentScene == 12)
            {
                this.gameObject.GetComponent<StatHandler>().GetStats(DeathsPerLevel);
            }
            if (DeathsText != null)
            {
                DeathsText.text = "Deaths: " + CurrentLevelDeaths;
            }
            body = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Deadly"))
            {


                deathSoundEffect.Play();
                CurrentLevelDeaths++;
                DeathsText.text = "Deaths: " + CurrentLevelDeaths;
                switch (CurrentScene)
                {
                    case 3://DCH
                        DeathsPerLevel[0]++;
                        break;

                    case 5://LVL2
                        DeathsPerLevel[1]++;
                        break;

                    case 7://LVL3
                        DeathsPerLevel[2]++;
                        break;

                    case 9://LVL4
                        DeathsPerLevel[3]++;
                        break;

                    case 11://Supplies
                        DeathsPerLevel[4]++;
                        break;
                }
                Die();
            }
        }

        void Die()
        {
            animator.SetTrigger("Death");
            body.bodyType = RigidbodyType2D.Static;
        }

        void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            restarted = true;
        }
    }

}