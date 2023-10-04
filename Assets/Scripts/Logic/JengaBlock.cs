using System;
using Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Logic
{
    public class JengaBlock : MonoBehaviour
    {
        [SerializeField] private MeshRenderer renderer;
        [SerializeField] private BlockVisualData blockVisualData;
        [SerializeField] public Block block { get; private set; }

        [FormerlySerializedAs("jengaBlockUI")] [SerializeField] private JengaUI jengaUI;
        private JengaManager jengaManager;

        public void Init(Block block, JengaManager jengaManager)
        {
            this.block = block;
            this.jengaManager = jengaManager;
            HandleVisual(this.block);
        }

        private void HandleVisual(Block block)
        {
            var visual = blockVisualData.GetVisualData(block);
            //renderer.material.mainTexture = visual.blockTexture;
            renderer.material.color = visual.color;
            if (jengaUI)
                jengaUI.UpdateText(visual.alias);
        }

        public void OnMouseDown()
        {
            string data = $"{block.grade}: {block.domain}\n[{block.cluster}]\n{block.standardid}: {block.standarddescription}";
            if (jengaManager)
                jengaManager.ShowDetails(data);
        }
    }
}