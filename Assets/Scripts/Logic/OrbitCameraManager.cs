using System.Collections.Generic;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logic
{
    public class OrbitCameraManager : MonoBehaviour
    {
        [SerializeField] private List<JengaStack> targets;
        private CinemachineFreeLook freeLookCamera;
        [SerializeField] private int currentTargetIndex = 0;
        private bool inited;

        private void Awake()
        {
            freeLookCamera = GetComponent<CinemachineFreeLook>();
            inited = false;
        }

        public async UniTask Init(List<JengaStack> targets)
        {
            this.targets = targets;
            if (targets.Count > 0 && freeLookCamera != null)
            {
               await SetTarget(targets[currentTargetIndex].transform);
            }
            inited = true;
        }

        void Update()
        {
            if (!inited)
                return;
            
            freeLookCamera.enabled = Input.GetMouseButton(0);

            if (!Input.GetKeyDown(KeyCode.Space) || targets.Count <= 0 || freeLookCamera == null)
                return;

            currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
            SetTarget(targets[currentTargetIndex].transform).Forget();
        }

        private async UniTask SetTarget(Transform target)
        {
            freeLookCamera.Follow = target;
            freeLookCamera.LookAt = target;
            freeLookCamera.enabled = true;
            await UniTask.DelayFrame(10);
            freeLookCamera.enabled = false;
        }
    }
}