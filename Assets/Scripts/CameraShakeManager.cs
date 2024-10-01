using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using waypoints;

public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;

    [SerializeField] private float globalShakeForce = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;  
        }
    }

    public void CameraShake(CinemachineImpulseSource impulseSourse)
    {
        impulseSourse.GenerateImpulseWithForce(globalShakeForce);
    }
}
