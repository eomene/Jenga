using Data;
using UnityEngine;

namespace Logic
{
    public class JengaStack : MonoBehaviour
    {
        [SerializeField]private JengaUI jengaUI;

        public void UpdateUI(string text)
        {
            jengaUI.UpdateText(text);
        }
    }


    public class JengaCreator
    {
        public JengaStack CreateStack(JengaConfig jengaConfig, JengaManager jengaManager, float offsetX, GameObject stackPrefab)
        {
            GameObject stackObject = GameObject.Instantiate(stackPrefab);
            stackObject.transform.position = new Vector3(offsetX, 0, 0);
            var stack = stackObject.GetComponent<JengaStack>();
            stack.UpdateUI(jengaConfig.stackName);
            int blockDataUsage = 0;
            int levels = jengaConfig.Blocks.Length / jengaConfig.blocksPerLevel;
            for (int i = 0; i < levels; i++)
            {
                float yOffset = i * jengaConfig.spacing;
                Vector3 position = new Vector3(offsetX, yOffset, 0);

                Quaternion rotation = Quaternion.Euler(0, i % 2 * 90, 0);

                for (int j = 0; j < jengaConfig.blocksPerLevel; j++)
                {
                    Vector3 offset = rotation * new Vector3(j - 1, 0, 0) * jengaConfig.spacing;
                    var block = GameObject.Instantiate(jengaConfig.blockPrefab, position + offset, rotation);
                    var jengaBlock = block.GetComponent<JengaBlock>();
                    jengaBlock.Init(jengaConfig.Blocks[blockDataUsage], jengaManager);
                    block.transform.SetParent(stack.transform);
                    blockDataUsage++;
                }
            }

            return stack;
        }
    }
}