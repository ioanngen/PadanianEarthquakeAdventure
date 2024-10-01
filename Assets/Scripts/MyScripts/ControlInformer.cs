using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PEA {
    public class ControlInformer : MonoBehaviour
    {
        public bool inform = false;
        [SerializeField] TextMeshProUGUI ControlInfo;
        void Start()
        {
            ControlInfo.text = string.Empty;
        }

        void Update()
        {
            if (inform) 
            {
                inform = false;
                ControlInfo.text = "Game: Use WASD or the arrow keys to move and space to jump";
                Invoke("RemoveControlInfo", 7f);
            }

        }
        void RemoveControlInfo()
        {
            ControlInfo.text = string.Empty;    
        }

    }
}