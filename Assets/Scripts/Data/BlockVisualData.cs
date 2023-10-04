using System;
using System.Linq;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "BlockVisualData", menuName = "Jenga/BlockVisualData")]
    public class BlockVisualData : ScriptableObject
    {
        public JengaBlockVisualData[] potentialBlockData;

        public JengaBlockVisualData GetVisualData(Block block)
        {
            return potentialBlockData.FirstOrDefault(x => (int)x.blockLevel == block.mastery);
        }
    }
    public enum BlockLevel
    {
        Glass = 0,
        Wood = 1,
        Stone = 2
    }
    [Serializable]
    public class JengaBlockVisualData
    {
        public BlockLevel blockLevel;
        public string alias;
        public Texture blockTexture;
        public Color color;
    }

    
}