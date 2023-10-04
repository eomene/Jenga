using System;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.UI
{
    public class GameButtons : MonoBehaviour
    {
        private JengaManager manager;
        private Button actionButton;
        [SerializeField]private int mode;
        
        private void Awake()
        {
            actionButton = GetComponent<Button>();
            actionButton.onClick.AddListener(ActionExecuted);
        }

        private void ActionExecuted()
        {
            manager.ActivateAction(mode);
        }

        public void Init(JengaManager manager)
        {
            this.manager = manager;
        }
    }
}