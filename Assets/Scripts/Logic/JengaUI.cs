using TMPro;
using UnityEngine;

namespace Logic
{
    public class JengaUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] textDisplay;

        public void UpdateText(string text)
        {
            for (int i = 0; i < textDisplay.Length; i++)
            {
                textDisplay[i].SetText(text);
            }
        }
    }
}
