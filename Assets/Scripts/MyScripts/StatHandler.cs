using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StatHandle { 
public class StatHandler : MonoBehaviour
{
        static int[] DeathsPerLevel = { 0, 0, 0, 0, 0 };
        [SerializeField] Text[] levels; 
        public void LoadStats()
        {
            if (SceneManager.GetActiveScene().buildIndex==13) 
            {
                int i = 0;
                foreach(Text t in levels)
                {
                    levels[i].text = "Level " + (i+1) + " Deaths: " + DeathsPerLevel[i];
                    i++;   
                }
            }
        }

        public void GetStats(int[] Deaths)
        {
            for(int i = 0; i <= 4; i++)
            {
                DeathsPerLevel[i] = Deaths[i];
            }
        }

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex == 13)
            {
                LoadStats();
            }
        }
    }
}