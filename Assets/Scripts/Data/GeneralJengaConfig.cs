using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [CreateAssetMenu(fileName = "GeneralJengaConfig", menuName = "Jenga/GeneralJengaConfig")]
    public class GeneralJengaConfig : ScriptableObject
    {
        public JengaConfig[] jengaConfigs;
        public float stackSpacing;
        [FormerlySerializedAs("stack")] public GameObject stackPrefab;
    }
    [Serializable]
    public class Block
    {
        public int id;
        public string subject;
        public string grade;
        public int mastery;
        public string domainid;
        public string domain;
        public string cluster;
        public string standardid;
        public string standarddescription;
    }

    public class JengaBlocks
    {
        public List<Block> Blocks;
    }

}
