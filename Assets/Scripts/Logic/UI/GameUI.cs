using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Logic.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameButtons[] actionButtons;
        [SerializeField] private JengaManager jengaManager;
        
        private void Awake()
        {
            for (int i = 0; i < actionButtons.Length; i++)
            {
                actionButtons[i].Init(jengaManager);
            }
        }
    }
}