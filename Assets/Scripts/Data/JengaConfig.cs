using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Data
{
    [CreateAssetMenu(fileName = "JengaConfig", menuName = "Jenga/JengaConfig")]
    public class JengaConfig : ScriptableObject
    {
        public string stackName;
        public GameObject blockPrefab;  
        public float spacing = 1.25f;
        public int blocksPerLevel = 3;
        public Block[] Blocks;
        public string apiEndpoint = "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";
        public string levelTag = "6th Grade";

        [ContextMenu("Test Load")]
        public async UniTask TestLoadJson()
        {
            var response = await GetConfig();
        }
        
        public async UniTask<Block[]> GetConfig()
        {
            async UniTask<string> GetTextAsync(UnityWebRequest req)
            {
                var op = await req.SendWebRequest();
                return op.downloadHandler.text;
            }

            string response = await GetTextAsync(UnityWebRequest.Get(apiEndpoint));
            Blocks = ProcessJsonResponse(response);
            return Blocks;
        }

        Block[] ProcessJsonResponse(string json)
        {
            var fixJson = "{\n    \"Blocks\":" + json + "}";
            var fixedResults = JsonUtility.FromJson<JengaBlocks>(fixJson);

            return fixedResults.Blocks.Where(x => x.grade == levelTag).ToArray();
        }
    }
}