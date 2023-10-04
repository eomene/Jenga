using System;
using UnityEngine;
using System.Collections.Generic;
using Cinemachine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField]private List<Transform> targets;
    private CinemachineFreeLook freeLookCamera;
    [SerializeField]private int currentTargetIndex = 0;

    private void Awake()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    public void Init(List<Transform> targets)
    {
        this.targets = targets;
        if (targets.Count > 0 && freeLookCamera != null)
        {
            SetTarget(targets[currentTargetIndex]);
        }
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || targets.Count <= 0 || freeLookCamera == null)
            return;
        
        currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
        SetTarget(targets[currentTargetIndex]);
    }

    void SetTarget(Transform target)
    {
        freeLookCamera.Follow = target;
        freeLookCamera.LookAt = target;
    }
}