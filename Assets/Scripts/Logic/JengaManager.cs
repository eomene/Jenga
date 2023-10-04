using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace Logic
{
    public class JengaManager : MonoBehaviour
    {
        [SerializeField] private GeneralJengaConfig jengaConfig;
        [SerializeField] private OrbitCamera orbitCamera;
        [SerializeField] private BlockDetailsUI blockDetailsUI;
        
        void Awake()
        {
            CreateMultipleStacks().Forget();
        }

        private async UniTask CreateMultipleStacks()
        {
            JengaCreator jengaCreator = new JengaCreator();
            List<Transform> stacks = new List<Transform>();
            for (int stackIndex = 0; stackIndex < jengaConfig.jengaConfigs.Length; stackIndex++)
            {
                var config = jengaConfig.jengaConfigs[stackIndex];
                await config.GetConfig();
                float stackOffsetX = stackIndex * jengaConfig.stackSpacing;
                var jenga = jengaCreator.CreateStack(config, this,stackOffsetX,jengaConfig.stackPrefab);
                stacks.Add(jenga.transform);
            }

            orbitCamera.Init(stacks);
        }

        public void ShowDetails(string selected)
        {
            blockDetailsUI.Show(selected);
        }
    }
}

