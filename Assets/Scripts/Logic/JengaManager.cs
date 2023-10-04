using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Logic
{
    public class JengaManager : MonoBehaviour
    {
        [SerializeField] private GeneralJengaConfig jengaConfig;
        [FormerlySerializedAs("orbitCamera")] [SerializeField] private OrbitCameraManager orbitCameraManager;
        [SerializeField] private BlockDetailsUI blockDetailsUI;
        List<JengaStack> stacks = new List<JengaStack>();

        
        void Awake()
        {
            CreateMultipleStacks().Forget();
        }

        private async UniTask CreateMultipleStacks()
        {
            JengaCreator jengaCreator = new JengaCreator();
            for (int stackIndex = 0; stackIndex < jengaConfig.jengaConfigs.Length; stackIndex++)
            {
                var config = jengaConfig.jengaConfigs[stackIndex];
                await config.GetConfig();
                float stackOffsetX = stackIndex * jengaConfig.stackSpacing;
                var jenga = jengaCreator.CreateStack(config, this,stackOffsetX,jengaConfig.stackPrefab);
                stacks.Add(jenga);
            }

            orbitCameraManager.Init(stacks).Forget();
        }

        public void ShowDetails(string selected)
        {
            blockDetailsUI.Show(selected);
        }

        public void ActivateAction(int mode)
        {
            for (int i = 0; i < stacks.Count; i++)
            {
                stacks[i].ActivateMode(mode);
            }
        }
    }
}

