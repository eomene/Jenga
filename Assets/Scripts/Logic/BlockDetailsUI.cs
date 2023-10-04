using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class BlockDetailsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textDisplay;
        [SerializeField] private Button close;

        private void Awake()
        {
            close.onClick.AddListener(Close);
        }

        private void Close()
        {
            textDisplay.SetText("");
            gameObject.SetActive(false);
        }

        public void Show(string text)
        {
            textDisplay.SetText(text);
            gameObject.SetActive(true);
        }
    }
}
