using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Logic
{
    public class OrbitCamera : MonoBehaviour
    {
        [SerializeField]private List<JengaStack> targets;
        private CinemachineFreeLook freeLookCamera;
        [SerializeField]private int currentTargetIndex = 0;

        private void Awake()
        {
            freeLookCamera = GetComponent<CinemachineFreeLook>();
        }

        public void Init(List<JengaStack> targets)
        {
            this.targets = targets;
            if (targets.Count > 0 && freeLookCamera != null)
            {
                SetTarget(targets[currentTargetIndex].transform);
            }
        }

        void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space) || targets.Count <= 0 || freeLookCamera == null)
                return;
        
            currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
            SetTarget(targets[currentTargetIndex].transform);
        }

        void SetTarget(Transform target)
        {
            freeLookCamera.Follow = target;
            freeLookCamera.LookAt = target;
        }
    }
}